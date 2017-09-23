using System.Collections.Generic;
using System.Threading.Tasks;
using NumeneraCypherBook.Core.Models;

namespace NumeneraCypherBook.Core.Data
{
    public interface ICypherRepository
    {
        Task<List<Cypher>> Get();
        Task<Cypher> Get(int id);
    }
}
