using DTO_DataTransferObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace DTO_DataTransferObject
{
    public class FullFilmDTO 
    {
        public FullFilmDTO()
        {

        }
        public FullFilmDTO(int _id, string _title, DateTime _rd, float _va, int _rt, string _pp, ICollection<ActorDTO> _ActorsDTO, ICollection<FilmTypeDTO> _TypesDTO, ICollection<CommentDTO> _CommentsDTO)
        {
            Id = _id;
            Title = _title;
            Date = _rd;
            VoteAverage = _va;
            Runtime = _rt;
            Posterpath = _pp;
            ActorsDTO = _ActorsDTO;
            TypesDTO = _TypesDTO;
            CommentsDTO = _CommentsDTO;
        }
        public FullFilmDTO(int _id, string _title, DateTime _rd, float _va, int _rt, string _pp)
        {
            Id = _id;
            Title = _title;
            Date = _rd;
            VoteAverage = _va;
            Runtime = _rt;
            Posterpath = _pp;
          
        }
        private int _id;
        private string _title;
        private DateTime _date;
        private float _voteAverage;
        private int _runtime;
        private string _posterpath;
        public int Id { get { return _id; } set { _id = value;  } }
        public string Title { get { return _title; } set { _title = value;  } }
        //Release date du film
        public DateTime Date { get { return _date; } set { _date = value;} }
        public float VoteAverage { get { return _voteAverage; } set { _voteAverage = value; } }
        public int Runtime { get { return _runtime; } set { _runtime = value; } }
        public string Posterpath { get { return _posterpath; } set { _posterpath = value; } }
        public ICollection<ActorDTO> ActorsDTO { get; set; } = new List<ActorDTO>();
        public ICollection<FilmTypeDTO> TypesDTO { get; set; } = new List<FilmTypeDTO>();
        public ICollection<CommentDTO> CommentsDTO = new List<CommentDTO>();

        public String ToString()
        {

            String temp = "ID:" + this.Id;
            foreach (FilmTypeDTO t in this.TypesDTO)
            {
                Console.WriteLine(t.Name);
            }
            return temp;
        }
    }
}
