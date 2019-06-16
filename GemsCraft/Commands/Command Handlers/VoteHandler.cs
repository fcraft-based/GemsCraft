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

using System.Collections.Generic;
using System.Threading;
using GemsCraft.fSystem;
using GemsCraft.Players;

namespace GemsCraft.Commands.Command_Handlers
{
    public class VoteHandler
    {
        public static string Usage;
        public static int VotedYes;
        public static int VotedNo;
        public static List<Player> Voted;
        public static string VoteStarter;
        public static bool VoteIsOn;
        public static Thread VoteThread;
        public static string VoteKickReason;
        public static string TargetName;
        public static string Question;

        public static void NewVote()
        {
            Usage = "&A/Vote Yes | No | Ask | Abort";
            VotedYes = 0;
            VotedNo = 0;
            Voted = new List<Player>();
            VoteIsOn = true;
        }

        public static void VoteParams(Player player, Command cmd)
        {
            string option = cmd.Next();
            if (option == null) { player.Message("Invalid param"); return; }
            switch (option)
            {
                default:
                    if (VoteIsOn)
                    {
                        if (VoteKickReason == null)
                        {
                            player.Message("Last Question: {0}&C asked: {1}", VoteStarter, Question);
                            player.Message(Usage);
                            return;
                        }
                        else
                            player.Message("Last VoteKick: &CA VoteKick has started for {0}&C, reason: {1}", TargetName, VoteKickReason);
                        player.Message(Usage);
                    }
                    else
                        player.Message(option);
                    break;

                case "abort":
                case "stop":
                    if (!VoteIsOn)
                    {
                        player.Message("No vote is currently running");
                        return;
                    }

                    if (!player.Can(Permission.MakeVotes))
                    {
                        player.Message("You do not have Permission to abort votes");
                        return;
                    }
                    VoteIsOn = false;
                    foreach (Player v in Voted)
                    {
                        if (v.Info.HasVoted)
                            v.Info.HasVoted = false;
                        v.Message("Your vote was cancelled");
                    }
                    Voted.Clear();
                    TargetName = null;
                    Server.Players.Message("{0} &Saborted the vote.", 0, player.ClassyName);
                    break;

                case "yes":
                    if (!VoteIsOn)
                    {
                        player.Message("No vote is currently running");
                        return;
                    }

                    if (player.Info.HasVoted)
                    {
                        player.Message("&CYou have already voted");
                        return;
                    }
                    Voted.Add(player);
                    VotedYes++;
                    player.Info.HasVoted = true;
                    player.Message("&8You have voted for 'Yes'");
                    break;

                case "no":
                    if (!VoteIsOn)
                    {
                        player.Message("No vote is currently running");
                        return;
                    }
                    if (player.Info.HasVoted)
                    {
                        player.Message("&CYou have already voted");
                        return;
                    }
                    VotedNo++;
                    Voted.Add(player);
                    player.Info.HasVoted = true;
                    player.Message("&8You have voted for 'No'");
                    break;

                case "ask":
                    string askQuestion = cmd.NextAll();
                    Question = askQuestion;
                    if (!player.Can(Permission.MakeVotes))
                    {
                        player.Message("You do not have permissions to ask a question");
                        return;
                    }
                    if (VoteIsOn)
                    {
                        player.Message("A vote has already started. Each vote lasts 1 minute.");
                        return;
                    }
                    if (Question.Length < 5)
                    {
                        player.Message("Invalid question");
                        return;
                    }

                    VoteThread = new Thread(new ThreadStart(delegate
                    {
                        NewVote();
                        VoteStarter = player.ClassyName;
                        Server.Players.Message("{0}&S Asked: {1}", MessageType.Announcement, player.ClassyName, Question);
                        Server.Players.Message("&9Vote now! &S/Vote &AYes &Sor /Vote &CNo", 0);
                        VoteIsOn = true;
                        Thread.Sleep(60000);
                        VoteCheck();
                    })); VoteThread.Start();
                    break;
            }
        }

        private static void VoteCheck()
        {
            if (!VoteIsOn) return;
            Server.Players.Message("{0}&S Asked: {1} \n&SResults are in! Yes: &A{2} &SNo: &C{3}", 0, VoteStarter,
                Question, VotedYes, VotedNo);
            VoteIsOn = false;
            foreach (Player v in Voted)
            {
                v.Info.HasVoted = false;
            }
        }
    }
}


