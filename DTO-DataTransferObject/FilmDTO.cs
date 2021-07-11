using System;
using System.Collections.Generic;
using System.Text;

namespace DTO_DataTransferObject
{
    public class FilmDTO
    {
		protected int _id;
		protected string _title;
		protected DateTime _date;
		protected float _voteAverage;
		protected int _runtime;
		protected string _posterpath;
		public virtual int Id { get { return _id; } set { _id = value; } }
		public virtual string Title { get { return _title; } set { _title = value; } }
		//Release date du film
		public virtual DateTime Date { get { return _date; } set { _date = value; } }
		public virtual float VoteAverage { get { return _voteAverage; } set { _voteAverage = value; } }
		public virtual int Runtime { get { return _runtime; } set { _runtime = value; } }
		public virtual string Posterpath { get { return _posterpath; } set { _posterpath = value; } }
		public List<CommentDTO> Comments { get; set; }
		public FilmDTO()
		{
		}
		public FilmDTO(int id, string title, DateTime rd, float va, int rt, string pp, List<CommentDTO> comments)
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
