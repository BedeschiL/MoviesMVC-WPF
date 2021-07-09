using BLL_BusinessLogicLayer;
using DTO_DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebAPI.Controllers
{
   
    [Route("filmtype")]
    public class FilmTypeController : Controller
    {
        [HttpGet]
        [Route("idMovie={idMovie}")]
        public ActionResult GetListFilmTypesByIdFilm(int idMovie)
        {
            BLLmanager bllm = new BLLmanager();
            var ret = bllm.GetListFilmTypesByIdFilm(idMovie);
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
