using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoWatch.Database.Models
{
    public class Character
    {
        public Guid Id { get; set; }
        public string CharacterName { get; set; }
        public string Role { get; set; }
        public string NickName { get; set; }

        public required Guid EpisodesId { get; set; }
        public Episode Episodes { get; set; }

        public required Guid PersonId { get; set; }
        public Person People { get; set; }


    }
}
