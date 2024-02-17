using SQLite;
using SQLiteNetExtensions.Attributes;

namespace maciuca.Model
{
    public class ListGenre
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(maciuca))]
        public int maciucaId { get; set; }
        public int GenreId { get; set; }
    }
}
