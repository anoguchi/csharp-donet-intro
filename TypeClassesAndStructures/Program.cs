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
public class Personagem
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

// Constructors

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

    Personagem personagem = new();
    personagem.FirstName = "Beto";
    personagem.LastName = "Noguchi";

    Console.WriteLine(personagem.FullName);

    Console.WriteLine("Constructors");

  }
}