using System.Runtime.InteropServices;
using HelloDotnet;

var version = typeof(Program).Assembly.GetName().Version?.ToString() ?? "dev";

Console.WriteLine($"hello-dotnet version {version}");
Console.WriteLine("Hello from C#/.NET! 🎯🐳");
Console.WriteLine($"OS: {RuntimeInformation.OSDescription}");
Console.WriteLine($"Arch: {RuntimeInformation.OSArchitecture}");
Console.WriteLine(Greeting.Greet("GitHub"));
Console.WriteLine($"Sum 1..10 = {Greeting.SumRange(1, 10)}");

if (args.Length > 0)
{
    Console.WriteLine("Аргументы:");
    for (int i = 0; i < args.Length; i++)
    {
        Console.WriteLine($"  {i + 1}: {args[i]}");
    }
}
