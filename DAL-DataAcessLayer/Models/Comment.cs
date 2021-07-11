using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL_DataAcessLayer
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
        public string Username { get; set; }
        public DateTime Date { get; set; }

        public virtual Film Film { get; set; } = new Film(); // PEUT PETRE OAS UTIL


        public Comment() { }
        public Comment(int _id, string _content, int _note, string username)
        {
            this.Id = _id;
            Content = _content;
            Rate = _note;
            Username = username;
            Date = DateTime.Now;
        }
        
        public Comment(string content, int rate, string username, DateTime date, Film film)
        {
            Content = content;
            Rate = rate;
            Username = username;
            Date = DateTime.Now;
            Film = film;
        }
    }
}
