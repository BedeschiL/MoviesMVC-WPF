using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL_DataAcessLayer
{
    public class FilmType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

       

        public FilmType(string _text) // Constructeur de FilmType (type de film)
        {
            string[] genredetail;
            Char[] delimiterChars = { '\u2024' };
            genredetail = _text.Split(delimiterChars);
            Id = Int32.Parse(genredetail[0]);
            Name = genredetail[1];
        }
        public FilmType() // Constructeur de FilmType (type de film)
        {

        }
        public FilmType(int _id, String _name) // Constructeur de FilmType (type de film)
        {
            Id = _id;
            Name = _name;
        }


        public virtual ICollection<Film> Films { get; set; } = new List<Film>();
    }
}
