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
using System.Threading.Tasks;

namespace MovieWEB.Controllers
{
    public class RechercheController : Controller
    {
        private readonly ILogger<FilmController> _logger;
        private static ListFilmModel FilmModel;
        private static int currentFilm = 0, nbFilm = 5;
       
        private static string Name;
        public RechercheController(ILogger<FilmController> logger)
        {
         
            _logger = logger;
        }
        private void LoadFilmFromAPI(int index, int nbbypage, string name)
        {
            
            Trace.WriteLine("LOAD");
            string query = "title?name=" + name + "&index=" + index + "&nbbypage=" + nbbypage;
            using (var client = new WebClient())
            {
                FilmModel = new ListFilmModel();
                //Get a string representation of the Json
                String finalQuery = (ConfigurationManager.AppSettings["basicUrl"] + query);
                String rawJson = client.DownloadString(finalQuery);
                List<FilmDTO> lf = JsonConvert.DeserializeObject<List<FilmDTO>>(rawJson);
                foreach (FilmDTO f in lf)
                {
                    FilmModel.Films.Add(new FilmUiModel(f));
                }
            }
        }
      
        #region Boutton
        [Route("/loadPrev")]
        public IActionResult BouttonPrevious()
        {
          
            Trace.WriteLine("prec");
            if (currentFilm == 0)
            {

            }
            else
            {
                currentFilm -= nbFilm;
            }
            LoadFilmFromAPI(currentFilm, nbFilm, Name);
            return View("Index", FilmModel);
        }
        [Route("/loadNext")]
        public IActionResult BouttonNext()
        {
          
            Trace.WriteLine("suiv");
            currentFilm += nbFilm;
            LoadFilmFromAPI(currentFilm, nbFilm, Name);
            return View("Index", FilmModel);
        }
        #endregion
        public IActionResult Index()
        {
            Trace.WriteLine("INDEX");
            FilmModel = new ListFilmModel();

            return View(FilmModel);
        }
        public IActionResult Recherche(string title, string name)
        {
            if(name==null)
            {
                return RedirectToAction("Index", "");
            }
            else
            {
               
                Name = name;
                Trace.WriteLine("------------");
                Trace.WriteLine("name :" + name);
                Trace.WriteLine("title :" + title);
                Trace.WriteLine("------------");
                LoadFilmFromAPI(currentFilm, nbFilm, name);
            }
          
            return View("index", FilmModel);
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
