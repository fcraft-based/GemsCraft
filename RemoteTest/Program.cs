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
    class Program
    {
        static void Main(string[] args)
        {
            XElement x = new XElement("HelloWWorld");
            x.Add("Hi there my friend!");
            x.Add("I'm stupid!");
            Console.WriteLine(x.ToString());

            Console.ReadLine();
        }
    }
}
