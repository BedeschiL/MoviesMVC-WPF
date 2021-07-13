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


        #region GetFullFilmDetailsByIdFilm
        [HttpGet]
        [Route("details")]
        public ActionResult GetFullFilmDetailsByIdFilm(int idF)
        {
            BLLmanager bllm = new BLLmanager();
            var ret = bllm.GetFullFilmDetailsByIdFilm(idF);
            return ret != null ? Ok(ret) : (ActionResult)NotFound();
        }
        #endregion
        [HttpGet]
        [Route("title")]
        public ActionResult GetFilmListWithName(string name, int index, int nbbypage)
        {
            BLLmanager bllm = new BLLmanager();
            var ret = bllm.GetFilmListWithName(name, index, nbbypage);
            return ret != null ? Ok(ret) : (ActionResult)NotFound();

        }
        [HttpGet]
        [Route("page")]
        public ActionResult GetPageOfFilmDTOOrderByTitle(int index, int nbbypage)
        {
           
            BLLmanager bllm = new BLLmanager();
            var ret = bllm.GetPageOfFilmDTOOrderByTitle(index, nbbypage);
            return ret != null ? Ok(ret) : (ActionResult)NotFound();

        }

        #region FindListFilmByPartialActorName
        [HttpGet]
        [Route("actors")]
        public ActionResult FindListFilmByPartialActorName(string name, int max)
        {
            BLLmanager bllm = new BLLmanager();
            var ret = bllm.FindListFilmByPartialActorName(name, max);
            return ret != null ? Ok(ret) : (ActionResult)NotFound();

        }
        #endregion
   
        



    }
}
