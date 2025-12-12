using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Common.Repositories
{
    public interface ITaskRepository<TTask> where TTask : class
    {
        IEnumerable<TTask> Get();
        TTask Get(Guid taskId);
        Guid Insert(TTask entity);
        bool Update(Guid taskId, TTask entity);
        bool Delete(Guid taskId);
    }
}
