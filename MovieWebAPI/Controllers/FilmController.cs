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


        #region GetFullFilmDetailsByIdFilm //Route = "details"
        [HttpGet]
        [Route("details")]
        public ActionResult GetFullFilmDetailsByIdFilm(int idF)
        {
            BLLmanager bllm = new BLLmanager();
            var ret = bllm.GetFullFilmDetailsByIdFilm(idF);
            return ret != null ? Ok(ret) : (ActionResult)NotFound();
        }
        #endregion
        #region GetFilmListWithName //Route = "title"
        [HttpGet]
        [Route("title")]
        #endregion
        #region  GetFilmListWithName
        public ActionResult GetFilmListWithName(string name, int index, int nbbypage)
        {
            BLLmanager bllm = new BLLmanager();
            var ret = bllm.GetFilmListWithName(name, index, nbbypage);
            return ret != null ? Ok(ret) : (ActionResult)NotFound();

        }
        #endregion
        #region GetPageOfFilmDTOOrderByTitle //Route ="page"
        [HttpGet]
        [Route("page")]
        public ActionResult GetPageOfFilmDTOOrderByTitle(int index, int nbbypage)
        {
           
            BLLmanager bllm = new BLLmanager();
            var ret = bllm.GetPageOfFilmDTOOrderByTitle(index, nbbypage);
            return ret != null ? Ok(ret) : (ActionResult)NotFound();

        }
        #endregion
        #region FindListFilmByPartialActorName //Route = "actorsName"
        [HttpGet]
        [Route("actorsName")]
        public ActionResult FindListFilmByPartialActorName(string name, int max)
        {
            BLLmanager bllm = new BLLmanager();
            var ret = bllm.FindListFilmByPartialActorName(name, max);
            return ret != null ? Ok(ret) : (ActionResult)NotFound();

        }
        [HttpGet]
        [Route("actorsId")]
        public ActionResult FindListFilmById(int id)
        {
            BLLmanager bllm = new BLLmanager();
            var ret = bllm.FindListFilmById(id);
            return ret != null ? Ok(ret) : (ActionResult)NotFound();

        }
        #endregion





    }
}
