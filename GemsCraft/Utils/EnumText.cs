using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemsCraft.Utils
{
    public class EnumText : Attribute
    {

        public EnumText(string text)
        {
            Text = text;
        }


        public string Text { get; set; }
    }
}
