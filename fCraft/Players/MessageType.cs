using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemsCraft.Players
{
    public enum MessageType // Comments from CPE suggested implementations
    {
        /// <summary>
        /// Normal message, shown in the chat area
        /// </summary>
        Chat = 0,
        /// <summary>
        /// Shown persistently in the top-right corner of the screen, in regular font
        /// </summary>
        Status1 = 1,
        /// <summary>
        /// Shown persistently just below Status 1
        /// </summary>
        Status2 = 2,
        /// <summary>
        /// Shown persistently just below Status 2
        /// </summary>
        Status3 = 3,
        /// <summary>
        /// Shown persistently in the bottom-right corner of the screen, in regular font
        /// </summary>
        BottomRight1 = 11,
        /// <summary>
        /// Shown persistently just above BottomRight1
        /// </summary>
        BottomRight2 = 12,
        /// <summary>
        /// Shown persistently just above BottomRight2
        /// </summary>
        BottomRight3 = 13,
        /// <summary>
        /// Pops up in a larger font near the top-center of the screen. Fades out after a few seconds
        /// </summary>
        Announcement = 100
    }
}
