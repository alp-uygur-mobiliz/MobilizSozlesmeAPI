using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace MobilizSozlesmeAPI
{
    public static class TechSignAPI
    {
        private static readonly string baseUrl = "https://api.techsigndoc.com/";

        public static async Task GetDocumentAsync(string id)
        {
            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, baseUrl + "oauth/access_token");
            var content = new MultipartFormDataContent
            {
                { new StringContent("alpu@mobiliz.com.tr"), "client_id" },
                { new StringContent("47N4skMqp-G.h9K"), "client_secret" },
                { new StringContent("client_credentials"), "grant_type" }
            };
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var authResponse = await response.Content.ReadFromJsonAsync<TechSignAuthResponse>();


            var request2 = new HttpRequestMessage(HttpMethod.Get, baseUrl + "doc/" + id);
            request2.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authResponse?.access_token);
            var response2 = await client.SendAsync(request2);
            response2.EnsureSuccessStatusCode();

            var documentResponse = JObject.Parse(await response2.Content.ReadAsStringAsync());//load
            var dataObject = documentResponse.SelectToken("pdfTemplateData.editTextFields");//select
            var textFields = dataObject?.ToObject<EditTextField[]>(); //cast to array



        }
    }
}
