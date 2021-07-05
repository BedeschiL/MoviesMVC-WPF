using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_DataAcessLayer
{
    public class Actor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Film> Films { get; set; } = new List<Film>();

        public Actor()
        {

        }
        public Actor(string text) // Constructeur d’objet Actor
        {
            string[] acteurdetail, characterdetail;
            string tmp;
            Char[] delimiterChars = { '\u2024' };
            acteurdetail = text.Split(delimiterChars);
            Id = Int32.Parse(acteurdetail[0]);
            Name = acteurdetail[1];
            delimiterChars[0] = '/';
            tmp = acteurdetail[2];
            characterdetail = tmp.Split(delimiterChars);
            Surname = characterdetail[0];
        }

        public String Draw()
        {
            return Id + Name + Surname;
        }
    }
}
