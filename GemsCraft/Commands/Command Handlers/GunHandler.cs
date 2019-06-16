//Copyright (C) <2012>  <Jon Baker, Glenn Mariën and Lao Tszy>

//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.

//Copyright (C) <2012> Jon Baker (http://au70.net)

using System;
using System.Collections.Concurrent;
using System.Threading;
using GemsCraft.Events;
using GemsCraft.fSystem;
using GemsCraft.Games;
using GemsCraft.Network;
using GemsCraft.Physics;
using GemsCraft.Players;
using GemsCraft.Utils;
using GemsCraft.Worlds;
using Map = GemsCraft.Worlds.Map;
// ReSharper disable StringLiteralTypo

namespace GemsCraft.Commands.Command_Handlers
{
    public class GunGlassTimer
    {
        private readonly Timer _timer;
        private bool _started;
        private readonly Player _player;
        private const int Tick = 125;
        private readonly object _objectLock = new object();
        public GunGlassTimer(Player player)
        {
            _player = player;
            _started = false;
            _timer = new Timer(Callback, null, Timeout.Infinite, Timeout.Infinite);
        }
        public void Start()
        {
            lock (_objectLock)
            {
                if (_started) return;
                _started = true;
                _timer.Change(0, Timeout.Infinite);
            }
        }
        public void Stop()
        {
            lock (_objectLock)
            {
                _started = false;
                _timer.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }
        private void Callback(object state)
        {
            try
            {
                if (_player.IsOnline && _player != null)
                {
                    if (_player.GunMode)
                    {
                        GunClass.GunMove(_player);
                    }
                    else
                    {
                        Stop();
                    }
                }
                else
                {
                    Stop();
                }
            }
            catch (Exception e)
            {
                Logger.Log(LogType.Error, "GunGlassTimer: " + e);
            }

            lock (_objectLock)
            {
                if (_started)
                    _timer.Change(Tick, Timeout.Infinite);
            }
        }
    }

    internal class GunClass
    {
        public static void Init()
        {
            Player.Clicking += ClickedGlass;
            Player.JoinedWorld += ChangedWorld;
            Player.Moving += MovePortal;
            Player.Disconnected += PlayerDisconnected;
            Player.PlacingBlock += PlayerPlaced;
            CommandManager.RegisterCommand(CdGun);
        }
        private static readonly CommandDescriptor CdGun = new CommandDescriptor
        {
            Name = "Gun",
            Category = CommandCategory.Moderation,
            IsConsoleSafe = false,
            Permissions = new[] { Permission.Gun },
            Usage = "/Gun",
            Help = "Fire At Will! TNT blocks explode TNT with physics on, Blue blocks make a Blue Portal, Orange blocks make an Orange Portal.",
            Handler = GunHandler
        };

        public static void GunHandler(Player player, Command cmd)
        {
            //to prevent players from doing /gun during a TDM game that arent actually playing in
            if (player.World != null && (player.World.gameMode == GameMode.TeamDeathMatch && !player.Info.isPlayingTD))
            {
                player.Message("Players who are not playing Team DeathMatch can only spectate.");
                return;
            }

            if (player.Info.isPlayingCTF && player.Info.gunDisarmed)
            {
                player.Message("You are currently disarmed. You cannot use a gun until the disarm powerup has worn off.");
                return;
            }
            if (player.GunMode)
            {
                player.GunMode = false;
                try
                {
                    foreach (Vector3I block in player.GunCache.Values)
                    {
                        player.Send(PacketWriter.MakeSetBlock(block.X, block.Y, block.Z, player.WorldMap.GetBlock(block)));
                        player.GunCache.TryRemove(block.ToString(), out _);
                    }
                    if (player.bluePortal.Count > 0)
                    {
                        int i = 0;
                        foreach (Vector3I block in player.bluePortal)
                        {
                            if (player.World == null || !player.World.IsLoaded) continue;
                            player.WorldMap.QueueUpdate(new BlockUpdate(null, block, player.blueOld[i]));
                            i++;
                        }
                        player.blueOld.Clear();
                        player.bluePortal.Clear();
                    }
                    if (player.orangePortal.Count > 0)
                    {
                        int i = 0;
                        foreach (Vector3I block in player.orangePortal)
                        {
                            if (player.World == null || !player.World.IsLoaded) continue;
                            player.WorldMap.QueueUpdate(new BlockUpdate(null, block, player.orangeOld[i]));
                            i++;
                        }
                        player.orangeOld.Clear();
                        player.orangePortal.Clear();
                    }
                    player.Message("&SGunMode deactivated");
                }
                catch (Exception ex)
                {
                    Logger.Log(LogType.SeriousError, "" + ex);
                }
            }
            else
            {
                if (player.World != null && !player.World.gunPhysics)
                {
                    player.Message("&WGun physics are disabled on this world");
                    return;
                }
                player.GunMode = true;
                GunGlassTimer timer = new GunGlassTimer(player);
                timer.Start();
                player.Message("&SGunMode activated. Fire at will!");
            }
        }

