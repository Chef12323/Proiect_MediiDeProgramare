using SQLite;
using SQLiteNetExtensions.Attributes;

namespace maciuca.Model
{
    public class Genre
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        [OneToMany]
        public List<ListGenre> ListGenres { get; set; }
    }
}
