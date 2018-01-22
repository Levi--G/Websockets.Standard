using System;
using Websockets.SharedTest;

namespace Websockets.Websocket4NetTests
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1) Link in your main activity
            Websockets.WP8.WebsocketConnection.Link();

            Console.WriteLine("Press ENTER to stop");

            var test = new Test();
            test.OnOutput += (s, data) => { Console.WriteLine(data); };
            test.DoTest(false);

            Console.ReadLine();

            test.EndTest();
        }
    }
}
