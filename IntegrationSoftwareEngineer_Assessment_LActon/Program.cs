using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

// make an array of integers
int[] numbers = { 1, 2, 3, 4, 5 };

// make a dictionary to hold our key and values
Dictionary<string, int[]> numberDictionary = new Dictionary<string, int[]>();

// enter numbers as the key, and our array of integers as our value
numberDictionary.Add("numbers", numbers);

// make new client for sending requests to endpoints
var client = new HttpClient();

// make new RequestMessage to send to endpoint with our client
var request = new HttpRequestMessage();
request.RequestUri = new Uri("http://localhost:7071/api/Endpoint_C"); // add the URI for the endpoint
request.Content = new StringContent(JsonSerializer.Serialize(numberDictionary)); // add the dictionary, after serializing from a dictionary into a JSON string

// call the endpoint with the client, and send our RequestMessage, and await a response from Endpoint_C
var response = await client.PostAsync(request.RequestUri,request.Content);

// print the response after it is returned
Console.WriteLine(response.Content.ReadAsStringAsync().Result);