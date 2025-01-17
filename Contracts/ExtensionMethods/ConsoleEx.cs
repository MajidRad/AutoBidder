

namespace Contracts.ExtensionMethods;
public static class ConsoleEx
{
    public static void ErrorMessage(this string message)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine($"---> {message}");
    }
    public static void SuccessMessage(this string message)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine($"---> {message}");
    }
    public static void InfoMessage(this string message)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"---> {message}");
    }
}
