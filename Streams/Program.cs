// See https://aka.ms/new-console-template for more information

internal class Program
{
    public static void Main(string[] args)
    {
        var content = File.ReadAllText(@"C:\Beto\Dev\CSharp\Intro\Streams\file.txt");
        var lines = File.ReadAllLines(@"C:\Beto\Dev\CSharp\Intro\Streams\file.txt");
        var bytes = File.ReadAllBytes(@"C:\Beto\Dev\CSharp\Intro\Streams\file.txt");
        
        Console.WriteLine("Content of file.txt:");
        Console.WriteLine(content);
    }
}