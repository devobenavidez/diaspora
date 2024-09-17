using Diaspora.Domain.Abstractions;
using Mailgun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Infrastructure.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly string _apiKey;
        private readonly string _domain;
        private readonly string _apiBaseUrl;
        private readonly string _fromEmail;

        public EmailService(string apiKey, string domain, string apiBaseUrl, string fromEmail)
        {
            _apiKey = apiKey;
            _domain = domain;
            _apiBaseUrl = apiBaseUrl;
            _fromEmail = fromEmail;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            using (var httpClient = new HttpClient())
            {
                // Configura la autenticación básica
                var authToken = Encoding.ASCII.GetBytes($"api:{_apiKey}");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

                // Contenido del formulario de solicitud POST
                var formContent = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "from", $"obenavidez@gmail.com" },
                { "to", toEmail },
                { "subject", subject },
                { "text", body }
            });

                // Realiza la solicitud POST
                var response = await httpClient.PostAsync($"{_apiBaseUrl}/{_domain}/messages", formContent);

                // Verifica el resultado de la solicitud
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to send email. Status Code: {response.StatusCode}");
                }
            }
        }
    }
}
