using AKS.WebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http.Headers;

namespace AKS.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        static HttpClient client = new HttpClient();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task<List<Temperatura>?> OnGetAsync()
        {

            List<Temperatura> lTemperatura = new List<Temperatura>();

            // Update port # in the following line.
            client.BaseAddress = new Uri("https://localhost:49155/weatherforecast");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

            
            if (response.IsSuccessStatusCode)
            {  
                string oResult = await response.Content.ReadAsStringAsync();
                lTemperatura = JsonConvert.DeserializeObject<List<Temperatura>>(oResult);
            }

            return lTemperatura;


        }
    }
}