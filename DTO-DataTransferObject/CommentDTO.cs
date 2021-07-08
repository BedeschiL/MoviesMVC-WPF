using DAL_DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO_DataTransferObject
{
	public class CommentDTO
    {
		public int Id { get; set; }
		public string Content { get; set; }//Content ?
		public int Rate { get; set; }//de 1 à 5
		public string Username { get; set; }
	
		public DateTime Date { get; set; }
		public Film Film { get; set; } //one to many avec film

		public CommentDTO()
		{
		}
		public CommentDTO(string content, int rate,string username)
		{
			Content = content;
			Rate = rate;
			Username = username;
		}
		public CommentDTO(string content, int rate, string username, DateTime date, Film film)
		{
			Content = content;
			Rate = rate;
			Username = username;
			Date = date;
			Film = film;
		}

        public CommentDTO(string content, int rate, string username, DateTime date) : this(content, rate, username)
        {
        }
    }
}
