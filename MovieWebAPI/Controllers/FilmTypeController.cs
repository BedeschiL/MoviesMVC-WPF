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
    #region GetListFilmTypesByIdFilm //Route ="filmtype"
    [Route("filmtype")]
    public class FilmTypeController : Controller
    {
        [HttpGet]
        public ActionResult GetListFilmTypesByIdFilm(int idMovie)
        {
            BLLmanager bllm = new BLLmanager();
            var ret = bllm.GetListFilmTypesByIdFilm(idMovie);
            return ret != null ? Ok(ret) : (ActionResult)NotFound();
        }
    }
    #endregion
}
