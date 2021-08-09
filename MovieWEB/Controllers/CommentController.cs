using DTO_DataTransferObject;
using GUImovieWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieWEB.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class CommentController : Controller
    {
        private readonly ILogger<FilmController> _logger;

        public CommentController(ILogger<FilmController> logger)
        {
            _logger = logger;
        }
        public IActionResult Comment(string ID)
        {
            CommentModel idTemp = new CommentModel(int.Parse(ID));
            return View(idTemp);
        }
     


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            check();
        }
        public void check()
        {
            Console.WriteLine("TEST");
            Trace.WriteLine("TEST");
        }
    }
}
