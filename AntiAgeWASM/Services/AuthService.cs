using Microsoft.AspNetCore.Authorization;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AntiAgeWASM.Services
{
    public class AuthService(HttpClient http)
    {
        public string Token { get; set; } = "";

        public bool IsAuthenticated { get; private set; }
        public HttpClient Http { get; } = http;

        public event Action<bool> OnAuthenticationChanged;

        

        public async Task CheckAuthenticationAsync()
        {
            var response = await Http.GetAsync("api/auth/status"); // Or your actual auth-check endpoint

            bool isAuthenticated = response.IsSuccessStatusCode;
            if (IsAuthenticated != isAuthenticated)
            {
                IsAuthenticated = isAuthenticated;
                OnAuthenticationChanged?.Invoke(IsAuthenticated);
            }
        }
        
        public async Task<string> Login(string email, string password)
        {
            var response = await Http.PostAsJsonAsync($"/login?useCookies=false", new { email, password });

            if (response.IsSuccessStatusCode)
            {
                IsAuthenticated = true;
                OnAuthenticationChanged?.Invoke(true);
                Console.WriteLine(response.Content.Headers);
                
                Token = await response.Content.ReadAsStringAsync();

                var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();
                if (tokenResponse != null && !string.IsNullOrEmpty(tokenResponse.AccessToken))
                {
                    Token = tokenResponse.AccessToken;
                }
                else
                {
                    Token = string.Empty; // Handle the case where the AccessToken is null or empty
                    Console.WriteLine("AuthService: Token is either null or empty.");
                }

                return Token;
            }

            IsAuthenticated = false;
            OnAuthenticationChanged?.Invoke(false);
            return "";
        }

        public async Task Logout()
        {
            await Http.PostAsync("api/auth/logout", null);
            IsAuthenticated = false;
            OnAuthenticationChanged?.Invoke(false);
        }
    }

    public class TokenResponse
    {
        public string? TokenType { get; set; }
        public string? AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string? RefreshToken { get; set; }
    }
}