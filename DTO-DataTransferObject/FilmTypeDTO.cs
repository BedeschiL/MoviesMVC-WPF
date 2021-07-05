using System;
using System.Collections.Generic;
using System.Text;

namespace DTO_DataTransferObject
{
    public class FilmTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FilmTypeDTO() // Constructeur de FilmType (type de film)
        {

        }
        public FilmTypeDTO(int _id, String _name) // Constructeur de FilmType (type de film)
        {
            Id = _id;
            Name = _name;
        }      
    }
	
}
