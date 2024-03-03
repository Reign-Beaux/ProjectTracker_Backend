using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PT.Application.ExternalServices.WhatsApp.Models;
using System.Net.Http.Headers;

namespace PT.Application.ExternalServices.WhatsApp
{
    public class WhatsAppService
    {
        private readonly WhatsAppSettings _settings;

        public WhatsAppService(IOptions<WhatsAppSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendCode(string code, string recipient, string template)
        {
            var payload = new
            {
                messaging_product = "whatsapp",
                to = recipient,
                type = "template",
                template = new
                {
                    name = template,
                    language = new { code = "es_MX" },
                    components = new[]
                    {
                        new
                        {
                            type = "body",
                            parameters = new[]
                            {
                                new { type = "text", text = code }
                            }
                        }
                    }
                },
            };
            var jsonPayload = JsonConvert.SerializeObject(payload);

            HttpClient client = new();
            HttpRequestMessage request = new(HttpMethod.Post, _settings.EndPoint);
            request.Headers.Add("Authorization", $"Bearer {_settings.Token}");
            request.Content = new StringContent(jsonPayload);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage responseMessage = await client.SendAsync(request);
            await responseMessage.Content.ReadAsStringAsync();
        }
    }
}
