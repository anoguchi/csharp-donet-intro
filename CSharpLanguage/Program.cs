﻿using System.Security.Cryptography;

internal class Program
{
  private static void Main(string[] args)
  {
    string pattern = "-------------------------";
    Console.WriteLine("Hello, Master!");
    int sum = AddNumbers(1, 1);
    Console.WriteLine(sum + 10);
    Console.WriteLine(AddNumbers(2));
    Console.WriteLine(AddNumbers(1, 2, 3, 4, 5, 6, 7, 8));

    Console.WriteLine(DateTime.UtcNow);

    DateTime.UtcNow.AddDays(1);
    Console.WriteLine(DateTime.UtcNow.AddDays(1));

    DateTime d = DateTime.Parse("10/9/2024 4:43:48 PM");
    Console.WriteLine(d);
    Console.WriteLine(pattern);

    // ARRAYS
    Console.WriteLine("ARRAYS");
    int[] arrayOfIntegers = [1, 2, 3, 4, 5];

    foreach (char character in "Hello World")
    {
      Console.WriteLine(character);
    }

    // ENUMS
    Console.WriteLine("ENUMS");
    var employeeType = EmployeeType.Manager;
    int employeeInt = (int)EmployeeType.Worker;
    Console.WriteLine(employeeType);
    Console.WriteLine(employeeInt);
    Console.WriteLine(employeeInt);
    Console.WriteLine(pattern);

    // TUPPLES
    Console.WriteLine("TUPPLES");
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
    Console.WriteLine(pattern);

    // STRINGS
    Console.WriteLine("STRINGS");
    string name = "Alberto";
    string name2 = "AlbertO";
    name = name.ToLower();
    string text = """
                  Hello master, how are you?
                  """;
    string greeting = $"Hello, {name}";
    string emptyString = string.Empty;
    var isNullOrEmpty = string.IsNullOrEmpty(emptyString);

    if (string.Equals(name, name2, StringComparison.OrdinalIgnoreCase))
    {
      Console.WriteLine("Name is equal");
    }

    Console.WriteLine(name);
    Console.WriteLine(text);
    Console.WriteLine(greeting);
    Console.WriteLine(isNullOrEmpty);
    Console.WriteLine(pattern);

    // CONTROL FLOW
    Console.WriteLine("CONTROL FLOW");

    int age = 16;
    if (age >= 18)
    {
      Console.WriteLine("You are an adult");
    }
    else
    {
      Console.WriteLine("You are a minor");
    }

    // Switch
    int day = 3;
    switch (day)
    {
      case 1:
        Console.WriteLine("Monday");
        break;
      case 2:
        Console.WriteLine("Tuesday");
        break;
      case 3:
        Console.WriteLine("Wednesday");
        break;
      case 4:
        Console.WriteLine("Thursday");
        break;
      case 5:
        Console.WriteLine("Friday");
        break;
      case 6:
        Console.WriteLine("Saturday");
        break;
      case 7:
        Console.WriteLine("Sunday");
        break;
      default:
        Console.WriteLine("Invalid day.");
        break;
    }

    // While
    int i = 0;
    while (i != 4)
    {
      i++;
      Console.WriteLine(i);
      if (i == 2)
      {
        Console.WriteLine("2");
        break;
      }
    }

    // ForEach
    int[] arr = [1, 2, 3, 4, 5];

    foreach (var arrValue in arr)
    {
      Console.WriteLine(arrValue);
    }

    // Break
    for (int i2 = 0; i2 < 10; i2++)
    {
      if (i2 == 5)
      {
        break;
      }
      Console.WriteLine(i2);
    }

    // Continue
    for (int i3 = 0; i3 < 10; i3++)
    {
      if (i3 == 5)
      {
        continue;
      }
    }
    Console.WriteLine(pattern);

    // OPERATORS
    Console.WriteLine("OPERATORS");

    int a = 5;
    int b = a++; // b is 5, a is 6
    int c = ++a; // c is 7, a is 7

    Console.WriteLine(b);
    Console.WriteLine(c);
    Console.WriteLine(a);
    Console.WriteLine(pattern);

    // CONVERSION
    Console.WriteLine("CONVERSION");

    // Implicit Conversion
    int num01 = 5;
    double num02 = num01; // Implicit conversion from int to double

    // Explicit Conversion
    int num03 = 5;
    double num04 = (double)num03;

    // Parse
    int num05 = int.Parse("5"); // Converts "5" to 5

    // TryParse
    string textBoxAge = "Beto";

    bool success = int.TryParse(textBoxAge, out int age02);

    if (!success)
    {
      Console.WriteLine("invalid input");
    }

    // Convert
    int num06 = Convert.ToInt32("5"); // Converts "5" to 5

    Console.WriteLine(pattern);

    // EXCEPTION HANDLING
    Console.WriteLine("EXCEPTION HANDLING");

    try
    {
      DateTime.Parse("asdf");
      string name3 = "Alice";
      if (name3 != "Beto")
      {
        throw new InvalidOperationException("YOU ARE NOT BETO!");
      }
    }
    catch (ArgumentNullException ex)
    {
      Console.WriteLine("Something went wrong!");
    }
    catch (FormatException ex)
    {
      Console.WriteLine("Something went wrong!");
    }
    finally
    {
      Console.WriteLine("Finally!");
    }

    try
    {
      string name3 = "Alice";
      if (name3 != "Beto")
      {
        throw new InvalidOperationException("YOU ARE NOT BETO!");
      }
    }
    catch (ArgumentNullException ex)
    {
      Console.WriteLine("Something went wrong!");
    }
    catch (FormatException ex)
    {
      Console.WriteLine("Something went wrong!");
    }
    finally
    {
      Console.WriteLine("Finally!");
    }

    Console.WriteLine(pattern);

    // PATTERN MATCHING
    Console.WriteLine("Pattern Matching");

    object value = "Hello, World!";
    if (value is string str)
    {
      Console.WriteLine($"The value is a string: {str}");
    }
    else
    {
      Console.WriteLine("The value is not a string.");
    }

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
  // Exception Handling
  public static void DomeSomeProcessing(string criticalValue)
  {
    if (string.IsNullOrWhiteSpace(criticalValue))
    {
      throw new ArgumentException();
    }
  }
}