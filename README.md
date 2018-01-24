## Websockets.Standard

Websockets.Standard is a .Net Standard class library that wraps around different WebSocket implementations.

This project originated from [WebSocket.PCL](https://github.com/NVentimiglia/WebSocket.PCL)

Feel free to make an issue/pull request to support more library's/platforms

### Platforms

- Android (Native coming soon)
- IOS (SocketRocket coming soon)
- UWP
- .NET Framework (4.5 and up)
- .NET Standard/Core (1.3 and up)
- ~~WP8~~ (dropped because silverlight is not .net standard/VS 2017 compatible)


### NuGet

- [Websockets.Standard](https://www.nuget.org/packages/Websockets.Standard/) (include in your library/common app)
- [.NET](https://www.nuget.org/packages/Websockets.Net/) (.Net 4.5+, Standard 1.3+, Universal)
- [WebSocket4Net](https://www.nuget.org/packages/Websockets.WebSocket4Net/) (.Net Standard 1.3+ and mono, soon other platforms too)

### Setup

**All**
- Include Websockets.Standard library

**Android & Ios**
- Include Websockets.Websocket4Net library

**.Net Framework & .Net Standard/Core & Windows 10 Universal**
- Include Websockets.Net library

**Xamarin Forms**
- Include the Websockets.Standard library in the main common app
- Include the platform specific library in the platform projects

**Windows 8 Phone**
- Fork or download source
- Change Websocket4Net version to add silverlight support and compile with VS 2015
- Include Websockets.Websocket4Net and Websockets.Standard library


### Usage

```cs
        void Configure()
        {
            // Call in your specific platform startup            
            // 1) Link at startup before socket creation
            Websockets.Net.WebsocketConnection.Link();
        }
        
        
        void Connect()
        {
            // 2) Get a websocket from the standard library via the factory
            connection = Websockets.WebSocketFactory.Create();
            connection.OnOpened += Connection_OnOpened;
            connection.OnMessage += Connection_OnMessage;
        }

        void Send()
        {            
            connection.Open("http://echo.websocket.org");
            connection.Send("Hello World");
        }

        private void Connection_OnOpened()
        {
            Debug.WriteLine("Opened !");
        }

        private void Connection_OnMessage(string obj)
        {
            Echo = obj == "Hello World";
        }
```

### Example

There are a few 'test' examples (projects with the Tests suffix). Take a look there. The relivent code is in a standalone test file. (some might not work yet!)

### TODO

- Support .NET 2.0 and other old frameworks (Planned next release)
- Support Native Android (port from old project)
- Support Ios SocketRocket (port from old project)
- Support other platforms/libraries.


### Questions

Make an issue and i will try to help asap.
