using DAL_DataAcessLayer;
using DAL_DataAcessLayer.Managers;
using DTO_DataTransferObject;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace BLL_BusinessLogicLayer
{
    public class BLLmanager
    {
        private DALmanager dalManager; 
        public  BLLmanager()
        {
            dalManager = new DALmanager(); 
        }
        //Actors
        #region GetListActorsByIdFilm
        public ICollection<LightActorDTO> GetListActorsByIdFilm(int id)
        {
            ICollection<LightActorDTO> retFoncActor = new List<LightActorDTO>();
            Film retFilm = new Film();
           
            retFilm = dalManager.SelectFilmWithId(id);
            if (retFilm != null)
            {
               
                foreach (Actor A in retFilm.Actors)
                {
                    LightActorDTO temp = new LightActorDTO(A.Id, A.Name, A.Surname);
                    
                    retFoncActor.Add(temp);
                }

            }
            return retFoncActor;
        }
        #endregion
        #region GetFavoriteActors
        public ICollection<ActorDTO> GetFavoriteActors(int nbDefilmCondition)
        {
            List<ActorDTO> listFavoriteAct = new List<ActorDTO>();
            var listactor = dalManager.SelectActorNbFilmMin(nbDefilmCondition);


            foreach (Actor a in listactor)
            {

                listFavoriteAct.Add(new ActorDTO(a.Id, a.Name, a.Surname));


            }
            return listFavoriteAct;
        }
        #endregion
        //Types
        #region GetListFilmTypesByIdFilm
        public ICollection<FilmTypeDTO> GetListFilmTypesByIdFilm(int id)
        {
            ICollection<FilmTypeDTO> retFoncTypes = new List<FilmTypeDTO>();
            Film retFilm = new Film();
            retFilm = dalManager.SelectFilmWithId(id);
            if (retFilm != null)
            {
                
                foreach (FilmType A in retFilm.Types)
                {
                    FilmTypeDTO temp = new FilmTypeDTO(A.Id, A.Name);
                   
                    retFoncTypes.Add(temp);
                }
            }
            return retFoncTypes;
        }
        #endregion
        //Film
        #region FindListFilmByPartialActorName
        public List<FilmDTO> FindListFilmByPartialActorName(String name, int maxFilm)
        {
            var listactor = dalManager.SelectActorWithName(name);

            List<FilmDTO> ListFilm = new List<FilmDTO>();
            int i = 0;

            foreach (Actor a in listactor)
            {
                i++;
                if (i > maxFilm)
                    break;
                foreach (Film f in a.Films)
                {
                    f.Posterpath=getImage(f.Id);
                    f.VoteAverage = voteAverageCalculator(f);

                    List<CommentDTO> Comments = new List<CommentDTO>();
                    foreach (Comment c in f.Comments)
                    {
                        Comments.Add(new CommentDTO(c.Content, c.Rate, c.Username, c.Date));
                    }
                    ListFilm.Add(new FilmDTO(f.Id, f.Title, f.Date, f.VoteAverage, f.Runtime, f.Posterpath, Comments));
                }
            }

            return (ListFilm);
        }
        #endregion
        #region GetFullFilmDetailsByIdFilm
        public FullFilmDTO GetFullFilmDetailsByIdFilm(int id)
        {
            Film f = new Film();
            ICollection<ActorDTO> listActeur = new List<ActorDTO>();
            ICollection<FilmTypeDTO> listFilmType = new List<FilmTypeDTO>();
            ICollection<CommentDTO> listComment = new List<CommentDTO>();
            f = dalManager.SelectFilmWithId(id);

            if (f != null)
            {
                f.Posterpath = getImage(f.Id);
                f.VoteAverage = voteAverageCalculator(f);
                foreach (Actor acTemp in f.Actors)
                {
                    listActeur.Add(new ActorDTO(acTemp.Id, 0, acTemp.Name, acTemp.Surname));
                }
                foreach (FilmType tTemp in f.Types)
                {
                    listFilmType.Add(new FilmTypeDTO(tTemp.Id, tTemp.Name));
                }
                foreach (Comment cTemp in f.Comments)
                {
                    listComment.Add(new CommentDTO(cTemp.Content, cTemp.Rate, cTemp.Username, cTemp.Date, f));
                }
                FullFilmDTO ffDTO = new FullFilmDTO(f.Id, f.Title, f.Date,
                    f.VoteAverage, f.Runtime, f.Posterpath, listActeur, listFilmType, listComment);
                return ffDTO;
            }
            return null;
        }
        #endregion
        #region GetPageOfFilmOrderByTitle
        public List<FilmDTO> GetPageOfFilmDTOOrderByTitle(int index, int nbbypage)
        {
            var PageFIlm = dalManager.GetPageOfFilmOrderByTitle(index, nbbypage);

            List<FilmDTO> Page = new List<FilmDTO>();

            foreach (Film f in PageFIlm)
            {
                f.Posterpath = getImage(f.Id);
                f.VoteAverage = voteAverageCalculator(f);
                ICollection<CommentDTO> listComment = new List<CommentDTO>();
                foreach (Comment c in f.Comments)
                {
                    listComment.Add(new CommentDTO(c.Content, c.Rate, c.Username, c.Date, f));
                }
                Page.Add(new FilmDTO(f.Id, f.Title, f.Date, f.VoteAverage, f.Runtime, f.Posterpath, listComment));
            }
            return Page;
        }

        #endregion
        #region GetFilmWithName
        public List<FilmDTO> GetFilmListWithName(string name, int index, int nbbypage)
        {
            var lf = dalManager.GetFilmListWithName(name, index, nbbypage);

            List<FilmDTO> ListFilm = new List<FilmDTO>();

            foreach (Film f in lf)
            {
                f.Posterpath = getImage(f.Id);
                List<CommentDTO> Comments = new List<CommentDTO>();
                foreach (Comment c in f.Comments)
                {
                    Comments.Add(new CommentDTO(c.Content, c.Rate, c.Username, c.Date));
                }
                ListFilm.Add(new FilmDTO(f.Id, f.Title, f.Date, f.VoteAverage, f.Runtime, f.Posterpath, Comments));
            }
            return (ListFilm);
        }
        #endregion

        //Comment
        #region InsertCommentOnFilmId
        public Boolean InsertCommentOnFilmId(int IDF, CommentDTO c)
        {
            Film f = dalManager.SelectFilmWithId(IDF);
            if (f != null)
                dalManager.InsertComment(new Comment(c.Content, c.Rate, c.Username, c.Date, f));
            else
                return (false);
            return (true);
        }
        #endregion

        #region GetImage
        public String getImage(int id)
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage r = client.GetAsync("https://api.themoviedb.org/3/movie/" + id + "?api_key=b61acbc4c15132b3cb5328f331b3c034").Result;    
            if (!r.IsSuccessStatusCode)
            {
               
                return "";
            }
            else
            {

                string s = r.Content.ReadAsStringAsync().Result;
                var data = (JObject)JsonConvert.DeserializeObject(s);
                String newPath = data["poster_path"].Value<String>();
                newPath = "https://image.tmdb.org/t/p/w500" + newPath;
                return newPath;
            }
        }
        #endregion
        #region VoteAverageCalculator
        public float voteAverageCalculator(Film f)
        {
            int countComment = f.Comments.Count;
            float voteAverage=0;
            foreach(Comment c in f.Comments)
            {
                voteAverage = voteAverage + c.Rate;
            }
            float final = voteAverage / (float)countComment;
            return (float) Math.Round(final,2);
        }
        #endregion
    }



}
