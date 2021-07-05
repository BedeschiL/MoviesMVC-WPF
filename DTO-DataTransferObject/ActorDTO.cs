using System;
using System.Collections.Generic;

namespace DTO_DataTransferObject
{
    public class ActorDTO
    {
		public int Id { get; set; }
		public int NbDeFilm { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public List<FilmDTO> Films { get; set; }
		public ActorDTO()
		{
		}
		public ActorDTO(int _nb, string _name, string _surname)
		{
			NbDeFilm = _nb;
			Surname = _surname;
			Name = _name;
		}
		public ActorDTO(int _id,int _nb, string _name, string _surname)
		{
			Id = _id;
			NbDeFilm = _nb;
			Surname = _surname;
			Name = _name;
		}
	}
}
