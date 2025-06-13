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