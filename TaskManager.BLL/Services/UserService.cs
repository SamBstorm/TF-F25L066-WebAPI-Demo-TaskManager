using TaskManager.BLL.Entities;
using TaskManager.BLL.Mapper;
using TaskManager.Common.Repositories;

namespace TaskManager.BLL.Services
{
    public class UserService : IUserRepository<User>
    {
        private readonly IUserRepository<DAL.Entities.User> _dalService;

        public UserService(IUserRepository<DAL.Entities.User> userRepository)
        {
            _dalService = userRepository;
        }
        public async IAsyncEnumerable<User> Get()
        {
            await foreach(DAL.Entities.User user in _dalService.Get())
            {
                yield return user.ToBLL();
            }
        }

        public User Get(Guid userId) 
        { 
            return _dalService.Get(userId).ToBLL();
        }

        public Guid Insert(User entity)
        {
            return _dalService.Insert(entity.ToDAL());
        }

        public bool Delete(Guid userId) 
        {
            return _dalService.Delete(userId);
        }

        public User CheckPassword(string email, string password)
        {
            return _dalService.CheckPassword(email, password).ToBLL();
        }

        public User GetCreator(Guid taskId)
        {
            return _dalService.GetCreator(taskId).ToBLL();
        }
    }
}
