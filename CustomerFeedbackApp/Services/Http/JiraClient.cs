using CustomerFeedbackApp.Models;
using System.Net.Http.Headers;
using System.Text;

namespace CustomerFeedbackApp.Services.Http
{
    public class JiraClient
    {
        private readonly HttpClient _httpClient;
        public JiraClient(HttpClient httpClient, IConfiguration configuration)
        {
            
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["JiraIssueRestApiURL"]);
            var basicAuthenticationUsername = configuration["BasicAuthenticationUsername"];
            var basicAuthenticationPassword = configuration["BasicAuthenticationPassword"];
            var basicAuthenticationValue =
                Convert.ToBase64String(
                    Encoding.ASCII.GetBytes($"{basicAuthenticationUsername}:{basicAuthenticationPassword}"));
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", basicAuthenticationValue);
        }
        public async Task<HttpResponseMessage> PostAsync(string feedback) => await _httpClient.PostAsJsonAsync("issue", feedback);
    }
}
