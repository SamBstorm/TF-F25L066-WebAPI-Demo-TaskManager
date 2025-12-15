using TaskManager.API.Models;

namespace TaskManager.API.Handlers
{
    public static class Mapper
    {
        #region User
        public static BLL.Entities.User ToBLL(this UserPost entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new BLL.Entities.User(entity.Email, entity.Password);
        }

        public static UserModel ToModel(this BLL.Entities.User entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new UserModel() { 
                UserId = entity.UserId,
                Email = entity.Email,
                Password = entity.Password,
                Role = entity.Role.ToString(),
                CreationDate = entity.CreationDate,
                IsActive = entity.IsActive
            };
        }
        #endregion
    }
}
