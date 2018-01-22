using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Websockets.SharedTest
{
    public class Test : IDisposable
    {
        private Websockets.IWebSocketConnection connection;
        private bool Failed;
        private bool Echo;
        public event EventHandler<string> OnOutput;

        void WriteLine(string line)
        {
            OnOutput?.Invoke(this, line);
        }

        public async void DoTest(bool withHeaders)
        {
            // 2) Call factory from your PCL code.
            // This is the same as new   Websockets.Droid.WebsocketConnectionDroid();
            // Except that the Factory is in a PCL and accessible anywhere
            connection = Websockets.WebSocketFactory.Create();
            connection.OnLog += Connection_OnLog;
            connection.OnError += Connection_OnError;
            connection.OnMessage += Connection_OnMessage;
            connection.OnOpened += Connection_OnOpened;

            //Timeout / Setup
            Echo = Failed = false;
            Timeout();

            //Do test

            WriteLine("Connecting...");
            if (withHeaders)
            {
                connection.Open("http://echo.websocket.org", null, new System.Collections.Generic.Dictionary<string, string> { { "Origin", "websocket.org" } });
            }
            else
            {
                connection.Open("http://echo.websocket.org");
            }

            while (!connection.IsOpen && !Failed)
            {
                await Task.Delay(10);
            }

            if (!connection.IsOpen)
                return;
            WriteLine("Connected !");

            //Trace.WriteLine("HI");
            WriteLine("Sending...");
            connection.Send("Hello World");
            WriteLine("Sent !");

            while (!Echo && !Failed)
            {
                await Task.Delay(10);
            }

            if (!Echo)
                return;

            WriteLine("Received !");

            WriteLine("Passed !");
        }

        public void EndTest()
        {
            connection?.Close();
            connection?.Dispose();
            connection = null;
        }

        private void Connection_OnOpened()
        {
            WriteLine("Opened !");
        }

        async void Timeout()
        {
            await Task.Delay(120000);
            Failed = true;
            WriteLine("Timeout");
        }

        private void Connection_OnMessage(string obj)
        {
            Echo = obj == "Hello World";
        }

        private void Connection_OnError(string obj)
        {
            WriteLine("ERROR " + obj);
            Failed = true;
        }

        private void Connection_OnLog(string obj)
        {
            WriteLine(obj);
        }

        public void Dispose()
        {
            EndTest();
        }
    }
}
