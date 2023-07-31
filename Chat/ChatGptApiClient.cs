using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Vertical;

public class ChatGptApiClient
{
    private const string ApiEndpoint = "https://api.openai.com/v1/chat/completions";
    private const string ApiKey = "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";

    public async Task<string> GetChatResponse(string message)
    {
        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");
            var requestBody = new
            {
                messages = new[]
                {
                    new { role = "system", content = "You are a helpful assistant." },
                    new { role = "user", content = message }
                }
            };
            var jsonRequest = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(ApiEndpoint, httpContent);
            var jsonResponse = await response.Content.ReadAsStringAsync();

            // Verifica o código de status da resposta HTTP
            if (response.IsSuccessStatusCode)
            {
                // Extrai a resposta da API
                var apiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ChatGptApiResponse>(jsonResponse);
                var chatResponse = apiResponse.choices[0].message.content;
                return chatResponse;
            }
            else
            {
                // Lidar com erros de chamada à API, se necessário
                Console.WriteLine($"Erro ao chamar a API: {response.StatusCode} - {jsonResponse}");
                return null;
            }
        }
    }
    
    public class ChatGptApiResponse
    {
        public ChatGptApiChoice[] choices { get; set; }
    }

    public class ChatGptApiChoice
    {
        public ChatGptApiMessage message { get; set; }
    }

    public class ChatGptApiMessage
    {
        public string role { get; set; }
        public string content { get; set; }
    }
}