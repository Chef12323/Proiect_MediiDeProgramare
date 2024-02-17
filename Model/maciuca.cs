﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maciuca.Model
{
    using SQLite;

    [Table("maciuca")] 
    public class maciuca
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        [MaxLength(250), Unique]
        public string Description {  get; set; }
        public string image { get; set; }
        public int GenreId { get; set; }
        public int CharacterId { get; set; }
    }
}
