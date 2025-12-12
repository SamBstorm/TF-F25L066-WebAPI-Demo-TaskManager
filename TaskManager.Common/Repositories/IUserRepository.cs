using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Common.Repositories
{
    public interface IUserRepository<TUser> where TUser : class
    {
        IEnumerable<TUser> Get();
        TUser GetCreator(Guid taskId);
        TUser Get(Guid userId);
        Guid Insert(TUser entity);
        bool Delete(Guid userId);
        TUser CheckPassword(string email, string password);
    }
}
