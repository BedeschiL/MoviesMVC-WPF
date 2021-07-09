using DTO_DataTransferObject;
using System;
using System.Collections.Generic;

namespace MovieWEB.Models
{
    public class FullFilmViewModel
    {
        public List<FullFilmDTO>  FullFilm { get; set; }
        public FullFilmViewModel(List<FullFilmDTO> listFilmDTO)
        {
            FullFilm = listFilmDTO;
        }
        public FullFilmViewModel()
        {
            FullFilm = new List<FullFilmDTO>();
        }
      
    }
}
