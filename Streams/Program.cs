using System.Text.Json;

internal class Program
{
    public static void Main(string[] args)
    {
        var content = File.ReadAllText(@"C:\Beto\Dev\CSharp\Intro\Streams\file.txt");
        var lines = File.ReadAllLines(@"C:\Beto\Dev\CSharp\Intro\Streams\file.txt");
        var bytes = File.ReadAllBytes(@"C:\Beto\Dev\CSharp\Intro\Streams\file.txt");
        
        Console.WriteLine("Content of file.txt:");
        Console.WriteLine(content);
        
        // JSON
        var employee = new Employee
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Age = 30
        };

        var json = JsonSerializer.Serialize(employee);
        var johnReborn = JsonSerializer.Deserialize<Employee>(json);
        
    }
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
