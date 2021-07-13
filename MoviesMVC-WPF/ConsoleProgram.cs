
using BLL_BusinessLogicLayer;
using DAL_DataAcessLayer;
using DAL_DataAcessLayer.Managers;
using DAL_DataAcessLayer.Parser;
using DTO_DataTransferObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MoviesMVC_WPF
{
    class ConsoleProgram
    {
        static void Main(string[] args)
        {
            FileParser fp = new FileParser();
            BLLmanager bll = new BLLmanager();
            DALmanager dal = new DALmanager();
            List<FilmDTO> tempActDTO = bll.GetPageOfFilmDTOOrderByTitle(0, 5);
            Console.WriteLine(tempActDTO.Count());
            //CREATION DB

            /* string movieFilePath = "C:\\movie\\movie.txt";
             fp.LoadTextFileInDB(movieFilePath,500);
             //------------------------
           */

            //TEST BLL 
            BLLmanager BLLmanager = new BLLmanager();
            /*
            /////////////////////////////////////////////////TEST FILM TYPES BY ID
            ICollection<FilmTypeDTO> tempFilmTypeDTO = BLLmanager.GetListFilmTypesByIdFilm(2);
            Console.WriteLine("Genre : \n");
            foreach (FilmTypeDTO t in tempFilmTypeDTO)
            {
                Console.WriteLine(t.Name + t.Id);
            }
            /////////////////////////////////////////////////TEST ACTOR BY ID
            ICollection<LightActorDTO> tempActDTO = BLLmanager.GetListActorsByIdFilm(2);
            Console.WriteLine("List Acteur by id : \n");
            foreach (LightActorDTO t in tempActDTO)
            {
                Console.WriteLine(t.Name + t.Id);
            }
            /////////////////////////////////////////////////TEST ACTOR PARTIAL NAME
            ICollection<FilmDTO> tempActDTOpartial = BLLmanager.FindListFilmByPartialActorName("for", 2);
            Console.WriteLine("List Acteur by partial name : \n");
            foreach (FilmDTO t in tempActDTOpartial)
            {
                Console.WriteLine(t.Title + t.Id);
            }
            /////////////////////////////////////////////////TEST ACTOR FAVORITE ACT
            ICollection<ActorDTO> tempActDTOFavoAct = BLLmanager.GetFavoriteActors(70);
            Console.WriteLine("List of Favorite Act : \n");
            foreach (ActorDTO t in tempActDTOFavoAct)
            {
                Console.WriteLine(t.Name + t.Surname);
            }*/
            /////////////////////////////////////////////////TEST GetFullFilmDetailsByIdFilm
            ///
          /*
            Console.WriteLine("Get fullfilmd etail : \n");
            FullFilmDTO fullFilmDTOs = BLLmanager.GetFullFilmDetailsByIdFilm(389);
            Console.WriteLine(fullFilmDTOs.ToString());


            Console.WriteLine("Get NBBYPAGE  : \n");
            List<FilmDTO> fdto = BLLmanager.GetPageOfFilmDTOOrderByTitle(0,5);
            Console.WriteLine("nb film" + fdto.Count);
            foreach(FilmDTO f in fdto)
            {
                Console.WriteLine("COUNT COMMENT " + f.Comments.Count);
            }
          */
            /////////////////////////////////////////////////TEST InsertComment

            /*
               Console.WriteLine("Insert Comment : \n");
               CommentDTO c = new CommentDTO("Bien", 5,"Louis",DateTime.Now);
               BLLmanager.InsertCommentOnFilmId(389, c);*/


            Console.WriteLine("SORTIE DU PROGR!");
            Console.ReadKey();
        }
    }
}
