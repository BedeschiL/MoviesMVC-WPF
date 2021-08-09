using DTO_DataTransferObject;
using System;
using System.Collections.Generic;

namespace MovieWEB.Models
{
    public class ListFilmModel
    {
        public string name { get; set; }
        public static int deb  = 0;
        public static int nbfilm  = 5;
        public int Deb
        {
            get { return deb; }
            set { deb = value; }
        }
        public int Nbfilm
        {
            get { return nbfilm; }
            set { nbfilm = value; }
        }

        public List<FilmUiModel>  Films { get; set; }
        public ListFilmModel(List<FilmUiModel> listFilmDTO)
        {

            Films = listFilmDTO;

        }
        public ListFilmModel(string _name)
        {
            name = _name;
            Films = new List<FilmUiModel>();
        }
        public ListFilmModel()
        {
            Films = new List<FilmUiModel>();
        }
      public void plus()
        {
            deb = deb + 5;    
        }
        public void moins()
        {
            deb = deb - 5;
        }
        public override string ToString()
        {
            return " Name +DEBUT + FIN " + deb +"  " + nbfilm + name;
        }
    }
}
