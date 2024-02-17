using maciuca.Model;
using SQLite;


namespace maciuca.Data
{
    public class maciucaDbContext
    {
        readonly SQLiteAsyncConnection _database;

        public maciucaDbContext(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<maciuca>().Wait();

            _database.CreateTableAsync<Genre>().Wait();
            _database.CreateTableAsync<ListGenre>().Wait();
            _database.CreateTableAsync<Character>().Wait();
            _database.CreateTableAsync<ListCharacter>().Wait();
        }


        //Character
        public Task<int> SaveCharacterAsync(Character character)
        {
            if (character.Id != 0)
            {
                return _database.UpdateAsync(character);
            }
            else
            {
                return _database.InsertAsync(character);
            }
        }
        public Task<int> DeleteCharacterAsync(Character character)
        {
            return _database.DeleteAsync(character);
        }
        public Task<List<Character>> GetCharacterAsync()
        {
            return _database.Table<Character>().ToListAsync();
        }

        //Genre
        public Task<int> SaveGenreAsync(Genre genre)
        {
            if (genre.Id != 0)
            {
                return _database.UpdateAsync(genre);
            }
            else
            {
                return _database.InsertAsync(genre);
            }
        }
        public Task<int> DeleteGenreAsync(Genre genre)
        {
            return _database.DeleteAsync(genre);
        }
        public Task<List<Genre>> GetGenreAsync()
        {
            return _database.Table<Genre>().ToListAsync();
        }

        //maciuca
        public Task<List<maciuca>> GetmaciucaAsync()
        {
            return _database.Table<maciuca>().ToListAsync();
        }
        public Task<maciuca> GetmaciucaAsync(int id)
        {
            return _database.Table<maciuca>()
            .Where(i => i.Id == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SavemaciucaAsync(maciuca maciuca)
        {
            if (maciuca.Id != 0)
            {
                return _database.UpdateAsync(maciuca);
            }
            else
            {
                return _database.InsertAsync(maciuca);
            }
        }
        public Task<int> DeletemaciucaAsync(maciuca slist)
        {
            return _database.DeleteAsync(slist);
        }

        public Task<int> SaveListGenreAsync(ListGenre listp)
        {
            if (listp.Id != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Genre>> GetListGenreAsync(int shoplistid)
        {
            return _database.QueryAsync<Genre>(
            "select P.Id, P.Name from Genre P"
            + " inner join ListGenre LP"
            + " on P.Id = LP.GenreId where LP.maciucaId = ?",
            shoplistid);
        }


        public Task<int> SaveListCharacterAsync(ListCharacter listp)
        {
            if (listp.Id != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Character>> GetListCharacterAsync(int shoplistid)
        {
            return _database.QueryAsync<Character>(
            "select P.Id, P.Name from Character P"
            + " inner join ListCharacter LP"
            + " on P.Id = LP.CharacterId where LP.maciucaId = ?",
            shoplistid);
        }
    }
}


