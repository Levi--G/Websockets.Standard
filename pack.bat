@echo off

echo building standard libs
cd %~dp0
mkdir nuget
::cd Websockets
::dotnet pack -c Release -o %~dp0\nuget
cd %~dp0
cd Websockets.NetStandard
dotnet pack -c Release -o %~dp0\nuget
cd %~dp0
cd Websockets.NetStandard2
dotnet pack -c Release -o %~dp0\nuget
cd %~dp0
cd Websockets.WebSocket4Net
dotnet pack -c Release -o %~dp0\nuget

echo building framework libs
cd %~dp0
cd Websockets.Universal
nuget pack Websockets.Universal.csproj -Properties Configuration=Release -OutputDirectory %~dp0\nuget
cd %~dp0
cd Websockets.Net
nuget pack Websockets.Net.csproj -Properties Configuration=Release -OutputDirectory %~dp0\nuget
cd %~dp0

echo Done...

start %~dp0\nuget