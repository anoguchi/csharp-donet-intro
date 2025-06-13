public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Salary { get; set; }
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

internal class Program
{
    public static void Main(string[] args)
    {
        var employees = new List<Employee>();
        employees.Add(new Employee { FirstName = "John", LastName = "Doe", Salary = 50000 });
        employees.Add(new Employee { FirstName = "Anna", LastName = "Doe", Salary = 60000 });
        employees.Add(new Employee { FirstName = "Sam", LastName = "Brown", Salary = 55000 });
        employees.Add(new Employee { FirstName = "Lisa", LastName = "White", Salary = 70000 });
        employees.Add(new Employee { FirstName = "Tom", LastName = "Doe", Salary = 45000 });
        employees.Add(new Employee { FirstName = "Anna", LastName = "Smith", Salary = 80000 });
        employees.Add(new Employee { FirstName = "Alberto", LastName = "Noguchi", Salary = 80000 });

        // Select distinct above 50K last names
        IEnumerable<string> distinctLastNamesAbove5K = employees
            .Where(e => e.Salary > 50000)
            .Select(e => e.LastName)
            .Distinct();

        foreach (var name in distinctLastNamesAbove5K)
        {
            Console.WriteLine(name);
        }
        
        // Select distinct last names with first names
        var distinctLastNames = employees
            .Select(e => new { e.LastName, e.FirstName })
            .Distinct();

        foreach (var name in distinctLastNames)
        {
            Console.WriteLine(name);
        }
        
        // Select distinct with class
        var distinctLastNamesWithClass = employees
            .Select(e => new Person { LastName = e.LastName, FirstName = e.FirstName })
            .Distinct();

        foreach (var person in distinctLastNamesWithClass)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}");

        }
        
        // Select distinct with start with 'A'
        var distinctLastNamesStartingWithA = employees
            .Where(e => e.LastName.StartsWith("A"))
            .Select(e => new { e.LastName, e.FirstName })
            .OrderBy(e => e.LastName)
            .Distinct();

        foreach (var person in distinctLastNamesStartingWithA)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}");
        }
        
        // Select individual values
        var alberto = employees.Single(e => e.FirstName == "Alberto" && e.LastName == "Noguchi");
        Console.WriteLine($"Alberto's Last Name: {alberto.LastName}");
        
        // Aggregate names 
        var aggregatedNames = employees
            .Select(e => $"{e.FirstName} {e.LastName}")
            .Aggregate((current, next) => $"{current}, {next}");
        Console.WriteLine($"Aggregated Names: {aggregatedNames}");
        
        // Group by
        var grouped = employees.GroupBy(e => e.FirstName);

        foreach (var group in grouped)
        {
            Console.WriteLine($"{group.Key} employees: {group.Count()}");
            foreach (var employee in group)
            {
                Console.WriteLine($"  {employee.FirstName} {employee.LastName} - {employee.Salary}");
            }
        }
    }
}
