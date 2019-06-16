﻿//Copyright (C) <2012>  <Jon Baker, Glenn Mariën and Lao Tszy>

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

using System;
using System.Diagnostics;
using System.IO;
using GemsCraft.Events;
using GemsCraft.fSystem;
using GemsCraft.Configuration;

namespace GemsCraft.Utils
{
    class HeartbeatSaverUtil
    {
        public static void Init()
        {
            EventHandler<CrashedEventArgs> Crash = new EventHandler<CrashedEventArgs>(HbCrashEvent);
        }
        public static void HbCrashEvent(object sender, CrashedEventArgs e)
        {
            if (!e.ShutdownImminent.Equals(true)) return;
            if (!ConfigKey.HbSaverKey.Enabled()) return;
            if (!ConfigKey.HbSaverKey.Enabled()) return;
            if (!File.Exists("heartbeatsaver.exe"))
            {
                            
                return;
            }

            //start the heartbeat saver
            Process HeartbeatSaver = new Process {StartInfo = {FileName = "heartbeatsaver.exe"}};
            HeartbeatSaver.Start();
        }
    }
}
