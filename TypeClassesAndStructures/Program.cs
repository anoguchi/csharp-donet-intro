using System.Security.Cryptography;
class Person
{
  public string Name { get; set; }
  public int Age { get; set; }
}

// MODERN NULLABILITY
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

internal class Program
{
  private static void Main(string[] args)
  {
    string pattern = "-------------------------";

    // VALUE TYPES
    void ChangeAge(int age)
    {
      age = 10;
    }

    Person person = new() { Name = "Old Name", Age = 20 };
    ChangeAge(person.Age); // person.Age is still 20
    Console.WriteLine(person.Age);

    Console.WriteLine(pattern);

    // REFERENCE TYPES
    void ChangeName(Person person)
    {
      person.Name = "New Name";
    }

    Person person2 = new() { Name = "Old Name" };
    ChangeName(person); // person.Name is now "New Name"
    Console.WriteLine(person.Name);

    Console.WriteLine(pattern);

    // NULL AND NULLABILITY
    string str = null; // Valid for reference types
    int number = null; // This will cause a compilation error - value types cannot be null

    // Nullable value types
    string str = null; // Valid for reference types
    int? nullableInt = null; // Valid for nullable value types

    /* Word to the Wise: NullReferenceException (Most important thing to remember: Check for null before accessing members of a reference type!)
    */
    Person person = null;
    Console.WriteLine(person.Name); // NullReferenceException

    // BOXING AND UNBOXING

    /*
    This section covers boxing and unboxing in programming, explaining how value types are converted to reference types and vice versa.
    */

    int number = 42;
    object boxed = number; // Boxing

    object boxed = 42;
    int number = (int)boxed; // Unboxing

  }
}