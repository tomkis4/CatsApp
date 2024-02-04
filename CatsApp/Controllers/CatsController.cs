using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatsApp.Data;
using CatsApp.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace CatsApp.Controllers
{
    [Authorize]
    public class CatsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _apiKey = "live_Kg8HqvTiYpHdztHFk3w6RiVaptksun4cHmjtX90wKZ6qVKz1ZZ47wNizOntIlACC";

        public CatsController(ApplicationDbContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }

        // GET: Cats
        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("x-api-key", _apiKey);

            var response = await client.GetAsync("https://api.thecatapi.com/v1/images/search?limit=1&size=small");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            var catImages = JsonConvert.DeserializeObject<List<CatImage>>(responseBody);
            var catImage = catImages.FirstOrDefault() ?? new CatImage();

            return View(catImage);
        }

        // GET: Cats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catsModelEntity = await _context.CatsModelEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catsModelEntity == null)
            {
                return NotFound();
            }

            return View(catsModelEntity);
        }

        // Other controller methods (Create, Edit, Delete) remain unchanged
        // ...
    }
}





