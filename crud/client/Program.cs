using client;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;

Console.WriteLine("Press \"Enter\" to see the issues Titles");
Console.ReadLine();

HttpClient client = new();
client.BaseAddress = new Uri("https://localhost:7191");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

HttpResponseMessage response = await client.GetAsync("api/issue");
response.EnsureSuccessStatusCode();



if (response.IsSuccessStatusCode)
{
    var issues = await response.Content.ReadFromJsonAsync<IEnumerable<IssueDto>>();
    foreach(var issue in issues)
    {
        Console.WriteLine(issue.Title);
    }
} else
{
    Console.WriteLine("No Results");
}
Console.WriteLine("Press \"Enter\" to Exit");
Console.ReadLine();
