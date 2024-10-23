using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Api
{
    public class ConsultarTemp
    {
        private readonly HttpClient _httpClient;

        public ConsultarTemp()
        {
            _httpClient = new HttpClient();
        }

        public async Task<decimal> GetTempCidade(string cidade)
        {
            var apiKey = "c38a99ab51cd6613fdb204baf41ce7b7";
            _httpClient.BaseAddress = new Uri("https://api.openweathermap.org");
            var url = $"/data/2.5/weather?q={cidade}&appid={apiKey}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var temperatura = JsonConvert.DeserializeObject<TemperaturaResponse>(json);
                return temperatura.Main.Temp;
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Erro ao consultar a temperatura: {response.StatusCode} - {errorMessage}");
            }
        }

        private class TemperaturaResponse
        {
            public MainInfo Main { get; set; }
        }

        private class MainInfo
        {
            public decimal Temp { get; set; }
        }

    }
}