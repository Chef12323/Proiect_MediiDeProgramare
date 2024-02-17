using SQLite;
using SQLiteNetExtensions.Attributes;

namespace maciuca.Model
{
    public class ListCharacter
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(maciuca))]
        public int maciucaId { get; set; }
        public int CharacterId { get; set; }
    }
}
