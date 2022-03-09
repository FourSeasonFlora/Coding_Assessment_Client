using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

int[] numbers = { 1, 2, 3, 4, 5 };
Dictionary<string, int[]> numberDictionary = new Dictionary<string, int[]>();
numberDictionary.Add("numbers", numbers);


var client = new HttpClient();
var request = new HttpRequestMessage();
request.RequestUri = new Uri("http://localhost:7071/api/Endpoint_C");
request.Content = new StringContent(JsonSerializer.Serialize(numberDictionary));

var response = await client.PostAsync(request.RequestUri,request.Content);
Console.WriteLine(response.Content.ReadAsStringAsync().Result);