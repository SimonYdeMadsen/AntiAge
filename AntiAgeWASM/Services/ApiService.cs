using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;


namespace AntiAgeWASM.Services
{
    public class ApiService
    {
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;

        public ApiService(HttpClient httpClient, AuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            string token = _authService.Token;
            Console.WriteLine($"Token: {token}");

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"ApiService: Request failed. Status code: {response.StatusCode}");
                return default;
            }

            var content = await response.Content.ReadFromJsonAsync<T>();

            if (content == null)
            {
                Console.WriteLine("ApiService: Dto is null.");
            }

            return content;
        }

        //public async Task<bool> PostAsync<T>(string url, object content = null)
        //{
        //    var request = new HttpRequestMessage(HttpMethod.Post, url);
        //    if (request == null)
        //    {
        //        Console.WriteLine($"ApiService: Invalid URL.");
        //        return default;
        //    }


        //    if (content != null)
        //    {
        //        var jsonContent = JsonSerializer.Serialize(content, _jsonOptions);
        //        request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        //    }

        //    // Send the request
        //    var response = await _httpClient.SendAsync(request);

        //    // Check for a successful response
        //    if (!response.IsSuccessStatusCode)
        //    {
        //        Console.WriteLine($"ApiService: Request failed with status {response.StatusCode}");
        //        return false;
        //    }
        //    return true;

        //    //// Read and deserialize the response content
        //    //string str = await response.Content.ReadAsStringAsync();
        //    //if (str.Length == 0)
        //    //{
        //    //    return default;
        //    //}


        //    //var result = JsonSerializer.Deserialize<T>(str, _jsonOptions);
        //    //return result;
        //}
    }
}