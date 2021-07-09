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
        public Actor(String AData)
        {
            var infoacteur = AData.Split('\u2024');
            Id = Int32.Parse(infoacteur[0], 0);
            var prenom = infoacteur[1].Split(" ");
            Name = prenom[0];
            if (prenom.Length > 1)
                Surname = prenom[1];
            Films = new List<Film>();
        }
    }
}
