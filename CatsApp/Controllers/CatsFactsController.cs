using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CatsApp.Controllers
{
    [Authorize] 
    public class CatFactsController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public CatFactsController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var catFacts = await GetCatFactsFromApi();

            return View("/Views/CatsFacts/Index.cshtml", catFacts);
        }

        [HttpGet]
        public async Task<IActionResult> GetNextFact()
        {
            var catFact = await GetCatFactFromApi();
            return Json(catFact);
        }

        private async Task<CatFact> GetCatFactFromApi()
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var response = await client.GetAsync("https://catfact.ninja/fact?max_length=140");

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var catFactResponse = JsonConvert.DeserializeObject<CatFactResponse>(responseBody);
                return new CatFact { Text = catFactResponse.Fact };
            }
            else
            {
                return new CatFact();
            }
        }

        private async Task<List<CatFact>> GetCatFactsFromApi()
        {
            var catFact = await GetCatFactFromApi();
            return new List<CatFact> { catFact };
        }
    }

    public class CatFact
    {
        public string Text { get; set; }
    }

    public class CatFactResponse
    {
        public string Fact { get; set; }
    }
}














