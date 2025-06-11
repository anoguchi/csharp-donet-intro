// BASIC GENERIC TYPES

using System.Collections.Immutable;

public class Box<T>
{
  private T _item;

  public void SetItem(T item)
  {
    _item = item;
  }

  public T GetItem()
  {
    return _item;
  }
}

// Generic Classes
public class Storage<T>
{
  public T Item { get; set; }
}

// Generic Method
public static class Utilities
{
  public static T GetDefaultValue<T>()
  {
    return default;
  }
}

// Repo Patterns with Generics
public interface IRepository<T> where T : class
{
  IEnumerable<T> GetAll();
  T GetById(int id);
  void Add(T entity);
  void Update(T entity);
  void Delete(T entity);
}

public class Repository<T> : IRepository<T> where T : class
{
  private readonly List<T> _entities = new List<T>();

  public IEnumerable<T> GetAll()
  {
    return _entities;
  }

  // yield keyword

  /* 
  The yield keyword is used to return an element one at a time from a method. It is commonly used in LINQ queries to return a sequence of elements. 
  */
  public IEnumerable<int> GetNumbers()
  {
    yield return 1;
    yield return 2;
  }

  public T GetById(int id)
  {
    // Try to find an entity with a property named "Id" of type Guid or int
    var prop = typeof(T).GetProperty("Id");
    if (prop != null)
    {
      foreach (var entity in _entities)
      {
        var value = prop.GetValue(entity);
        if (value is int intValue && intValue == id)
          return entity;
        if (value is Guid guidValue && guidValue.GetHashCode() == id)
          return entity;
      }
    }
    return null;
  }

  public void Add(T entity)
  {
    _entities.Add(entity);
  }

  public void Update(T entity)
  {
    // Logic for updating entity
  }

  public void Delete(T entity)
  {
    _entities.Remove(entity);
  }
}
public class Customer
{
  public Guid Id { get; set; }
  public string Name { get; set; }
}

public class Product
{
  public Guid Id { get; set; }
  public string Name { get; set; }
}

// IEnumerable<T> as Our First Generic Collection Type
public class Example
{
  public void PrintItems(IEnumerable<string> items)
  {
    //Remember foreach?
    foreach (var item in items)
    {
      Console.WriteLine(item);
    }
  }
}

internal class Program
{
  private static void Main(string[] args)
  {
    string pattern = "-------------------------";

    // GENERICS
    Console.WriteLine("GENERICS");

    Box<int> intBox = new Box<int>();
    intBox.SetItem(10);
    Console.WriteLine(intBox.GetItem()); // 10

    Box<string> stringBox = new Box<string>();
    stringBox.SetItem("Hello");
    Console.WriteLine(stringBox.GetItem()); // Hello

    //stringBox.SetItem(123); // Compile-time error, yay!

    var defaultValueOfInt = Utilities.GetDefaultValue<bool>();
    Console.WriteLine(defaultValueOfInt);

    // Repo Patterns with Generics
    var customerRepository = new Repository<Customer>();
    var productRepository = new Repository<Product>();

    customerRepository.Add(new Customer { Id = Guid.NewGuid(), Name = "John Doe" });
    productRepository.Add(new Product { Id = Guid.NewGuid(), Name = "Product A" });

    foreach (var customer in customerRepository.GetAll())
    {
      Console.WriteLine($"Customer: {customer.Id} - {customer.Name}");
    }

    foreach (var product in productRepository.GetAll())
    {
      Console.WriteLine($"Product: {product.Id} - {product.Name}");
    }

    Console.WriteLine(pattern);

    // ARRAYS VS COLLECTIONS
    Console.WriteLine("ARRAYS");
    // Declaring an array of integers with 5 elements
    int[] numbers = new int[5];
    numbers[0] = 1;
    numbers[1] = 2;
    numbers[2] = 3;
    numbers[3] = 4;

    var theDefaultValue = numbers[4]; //0
    //var notPossible = numbers[5]; //throws an IndexOutOfRangeException

    // Initializing an array with values
    int[] myNumbers = { 1, 2, 3, 4, 5 };

    // Introducing the .NET Developer's Favorite Collection Type: List<T>
    Console.WriteLine("Lists");

    var bus = new List<string>();

    bus.Add("Beto");
    bus.Add("Tiago");
    bus.Add("Felipe");
    bus.AddRange(["Hulk", "Diogon"]);

    foreach (var busList in bus)
    {
      Console.WriteLine(busList);
    }

    List<int> digit = [1, 2, 3, 4, 5];

    var dict = new Dictionary<string, int>();

    dict["asdf"] = 3;

    var otherBus = bus.ToImmutableArray();
    
    // Lambda Expression
    Console.WriteLine("---Lambda Expressions---");
    Func<int, int, int> add = (a, b) => a + b;

    int Add(int a, int b)
    {
      return a + b;
    }
    
    Action doesSomething = () => Console.WriteLine("Does Something");
    Action<string> write = Console.WriteLine;
    write("test");
    
  }
}