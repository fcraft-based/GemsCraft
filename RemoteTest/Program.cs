using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace RemoteTest
{
    enum Hello { What = 0, To = 1, Me = 2}
    class Program
    {
        static void Main(string[] args)
        {
            Hello h = (Hello) 25;
            Console.WriteLine("WHAT" + h.ToString() + " HI!");
            Console.ReadLine();
        }
    }
}
