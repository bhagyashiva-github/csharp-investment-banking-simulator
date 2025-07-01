# C# Investment Banking Simulator
This is a repository of C# programming that simulates investment banking system.
The project implements all the important C# .NET concepts independently in seperate folders. 

## Projects 
The following concepts are implemented in this repository
- Abstraction 
- Encapsulation 
- Inheritance 
- Polymorphism 
- Asynchronous Programming 
- Parallel Programming 
- Multi-threading 
- Event-Driven Programming 
- Design Patterns 
- High Performance Computing 
- Memory Management 
- Exception Handling
- Logging using `NLog` 
- Collections and DataStructures 

## Technologies Used
- C# (.NET 9)

## How to Run
1. Install .NET SDK.
2. Clone project.
3. Run `dotnet run`.

## To Configure NLog
- Add the NLog packages using the following commands 
`dotnet add package NLog`
`dotnet add package NLog.Extensions.Logging`
- Created a custom `NLog.config` file in project root folder
- Add below code to `.csproj` file
`<ItemGroup>
  <None Update="NLog.config">
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
  </None>
</ItemGroup>
`

## Author 
Bhagya Sri Ramkumar
