using BLL_BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebAPI.Controllers
{
    
    [Route("actor")]
    public class ActorController : Controller
    {
        [HttpGet]
        public ActionResult GetListActorsByIdFilm(int idMovie)
        {
            BLLmanager bllm = new BLLmanager();
            var ret = bllm.GetListActorsByIdFilm(idMovie);
            return ret != null ? Ok(ret) : (ActionResult)NotFound();

        }
        [HttpGet]
        [Route("favorite")]
        public ActionResult GetFavoriteActors(int nbFilm)
        {
            BLLmanager bllm = new BLLmanager();
            var ret = bllm.GetFavoriteActors(nbFilm);
            return ret != null ? Ok(ret) : (ActionResult)NotFound();

        }
    }
}
