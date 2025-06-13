internal class Program
{
    public static async Task Main(string[] args)
    {
        string data = await GetDataFromServerAsync("https://google.com");
        Console.WriteLine(data);
    }
    
    public static async Task<string> GetDataFromServerAsync(string url)
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetStringAsync(url);
        return response;
    }
}

public class MyResource : IDisposable
{
    private bool _disposed = false; // To detect redundant calls
    private SqlConnection _connection;

    // Implement IDisposable
    public void Dispose()
    {
        if (!disposed)
        {
            _connection.Dispose();

            // Free your own state (unmanaged objects).
            disposed = true;
        }
    }
}