        public static void GunMove(Player player)
        {
            World world = player.World;
            if (null == world) return;
            try
            {
                lock (world.SyncRoot)
                {
                    if (null == world.Map) return;
                    if (!player.IsOnline) return;
                    Position p = player.Position;
                    double ksi = 2.0 * Math.PI * (-player.Position.L) / 256.0;
                    double phi = 2.0 * Math.PI * (player.Position.R - 64) / 256.0;
                    double sphi = Math.Sin(phi);
                    double cphi = Math.Cos(phi);
                    double sksi = Math.Sin(ksi);
                    double cksi = Math.Cos(ksi);

                    if (player.IsOnline)
                    {
                        if (player.GunCache.Values.Count > 0)
                        {
                            foreach (Vector3I block in player.GunCache.Values)
                            {
                                if (!player.IsOnline) continue;
                                player.Send(PacketWriter.MakeSetBlock(block.X, block.Y, block.Z, world.Map.GetBlock(block)));
                                player.GunCache.TryRemove(block.ToString(), out _);
                            }
                        }
                    }

                    for (int y = -1; y < 2; ++y)
                    {
                        for (int z = -1; z < 2; ++z)
                        {
                            if (!player.IsOnline) continue;
                            //4 is the distance betwen the player and the glass wall
                            Vector3I glassBlockPos = new Vector3I((int)(cphi * cksi * 4 - sphi * (0.5 + y) - cphi * sksi * (0.5 + z)),
                                (int)(sphi * cksi * 4 + cphi * (0.5 + y) - sphi * sksi * (0.5 + z)),
                                (int)(sksi * 4 + cksi * (0.5 + z)));
                            glassBlockPos += p.ToBlockCoords();
                            if (world.Map.GetBlock(glassBlockPos) != Block.Air) continue;
                            player.Send(PacketWriter.MakeSetBlock(glassBlockPos, Block.Glass));
                            player.GunCache.TryAdd(glassBlockPos.ToString(), glassBlockPos);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(LogType.SeriousError, "GunGlass: " + ex);
            }
        }



        public static void PlayerPlaced(object sender, PlayerPlacingBlockEventArgs e)
        {
            try
            {
                if (e.Player.World == null) return;
                foreach (Player p in e.Player.World.Players)
                {
                    if (e.OldBlock != Block.Water && e.OldBlock != Block.Lava) continue;
                    if (p.orangePortal.Contains(e.Coords) || p.bluePortal.Contains(e.Coords))
                    {
                        e.Result = CanPlaceResult.Revert;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(LogType.SeriousError, "PlacingInPortal: " + ex);
            }
        }

        private static readonly TntBulletBehavior TntBulletBehavior = new TntBulletBehavior();
        private static readonly BulletBehavior BulletBehavior = new BulletBehavior();

        public static void ClickedGlass(object sender, PlayerClickingEventArgs e)
        {
            if (!e.Player.GunMode || e.Player.Info.IsHidden || e.Player.Info.IsFrozen) return;
            World world = e.Player.World;

            if (!e.Player.GunCache.Values.Contains(e.Coords)) return;
            if (world != null && !world.gunPhysics) return;
            e.Player.Send(PacketWriter.MakeSetBlock(e.Coords.X, e.Coords.Y, e.Coords.Z, Block.Glass));
            if (world != null && e.Block == Block.TNT && world.tntPhysics)
            {
                if (!e.Player.CanFireTNT()) return;
                double ksi = 2.0 * Math.PI * (-e.Player.Position.L) / 256.0;
                double r = Math.Cos(ksi);
                double phi = 2.0 * Math.PI * (e.Player.Position.R - 64) / 256.0;
                Vector3F dir = new Vector3F((float)(r * Math.Cos(phi)), (float)(r * Math.Sin(phi)), (float)(Math.Sin(ksi)));
                world.AddPhysicsTask(new Particle(world, e.Coords, dir, e.Player, Block.TNT, TntBulletBehavior), 0);
            }
            else
            {
                Block block = e.Block;
                if (block == Block.Blue) block = Block.Water;
                if (block == Block.Orange) block = Block.Lava;
                double ksi = 2.0 * Math.PI * (-e.Player.Position.L) / 256.0;
                double r = Math.Cos(ksi);
                double phi = 2.0 * Math.PI * (e.Player.Position.R - 64) / 256.0;
                Vector3F dir = new Vector3F((float)(r * Math.Cos(phi)), (float)(r * Math.Sin(phi)), (float)(Math.Sin(ksi)));
                world?.AddPhysicsTask(new Particle(world, e.Coords, dir, e.Player, block, BulletBehavior), 0);
            }
        }


        public static void MovePortal(object sender, PlayerMovingEventArgs e)
        {
            try
            {
                if ((DateTime.Now - e.Player.LastUsedPortal).TotalSeconds < 4)
                {
                    return;
                }
                Vector3I newPos = new Vector3I(e.NewPosition.X / 32, e.NewPosition.Y / 32, e.NewPosition.Z / 32);
                if (e.Player.World == null) return;
                foreach (Player p in e.Player.World.Players)
                {
                    foreach (Vector3I block in p.bluePortal)
                    {
                        if (newPos != block) continue;
                        if (p.World?.Map != null && (p.World != null && p.World.Map.GetBlock(block) != Block.Water)) continue;
                        if (p.orangePortal.Count > 0)
                        {
                            e.Player.TeleportTo(new Position
                            {
                                X = (short) (((p.orangePortal[0].X) + 0.5) * 32),
                                Y = (short) (((p.orangePortal[0].Y) + 0.5) * 32),
                                Z = (short) (((p.orangePortal[0].Z) + 1.59375) * 32),
                                R = (byte) (p.blueOut - 128),
                                L = e.Player.Position.L
                            });
                        }

                        e.Player.LastUsedPortal = DateTime.Now;
                    }

                    foreach (Vector3I block in p.orangePortal)
                    {
                        if (newPos != block) continue;
                        if (p.World?.Map != null && (p.World != null && p.World.Map.GetBlock(block) != Block.Lava)) continue;
                        if (p.bluePortal.Count > 0)
                        {
                            e.Player.TeleportTo(new Position
                            {
                                X = (short) (p.bluePortal[0].X + 0.5 * 32),
                                Y = (short) (p.bluePortal[0].Y + 0.5 * 32),
                                Z = (short) ((p.bluePortal[0].Z + 1.59375) *
                                             32), //fixed point 1.59375 lol.
                                R = (byte) (p.orangeOut - 128),
                                L = e.Player.Position.L
                            });
                        }

                        e.Player.LastUsedPortal = DateTime.Now;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(LogType.SeriousError, "MovePortal: " + ex);
            }
        }

        public static void ChangedWorld(object sender, PlayerJoinedWorldEventArgs e)
        {
            try
            {
                if (e.OldWorld == null) return;
                if (e.OldWorld.Name == e.NewWorld.Name)
                {
                    e.Player.orangeOld.Clear();
                    e.Player.orangePortal.Clear();
                    e.Player.blueOld.Clear();
                    e.Player.bluePortal.Clear();
                }
                if (e.OldWorld.IsLoaded)
                {
                    Map map = e.OldWorld.Map;
                    if (e.Player.orangePortal.Count > 0)
                    {
                        int i = 0;
                        foreach (Vector3I block in e.Player.orangePortal)
                        {
                            map?.QueueUpdate(new BlockUpdate(null, block, e.Player.orangeOld[i]));
                            i++;
                        }
                        e.Player.orangeOld.Clear();
                        e.Player.orangePortal.Clear();
                    }

                    if (e.Player.bluePortal.Count <= 0) return;
                    {
                        int i = 0;
                        foreach (Vector3I block in e.Player.bluePortal)
                        {
                            map?.QueueUpdate(new BlockUpdate(null, block, e.Player.blueOld[i]));
                            i++;
                        }
                        e.Player.blueOld.Clear();
                        e.Player.bluePortal.Clear();
                    }
                }
                else
                {
                    if (e.Player.bluePortal.Count > 0)
                    {
                        if (e.OldWorld.Map != null)
                        {
                            e.OldWorld.Map.Blocks[e.OldWorld.Map.Index(e.Player.bluePortal[0])] =
                                (byte) e.Player.blueOld[0];
                            e.OldWorld.Map.Blocks[e.OldWorld.Map.Index(e.Player.bluePortal[1])] =
                                (byte) e.Player.blueOld[1];
                        }

                        e.Player.blueOld.Clear();
                        e.Player.bluePortal.Clear();
                    }

                    if (e.Player.orangePortal.Count <= 0) return;
                    if (e.OldWorld.Map != null)
                    {
                        e.OldWorld.Map.Blocks[e.OldWorld.Map.Index(e.Player.orangePortal[0])] =
                            (byte) e.Player.orangeOld[0];
                        e.OldWorld.Map.Blocks[e.OldWorld.Map.Index(e.Player.orangePortal[1])] =
                            (byte) e.Player.orangeOld[1];
                    }

                    e.Player.orangeOld.Clear();
                    e.Player.orangePortal.Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(LogType.SeriousError, "GunPortalChangeWorld: " + ex);
            }
        }

        public static void PlayerDisconnected(object sender, PlayerDisconnectedEventArgs e)
        {
            try
            {
                if (e.Player.World == null) return;
                if (e.Player.World.IsLoaded)
                {
                    Map map = e.Player.World.Map;
                    if (e.Player.orangePortal.Count > 0)
                    {
                        int i = 0;
                        foreach (Vector3I block in e.Player.orangePortal)
                        {
                            map?.QueueUpdate(new BlockUpdate(null, block, e.Player.orangeOld[i]));
                            i++;
                        }
                        e.Player.orangeOld.Clear();
                        e.Player.orangePortal.Clear();
                    }

                    if (e.Player.bluePortal.Count <= 0) return;
                    {
                        int i = 0;
                        foreach (Vector3I block in e.Player.bluePortal)
                        {
                            map?.QueueUpdate(new BlockUpdate(null, block, e.Player.blueOld[i]));
                            i++;
                        }
                        e.Player.blueOld.Clear();
                        e.Player.bluePortal.Clear();
                    }
                }
                else
                {
                    if (e.Player.bluePortal.Count > 0)
                    {
                        if (e.Player.World.Map != null)
                        {
                            e.Player.World.Map.Blocks[e.Player.World.Map.Index(e.Player.bluePortal[0])] =
                                (byte) e.Player.blueOld[0];
                            e.Player.World.Map.Blocks[e.Player.World.Map.Index(e.Player.bluePortal[1])] =
                                (byte) e.Player.blueOld[1];
                        }
                    }

                    if (e.Player.orangePortal.Count <= 0) return;
                    e.Player.WorldMap.Blocks[e.Player.WorldMap.Index(e.Player.orangePortal[0])] = (byte)e.Player.orangeOld[0];
                    e.Player.WorldMap.Blocks[e.Player.WorldMap.Index(e.Player.orangePortal[1])] = (byte)e.Player.orangeOld[1];
                }
            }
            catch (Exception ex)
            {
                Logger.Log(LogType.SeriousError, "GunPortalDisconnected: " + ex);
            }
        }
        public static void Removal(ConcurrentDictionary<string, Vector3I> bullets, Map map)
        {
            foreach (Vector3I bp in bullets.Values)
            {
                map.QueueUpdate(new BlockUpdate(null,
                    (short)bp.X,
                    (short)bp.Y,
                    (short)bp.Z,
                    Block.Air));
                bullets.TryRemove(bp.ToString(), out _);
            }
        }


        public static bool CanPlacePortal(short x, short y, short z, Map map)
        {
            int count = 0;
            // ReSharper disable once InconsistentNaming
            for (short Z = z; Z < z + 2; Z++)
            {
                Block check = map.GetBlock(x, y, Z);
                if (check != Block.Air && check != Block.Water && check != Block.Lava)
                {
                    count++;
                }
            }
            return count == 2;
        }
    }
}
