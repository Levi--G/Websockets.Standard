## Websockets.Standard

Websockets.Standard is a .Net Standard class library that wraps around different WebSocket implementations.

This project originated from [WebSocket.PCL](https://github.com/NVentimiglia/WebSocket.PCL)

Feel free to make an issue/pull request to support more library's/platforms

### Platforms

- Android (Native coming soon)
- IOS (SocketRocket coming soon)
- UWP
- .NET Framework (2.0 and up)
- .NET Standard/Core (1.3 and up)
- ~~WP8~~ (dropped because silverlight is not .net standard/VS 2017 compatible)


### NuGet

- [Websockets.Standard](https://www.nuget.org/packages/Websockets.Standard/) (include in your library/common app)
- [.NET](https://www.nuget.org/packages/Websockets.Net/) (.Net 4.5+, Standard 1.3+, Universal)
- [WebSocket4Net](https://www.nuget.org/packages/Websockets.WebSocket4Net/) (.Net Standard 1.3+, mono, .NET 2.0+)

### Advantages

With Websocket.Standard you can easily switch between implementations per platform or even at runtime!! Don't know wich websocket to use? Just try them one-by-one by changing one line and see wich suits you best! Are you missing a common websocket library, make an issue and tell us which you need!

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

### Special Setups

**.NET Standard/PCL library**
- Include the Websockets.Standard library only, and don't link anything leave that to the platforms to choose

**Xamarin Forms**
- Include the Websockets.Standard library in the main common app
- Include the platform specific library in the platform projects

**Windows 8 Phone**
- Fork or download source
- Change Websocket4Net version to add silverlight support and compile with VS 2015
- Include Websockets.Websocket4Net and Websockets.Standard library

### Example

There are a few 'test' examples (projects with the Tests suffix). Take a look there. They use a common library, the platforms just include the library and link the right implementation.

### TODO

- Support multiple factories/implementation in one app
- Support Native Android (port from old project)
- Support Ios SocketRocket (port from old project)
- Support other platforms/libraries.


### Questions?

Make an issue and i will try answer asap.
