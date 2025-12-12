using TaskManager.BLL.Entities;
using TaskManager.BLL.Mapper;
using TaskManager.Common.Repositories;

namespace TaskManager.BLL.Services
{
    public class ManagedTaskService : ITaskRepository<ManagedTask>
    {
        private ITaskRepository<DAL.Entities.ManagedTask> _dalService;
        private IUserRepository<User> _userService;

        public ManagedTaskService(
            ITaskRepository<DAL.Entities.ManagedTask> dalService, 
            IUserRepository<User> userService)
        {
            _dalService = dalService;
            _userService = userService;
        }

        public bool Delete(Guid taskId)
        {
            return _dalService.Delete(taskId);
        }

        public IEnumerable<ManagedTask> Get()
        {
            return _dalService.Get().Select(dal => {
                User creator = _userService.GetCreator(dal.TaskId);
                return dal.ToBLL(creator);
            });
        }

        public ManagedTask Get(Guid taskId)
        {
            User creator = _userService.GetCreator(taskId);
            return _dalService.Get(taskId).ToBLL(creator);
        }

        public Guid Insert(ManagedTask entity)
        {
            return _dalService.Insert(entity.ToDAL());
        }

        public bool Update(Guid taskId, ManagedTask entity)
        {
            return _dalService.Update(taskId, entity.ToDAL());
        }
    }
}
