using DTO_DataTransferObject;
using System;
using System.Collections.Generic;

namespace MovieWEB.Models
{
    public class ListFilmModel
    {
        public List<FilmUiModel>  Films { get; set; }
        public ListFilmModel(List<FilmUiModel> listFilmDTO)
        {
            Films = listFilmDTO;
        }
        public ListFilmModel()
        {
            Films = new List<FilmUiModel>();
        }
      
    }
}
