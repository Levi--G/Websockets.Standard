using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websockets.SharedTest;

namespace Websockets.NetTests
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1) Link in your main activity
            Websockets.Net.WebsocketConnection.Link();

            Console.WriteLine("Press ENTER to stop");

            var test = new Test();
            test.OnOutput += (s, data) => { Console.WriteLine(data); };
            test.DoTest(true);

            Console.ReadLine();

            test.EndTest();
        }
    }
}
