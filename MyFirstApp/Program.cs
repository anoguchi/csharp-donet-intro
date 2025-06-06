using System.Security.Cryptography;

internal class Program
{
  private static void Main(string[] args)
  {
    Console.WriteLine("Hello, Master!");
    int sum = AddNumbers(1, 1);
    Console.WriteLine(sum + 10);
    Console.WriteLine(AddNumbers(2));
    Console.WriteLine(AddNumbers(1, 2, 3, 4, 5, 6, 7, 8));

    string name = "Alberto";
    name = name.ToLower();

    Console.WriteLine(name);
    Console.WriteLine(DateTime.UtcNow);

    DateTime.UtcNow.AddDays(1);
    Console.WriteLine(DateTime.UtcNow.AddDays(1));

    DateTime d = DateTime.Parse("10/9/2024 4:43:48 PM");
    Console.WriteLine(d);

    // Arrays
    int[] arrayOfIntegers = [1, 2, 3, 4, 5];

    foreach (char character in "Hello World")
    {
      Console.WriteLine(character);
    }

    var employeeType = EmployeeType.Manager;
    int employeeInt = (int)EmployeeType.Worker;
    Console.WriteLine(employeeType);
    Console.WriteLine(employeeInt);

    // Tupples
    var myTuple = (42, "Hello", true);
    var myNamedTuple = (Age: 30, Name: "Beto", IsEmployed: false);
    Console.WriteLine(myTuple.Item1);
    Console.WriteLine(myTuple.Item2);
    Console.WriteLine(myTuple.Item3);
    Console.WriteLine(myNamedTuple.Age);
    Console.WriteLine(myNamedTuple.Name);
    Console.WriteLine(myNamedTuple.IsEmployed);

    var personInfo = GetEmployee();
    Console.WriteLine(personInfo.Age);
    Console.WriteLine(personInfo.Name);

  }
  // Enums
  enum EmployeeType
  {
    Manager = 1,
    Supervisor = 2,
    Worker = 3
  }
  public static int AddNumbers(int a, int b = 5)
  {
    return a + b;
  }
  public static int AddNumbers(int a, int b, int c)
  {
    return a + b + c;
  }
  public static int AddNumbers(params int[] integers)
  {
    return integers.Sum();
  }
  public static void PrintMessage()
  {
    Console.WriteLine("Damn");
  }
  public static bool IsEven(int number)
  {
    if (number % 2 == 0)
    {
      return true;
    }
    return false;
  }
  public static (int Age, String Name) GetEmployee()
  {
    return (30, "Beto");
  }
}