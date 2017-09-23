using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using NumeneraCypherBook.Core.Data;
using NumeneraCypherBook.Core.Models;

namespace NumeneraCypherBook.Core.Data.EntityFramework
{
    public class CypherRepository : ICypherRepository
    {
        private NumeneraContext _db { get; set; }

        public CypherRepository(NumeneraContext db)
        {
            _db = db;
        }

        public async Task<List<Cypher>> Get()
        {
            return await _db.Cyphers.ToListAsync();
        }

        public async Task<Cypher> Get(int id)
        {
            return await _db.Cyphers.FirstOrDefaultAsync(cypher => cypher.Id == id);
        }
    }
}
