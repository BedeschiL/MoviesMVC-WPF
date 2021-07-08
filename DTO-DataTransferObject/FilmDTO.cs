using System;
using System.Collections.Generic;
using System.Text;

namespace DTO_DataTransferObject
{
    public class FilmDTO
    {
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTime? Date { get; set; }
		public float VoteAverage { get; set; }
		public int Runtime { get; set; }
		public string Posterpath { get; set; }
		public List<CommentDTO> Comments { get; set; }
		public FilmDTO()
		{
		}
		public FilmDTO(int id, string title, DateTime? rd, float va, int rt, string pp, List<CommentDTO> comments)
		{
			Id = id;
			Title = title;
			Date = rd;
			VoteAverage = va;
			Runtime = rt;
			Posterpath = pp;
		}
	}
}
