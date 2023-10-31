using Microsoft.AspNetCore.Mvc;
using Lab9.Models;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace Lab9.ViewComponents
{
    public class WeatherDataViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherDataViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string region)
        {
            string apiKey = "9f0082b62987a051699622946c4f0786";
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.openweathermap.org/data/2.5/weather?q={region}&appid={apiKey}");
            var client = _httpClientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Weather> (content);
                return View(data);
            }

            return Content("Unable to retrieve weather data");
        }
    }
}
