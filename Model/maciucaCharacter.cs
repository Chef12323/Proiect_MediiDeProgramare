using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maciuca.Model
{
    public class maciucaCharacter
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int maciucaId { get; set; }
        public int CharacterId { get; set; }
    }
}
