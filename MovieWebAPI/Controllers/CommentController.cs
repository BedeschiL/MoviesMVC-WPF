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

    [Route("comment")]
    public class CommentController : Controller
    {
        [HttpGet] 
        public ActionResult InsertCommentOnFilmId(int idFilm, string content, int rate, string username)
        {
            BLLmanager bllm = new BLLmanager();
            CommentDTO comment = new CommentDTO(content,rate,username);
            var ret = bllm.InsertCommentOnFilmId(idFilm, comment);
            if (ret == true)
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
