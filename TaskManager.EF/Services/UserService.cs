using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Common.Repositories;
using TaskManager.DAL.Entities;
using TaskManager.EF.Mapper;

namespace TaskManager.EF.Services
{
    public class UserService : IUserRepository<DAL.Entities.User>
    {
        private readonly TaskManagerDbContext _dbcontext;

        public UserService(TaskManagerDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public User CheckPassword(string email, string password)
        {
            return _dbcontext.Users.Single(u => u.Email == email && SaltAndHash(password, u.Salt) == u.Password).ToDAL();
        }

        public bool Delete(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async IAsyncEnumerable<User> Get()
        {
            foreach(EF.Models.User u in _dbcontext.Users)
            {
                yield return u.ToDAL();
            }
        }

        public User Get(Guid userId)
        {
            return _dbcontext.Users.Single(u => u.UserId == userId).ToDAL();
        }

        public User GetCreator(Guid taskId)
        {
            throw new NotImplementedException();
        }

        public Guid Insert(User entity)
        {
            Guid salt = Guid.NewGuid();
            EF.Models.User user = new Models.User()
            {
                Email = entity.Email,
                Salt = salt,
                Password = SaltAndHash(entity.Password, salt)
            };
            _dbcontext.Users.Add(user);
            _dbcontext.SaveChanges();
            return user.UserId;
        }

        private byte[] SaltAndHash(string password, Guid salt)
        {
            string saltedPassword = string.Concat(password, salt);
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
            }
        }
    }
}
