using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.BLL.Entities
{
    public class User
    {
        public Guid UserId { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public UserRole Role { get; private set; }
        public DateTime CreationDate { get; private set; }
        private DateTime? _disableDate;
        public bool IsActive { get { return _disableDate is null; } }
        public DateTime? DisableDate { get { return _disableDate; } }

        public User(Guid userId, string email, string password, string userRole, DateTime creationDate, DateTime? disableDate) {
            UserId = userId;
            Email = email;
            Password = password;
            Role = Enum.Parse<UserRole>(userRole);
            CreationDate = creationDate;
            _disableDate = disableDate;
        }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public User(Guid userId)
        {
            UserId = userId;
        }

        public UserRole ChangeRole()
        {
            Role = (Role == UserRole.User) ? UserRole.Admin : UserRole.User;
            return Role;
        }

        /*public DAL.Entities.User ToDAL()
        {

        }*/
    }
}
