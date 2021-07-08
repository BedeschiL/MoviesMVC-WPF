using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL_DataAcessLayer
{
    public class Film
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        //Release date du film
        public DateTime Date { get; set; }
        public float VoteAverage { get; set; }
        public int Runtime { get; set; }
        public string Posterpath { get; set; }

        public virtual ICollection<Actor> Actors { get; set; } = new List<Actor>();
        public virtual ICollection<FilmType> Types { get; set; } = new List<FilmType>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
