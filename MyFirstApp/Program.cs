internal class Program
{
  private static void Main(string[] args)
  {
    Console.WriteLine("Hello, Master!");
    int sum = AddNumbers(1, 1);
    Console.WriteLine(sum + 10);
    Console.WriteLine(AddNumbers(2));
    Console.WriteLine(AddNumbers(1, 2, 3, 4, 5, 6, 7, 8));
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
}