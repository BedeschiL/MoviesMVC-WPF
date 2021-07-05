using DAL_DataAcessLayer;
using DAL_DataAcessLayer.Managers;
using DTO_DataTransferObject;
using System;
using System.Collections.Generic;

namespace BLL_BusinessLogicLayer
{
    public class BLLmanager
    {
        private DALmanager DALmanager; 
        public  BLLmanager()
        {
            DALmanager = new DALmanager(); 
        }
        
        public ICollection<LightActorDTO> GetListActorsByIdFilm(int id)
        {
            ICollection<LightActorDTO> retFoncActor = new List<LightActorDTO>();
            Film retFilm = new Film();
           
            retFilm = DALmanager.SelectFilmWithId(id);
            Console.WriteLine(retFilm.Comments.Count);
            Console.WriteLine(retFilm.Actors.Count);
            if (retFilm != null)
            {
                Console.WriteLine("Count" + retFilm.Actors.Count);
                foreach (Actor A in retFilm.Actors)
                {
                    LightActorDTO temp = new LightActorDTO(A.Id, A.Name, A.Surname);
                    
                    retFoncActor.Add(temp);
                }

            }
            return retFoncActor;
        }








    }
}
