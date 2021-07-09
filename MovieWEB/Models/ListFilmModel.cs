using DTO_DataTransferObject;
using System;
using System.Collections.Generic;

namespace MovieWEB.Models
{
    public class ListFilmModel
    {
        public List<FilmDTO>  Films { get; set; }
        public ListFilmModel(List<FilmDTO> listFilmDTO)
        {
            Films = listFilmDTO;
        }
        public ListFilmModel()
        {
            Films = new List<FilmDTO>();
        }
      
    }
}
