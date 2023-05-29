using System.Net.Http.Json;
using System.Text.RegularExpressions;

class Program
{
    static HttpClient httpClient = new HttpClient();
    static async Task Main()
    {
        string text = "";

        string path = @"text.txt"; // \digital-design-test\bin\Debug\net6.0
        using (StreamReader reader = new StreamReader(path))
        {
            text = reader.ReadToEnd();
        }
        string pattern = @"[\t\n\r]"; 

        string words = Regex.Replace(text, pattern, String.Empty);

        var content = JsonContent.Create(words);
        
        using var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7230/api/GetUniqueWords");
        request.Content = content;
        using var response = await httpClient.SendAsync(request);
        string responseText = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseText);

        Console.WriteLine("Нажмите любую кнопку для выхода...");
        Console.ReadKey();
    }
}