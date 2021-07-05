using System;
using System.Collections.Generic;
using System.Text;

namespace DTO_DataTransferObject
{
    public class LightActorDTO
    {
        public LightActorDTO()
        {

        }
        public LightActorDTO(int _id, String _name, String _surname)
        {
            Id = _id;
            Name = _name;
            Surname = _surname;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }    
    }
}
