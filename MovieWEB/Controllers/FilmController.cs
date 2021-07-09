using DTO_DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieWEB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieWEB.Controllers
{
    public class FilmController : Controller
    {
		private readonly ILogger<FilmController> _logger;
        private ListFilmModel FilmModel = new ListFilmModel();
       

        public FilmController(ILogger<FilmController> logger)
		{
			
            _logger = logger;
            LoadFilmFromAPI();
          

		}
        private void LoadFilmFromAPI()
        {
            string querytype = "page";
            string query = "?index=" + 0 + "&nbbypage=" + 5;

            using (var client = new WebClient())
            {
                //Get a string representation of the Json
                String finalQuery = (ConfigurationManager.AppSettings["basicUrl"] + querytype + query);
                String rawJson = client.DownloadString(finalQuery);

                List<FilmDTO> lf = JsonConvert.DeserializeObject<List<FilmDTO>>(rawJson);
                FilmModel.Films = lf;


            }
        }
      
        public IActionResult Index()
        {
            return View(FilmModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


	}
}
