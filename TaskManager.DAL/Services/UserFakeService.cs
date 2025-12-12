using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Common.Repositories;
using TaskManager.DAL.Entities;

namespace TaskManager.DAL.Services
{
    public class UserFakeService : IUserRepository<User>
    {
        private static List<User> _users = new List<User>();
        public User CheckPassword(string email, string password)
        {
            return _users.FirstOrDefault<User>(u => u.Email == email && u.Password == password) ?? throw new InvalidOperationException();
        }

        public bool Delete(Guid userId)
        {
            return _users.Remove(_users.Find(u => u.UserId == userId));
        }

        public IEnumerable<User> Get()
        {
            return _users;
        }

        public User Get(Guid userId)
        {
            return _users.Find(u => u.UserId == userId) ?? throw new ArgumentOutOfRangeException(nameof(userId));
        }

        public User GetCreator(Guid taskId)
        {
            throw new NotImplementedException();
        }

        public Guid Insert(User entity)
        {
            entity.UserId = Guid.NewGuid();
            _users.Add(entity);
            return entity.UserId;
        }
    }
}
