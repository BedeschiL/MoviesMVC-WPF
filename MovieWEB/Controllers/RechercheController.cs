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
        private static ListFilmModel FilmModel = new ListFilmModel();
        private static int currentFilm = 0, nbFilm = 5;
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
        public IActionResult Recherche(ListFilmModel model, string test, string localisation)
        {
            if(localisation!=null && localisation.CompareTo("") != 0)
            {
                if(localisation.CompareTo("suiv")==0)
                {
                    currentFilm += 5;
                }
                else
                {
                    currentFilm -= 5;
                }


            }

          
            Trace.WriteLine("MODEL NAME )====" + model.name);
            Trace.WriteLine("Test NAME )====" + test);
            Trace.WriteLine("LOCALISATION  )====" + localisation);
            FilmModel.name = model.name;
            if (model.name != null && model.name.CompareTo("") != 0)
            {
                Trace.WriteLine("test model name");
                LoadFilmFromAPI(currentFilm, nbFilm, model.name);
            }
            else if (test!=null && test.CompareTo("")!=0)
            {
                Trace.WriteLine("test name");
                LoadFilmFromAPI(currentFilm, nbFilm, test);
            }
           
           
            Trace.WriteLine("CURRENT" + currentFilm + " NB FILM" + nbFilm);
            
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
