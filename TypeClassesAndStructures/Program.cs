using System.Security.Cryptography;
class Person
{
  public string Name { get; set; }
  public int Age { get; set; }
}

// Modern Nullability
public class Address
{
  public string Street { get; set; }
  public string City { get; set; }
  public string State { get; set; }
  public string ZipCode { get; set; }
}

public class Human
{
  public string Name { get; set; }        // Non-nullable reference type
  public string? MiddleName { get; set; } // Nullable reference type
  public Address? Address { get; set; }   // Nullable reference type
}

// CLASSES

// Fields
public class Persona
{
  public string Name;
}

// Properties
public class Individual
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public int Age { get; } // Immutable property
  public string FullName => $"{FirstName} {LastName}";
}

public class Hero
{
  public string Name { get; } // Immutable property, typically set in constructor
  public int Age { get; set; } // Mutable property
}

// CONSTRUCTORS

public class Guy
{
  public string Name { get; set; }
  public int Age { get; set; }

  public Guy(string name, int age)
  {
    Name = name;
    Age = age;
  }
}

// Thrown exceptions in constructors
public class Fellow
{
  public string Name { get; set; }
  public int Age { get; set; }

  public Fellow(string name, int age)
  {
    if (string.IsNullOrWhiteSpace(name))
    {
      throw new ArgumentException("Name cannot be null or empty", nameof(name));
    }
    Name = name;
    Age = age;
  }
}

// Using object initializers
public class Creature
{
  public string Name { get; init; }
  public int Age { get; init; }
}

// STRUCTS
public struct Point
{
  public int X { get; }   //look ma, no setter!
  public int Y { get; }

  public Point(int x, int y)
  {
    X = x;
    Y = y;
  }
}

// RECORDS
public record Dude(string Name, int Age);

// INHERITANCE
public class BaseEmployee
{
  public string FirstName { get; set; }
  public string LastName { get; set; }

  public virtual string GetEmployeeDetails()
  {
    return $"{FirstName} {LastName}";
  }
}

public class HourlyEmployee : BaseEmployee
{
  public decimal HourlyRate { get; set; }

  public decimal CalculateWeeklyPay(int hoursWorked)
  {
    return HourlyRate * hoursWorked;
  }
}

// SEALED VS VIRTUAL

// Virtual - A virtual method/property in the base class can be overridden in derived classes to provide specific implementations.
public class BaseWorker
{
  public virtual string GetWorkerDetails()
  {
    return "Base worker details";
  }
}

public class DerivedWorker : BaseWorker
{
  public override string GetWorkerDetails()
  {
    return "Derived worker details";
  }
}

// Sealed - A sealed class cannot be inherited. Use this to prevent further derivation.
public class MyEmployee
{
  public sealed override string ToString() //sealed prevents overriding in derived classes
  {
    return "Base employee details";
  }
}

// ABSTRACT CLASSES

/*
Abstract classes serve as a base class that other classes can derive from. They may contain abstract methods that derived classes must implement, providing shared behaviors and properties.

Abstract classes cannot be instantiated directly. 
*/

public abstract class Customer
{
  public string FirstName { get; set; }
  public string LastName { get; set; }

  public abstract decimal CalculatePay(); // Abstract method

  public virtual string GetCustomerDetails() // Virtual method
  {
    return $"{FirstName} {LastName}";
  }

  public sealed override string ToString() // Sealed method
  {
    return GetCustomerDetails();
  }
}

// Example of Derived Classes
public class HourlyCustomer : Customer
{
  public decimal HourlyRate { get; set; }
  public int HoursWorked { get; set; }

  public override decimal CalculatePay()
  {
    return HourlyRate * HoursWorked;
  }
}

public class SalariedCustomer : Customer
{
  public decimal Salary { get; set; }

  public override decimal CalculatePay()
  {
    return Salary / 52; // Weekly pay calculation
  }
}

