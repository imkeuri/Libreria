using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.IContratos
{
    public interface IBooksContract<T>
    {
        Task<List<T>> GetBooks();
        Task<T> GetBooksById(int id);
        Task<T> CreateBooks (T obj);
        Task DeleteBooks (int id);
        Task<T> UpdateBooks(T obj);
    }
}
