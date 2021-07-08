using BLL_BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebAPI.Controllers
{
   
    [Route("movie")]
    public class FilmController : Controller
    {
      
        [HttpGet]
        [Route("details={idF}")]
        public ActionResult GetFullFilmDetailsByIdFilm(int idF)
        {
            BLLmanager bllm = new BLLmanager();
            var ret = bllm.GetFullFilmDetailsByIdFilm(idF);
            
                return Ok(ret);
            
           
        }
        [HttpGet]
        [Route("actors={name}")]
        public ActionResult FindListFilmByPartialActorName(String name, int max)
        {
            BLLmanager bllm = new BLLmanager();
            var ret = bllm.FindListFilmByPartialActorName(name, max);
            if (ret != null)
            {
                return Ok(ret);
            }
            else
            {
                return NotFound();
            }
        }






    }
}