// INTERFACES
public interface IDatabase
{
  void Connect();
  void Disconnect();
  bool IsConnected { get; }
}
public class SqlDatabase : IDatabase
{
  public bool IsConnected { get; private set; }

  public void Connect()
  {
    // Implementation code
    IsConnected = true;
  }

  public void Disconnect()
  {
    // Implementation code
    IsConnected = false;
  }
}

// EXTENSION METHODS
public static class StringExtensions
{
  public static bool IsPalindrome(this string str)
  {
    if (string.IsNullOrEmpty(str))
      return false;

    string reversed = new string(str.Reverse().ToArray());
    return str.Equals(reversed, StringComparison.OrdinalIgnoreCase);
  }
}

internal class Program
{
  private static void Main(string[] args)
  {
    string pattern = "-------------------------";

    // VALUE TYPES
    Console.WriteLine("VALUE TYPES");
    void ChangeAge(int age)
    {
      age = 10;
    }

    Person person = new() { Name = "Old Name", Age = 20 };
    ChangeAge(person.Age); // person.Age is still 20
    Console.WriteLine(person.Age);

    Console.WriteLine(pattern);

    // Reference Types
    void ChangeName(Person person)
    {
      person.Name = "New Name";
    }

    Person person2 = new() { Name = "Old Name" };
    ChangeName(person); // person.Name is now "New Name"
    Console.WriteLine(person.Name);

    Console.WriteLine(pattern);

    // Null and Nullability

    /*
    string str = null; // Valid for reference types
    int number = null; // This will cause a compilation error - value types cannot be null
    */

    // Nullable value types

    /*
    string str = null; // Valid for reference types
    int? nullableInt = null; // Valid for nullable value types
    */

    /* Word to the Wise: NullReferenceException (Most important thing to remember: Check for null before accessing members of a reference type!)
    */

    /* Person person = null;
    Console.WriteLine(person.Name); // NullReferenceException 
    */

    // Boxing and Unboxing

    /*
    This section covers boxing and unboxing in programming, explaining how value types are converted to reference types and vice versa.
    */

    int number = 42;
    object boxed = number; // Boxing

    object boxed2 = 42;
    int number2 = (int)boxed; // Unboxing

    // CLASSES
    Console.WriteLine("CLASSES");

    var persona = new Persona
    {
      Name = "John Doe"
    };

    Individual individual = new();
    individual.FirstName = "Beto";
    individual.LastName = "Noguchi";

    Console.WriteLine(individual.FullName);

    // CONSTRUCTORS  
    Console.WriteLine("Constructors");

    // Using object initializers
    Person person01 = new Person
    {
      Name = "John Doe",
      Age = 30            //❤️
    };

    Creature creature = new Creature
    {
      // cant do creature.Name or creature.Age
      Name = "John Doe",
      Age = 30
    };

    Console.WriteLine(pattern);

    // STRUCTS AND RECORDS
    Console.WriteLine("Structs and Records");

    var dude = new Dude("John Doe", 30);
    var dude2 = new Dude("John Doe", 30);
    var dude3 = dude2 with { Age = 31 };

    Console.WriteLine(dude == dude2); // True
    dude.Equals(dude2); // True

    Console.WriteLine(pattern);

    // INHERITANCE
    Console.WriteLine("INHERITANCE");
    var hourByEmployee = new HourlyEmployee
    {
      FirstName = "Beto",
      LastName = "Noguchi",
      HourlyRate = 123.23M
    };

    Console.WriteLine(hourByEmployee.GetEmployeeDetails());

    Console.WriteLine(pattern);

    // EXTENSION METHODS
    Console.WriteLine("EXTENSION METHODS");

    var maam = "maam";

    // var isPalindrome = StringExtensions.IsPalindrome(maam);
    var isPalindrome = maam.IsPalindrome();
    Console.WriteLine(isPalindrome);

  }
}
