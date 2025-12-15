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
        #endregion
    }
}
