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
        private static int currentFilm=0, nextfilm=5;

        public FilmController(ILogger<FilmController> logger)
		{			
            _logger = logger;
		}
        private void LoadFilmFromAPI(int index, int nbbypage)
        {
            Trace.WriteLine("\n\nLoadFilmFromapi current " + currentFilm + "nextfilm" + nextfilm);
            Trace.WriteLine("\n\nCOUNT LIST FILM "+ FilmModel.Films.Count);
            
          
            string querytype = "page";
            string query = "?index=" + index + "&nbbypage=" + nbbypage;

            using (var client = new WebClient())
            {
                //Get a string representation of the Json
                String finalQuery = (ConfigurationManager.AppSettings["basicUrl"] + querytype + query);
                String rawJson = client.DownloadString(finalQuery);

                List<FilmDTO> lf = JsonConvert.DeserializeObject<List<FilmDTO>>(rawJson);
                foreach(FilmDTO f in lf)
                {
                    FilmModel.Films.Add(new FilmUiModel(f));
                }
               


            }
        }
        #region Boutton
        [Route("FilmController/BouttonPrevious")]
        public IActionResult BouttonPrevious()
        {
            Trace.WriteLine("BouttonPrevious\n");
            Trace.WriteLine("current " + currentFilm +"nextfilm" + nextfilm);
            currentFilm -= 5;
                nextfilm -= 5;
            
            return RedirectToAction("Index", "Film");
        }
        [Route("FilmController/BouttonNext")]
        public IActionResult BouttonNext()
        {
            Trace.WriteLine("Boutton next\n");
            Trace.WriteLine("current " + currentFilm + "nextfilm" + nextfilm);

            currentFilm += 5;
                nextfilm += 5;
           
            return RedirectToAction("Index", "Film");
        }
        #endregion
        public IActionResult Index()
        {
            
            LoadFilmFromAPI(currentFilm, nextfilm);
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
