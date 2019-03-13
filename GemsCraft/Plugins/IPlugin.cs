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

//Copyright (C) <2012> Glenn Mariën (http://project-vanilla.com)

using System;
using System.ComponentModel;
using GemsCraft.Utils;
using Text = GemsCraft.Utils.EnumText;
using Version = GemsCraft.Utils.Version;

namespace GemsCraft.Plugins
{
    public interface IPlugin
    {
        #region Info

        string Name { get; set; }
        string Version { get; set; }
        string Author { get; set; }
        DateTime ReleaseDate { get; set; }
        string FileName { get; set; }
        Version SoftwareVersion { get; set; }

        #endregion

        #region Software Settings

        bool Enabled { get; set; }

        #endregion

        void Initialize();

        void Save();

        IPlugin Load();
    }
}
