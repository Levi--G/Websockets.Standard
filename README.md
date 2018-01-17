## Websockets.Standard

Websockets.Standard is a .Net Standard class library that wraps around different WebSocket implementations.

This project originated from [WebSocket.PCL](https://github.com/NVentimiglia/WebSocket.PCL)

Feel free to make an issue/pull request to support more library's/platforms

### Platforms

- Android (Native coming soon)
- IOS (SocketRocket coming soon)
- UWP
- .NET Core 
- .NET Framework (4.5 and up)
- .NET Standard (1.3 - 1.6)
- .NET Standard2 (2.0 and up)
- ~~WP8~~ (dropped because silverlight is not .net standard/VS 2017 compatible)


### NuGet

https://www.nuget.org/packages/Websockets.Standard/

### Setup

**Android**
- Include Websockets.Websocket4Net and Websockets.Standard library

**Ios**
- Include Websockets.Websocket4Net and Websockets.Standard library

**.Net Framework**
- Include Websockets.Net (or Websockets.NetStandard) and Websockets.Standard library

**.Net Standard/Core**
- Include Websockets.NetStandard (or Websockets.NetStandard2) and Websockets.Standard library

**Windows 10 Universal**
- Include Websockets.Universal and Websockets.Standard library

**Xamarin Forms**
- Include the Websockets.Standard library in the main common app
- Include the platform specific library in the platform projects

**Windows 8 Phone**
- Fork or download source
- Change Websocket4Net version to add silverlight support and compile with VS 2015
- Include Websockets.Websocket4Net and Websockets.Standard library


### Usage

`````
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
`````

### Example

There are a few 'test' examples (projects with the Tests suffix). Take a look there. The relivent code is in a standalone test file. (some might not work yet!)

### TODO

- Make the actual NuGet Packages
- Support .NET 2.0 and other old frameworks
- Support Native Android (port from old project)
- Support Ios SocketRocket (port from old project)
- Support other platforms.


### Questions

Make an issue and i will try to help asap.
