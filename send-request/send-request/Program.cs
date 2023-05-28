using System.Net.Http.Json;

class Program
{
    static HttpClient httpClient = new HttpClient();
    static async Task Main()
    {
        Console.WriteLine("Введите строку для обработки");
        string data = Console.ReadLine();
        var content = JsonContent.Create(data);
        
        using var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7230/api/GetUniqueWords");
        request.Content = content;
        using var response = await httpClient.SendAsync(request);
        string responseText = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseText);
    }
}