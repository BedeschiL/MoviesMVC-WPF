
using DTO_DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GUImovieWEB.Models
{
    public class ActeurUImodel : ActorDTO
    {
        //public BitmapImage avatar { get; set; }
        public string resume { get; set; }
        public string avatar { get; set; }
        public string birthday { get; set; }
        public string birthplace { get; set; }
      

       

    }
}
