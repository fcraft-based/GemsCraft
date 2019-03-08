using System;
using System.Collections.Generic;

namespace GemsCraft.AutoRank
{
    /// <summary>
    /// Simple class to hold values for autorank conditions
    /// </summary>
    public class Condition
    {
        // Values
        public string StartingRank;
        public string EndingRank;
        public Dictionary<string, Tuple<string, int>> Conditions = new Dictionary<string, Tuple<string, int>>();

        // Constructor
        public Condition(string start, string end, string cond, string oper, string val)
        {
            StartingRank = start;
            EndingRank = end;
            Conditions.Add(cond, new Tuple<string, int>(oper, Convert.ToInt32(val)));
        }

    }
}
