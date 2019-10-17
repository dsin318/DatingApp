using System.Collections;
using System.Threading.Tasks;
using DattingApp.API.Models;

namespace DattingApp.API.Data
{
    public interface IDatingRepository
    {
         void Add<T> (T entity) where T: class;

         void Delete<T> (T entity) where T: class;

         Task<bool> SaveAll();
         Task<IEnumerable> GetUsers();
         Task<User> GetUser(int id);
    }
}