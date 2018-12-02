using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fCraft.GUI.ConfigGUI.GUI.Sections;

namespace fCraft.GUI.ConfigGUI.GUI
{
    /// <summary>
    /// All data entered will be stored statically in the form-objects here
    /// This way, when a new config window is opened, it retains all the information that was just entered
    /// :o
    /// </summary>
    public class SectionClasses
    {
        internal static GeneralConfig GeneralConfig;
        internal static ChatConfig ChatConfig;
        internal static WorldConfig WorldConfig;
        internal static RankConfig RankConfig;
        internal static SecurityConfig SecurityConfig;
        internal static SavingConfig SavingConfig;
        internal static LoggingConfig LoggingConfig;
        internal static IRCConfig IRCConfig;
        internal static AdvancedConfig AdvancedConfig;
        internal static MiscConfig MiscConfig;
    }
}
