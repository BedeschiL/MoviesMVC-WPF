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
    public class DetailsController : Controller
    {
        private readonly ILogger<FilmController> _logger;

        public DetailsController(ILogger<FilmController> logger)
        {
            _logger = logger;
        }

        public IActionResult Details(int id)
        {
            FullFilmDTO lf;
          
            string query = "details?idF="+id;
            using (var client = new WebClient())
            {
                //Get a string representation of the Json
                String finalQuery = (ConfigurationManager.AppSettings["basicUrl"] + query);
                String rawJson = client.DownloadString(finalQuery);
                 lf = JsonConvert.DeserializeObject<FullFilmDTO> (rawJson);
                
            }
            DetailsModel dmodel = new DetailsModel(lf);
            return View(dmodel);
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
