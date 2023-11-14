using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace Agenda.Api.Controllers.Clima
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperaturaController : Controller
    {
        private readonly string apiKey = "e0122df7d2c084aeaacfd6c3a7d59272";
        private readonly IHttpClientFactory _httpClientFactory;

        public TemperaturaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("{cidade}")]
        public async Task<IActionResult> GetClima(string cidade)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={cidade}&appid={apiKey}&lang=pt_br&units=metric";
            try
            {
                var client = _httpClientFactory.CreateClient();                
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var tempo = JsonSerializer.Deserialize<JsonDocument>(content);

                   
                    return Ok(tempo);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
    }
    
}
