using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B = TaskManager.BLL.Entities;
using D = TaskManager.DAL.Entities;

namespace TaskManager.BLL.Mapper
{
    internal static class Mapper
    {
        #region User
        public static D.User ToDAL(this B.User entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new D.User()
            {
                UserId = entity.UserId,
                Email = entity.Email,
                Password = entity.Password,
                Role = entity.Role.ToString(),
                CreationDate = entity.CreationDate,
                DisableDate = entity.DisableDate
            };
        }
        public static B.User ToBLL(this D.User entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new B.User(
                entity.UserId,
                entity.Email,
                entity.Password,
                entity.Role,
                entity.CreationDate,
                entity.DisableDate
                );
        }
        #endregion
        #region ManagedTask
        public static D.ManagedTask ToDAL(this B.ManagedTask entity) {
            if(entity is null) throw new ArgumentNullException( nameof(entity));
            return new D.ManagedTask()
            {
                TaskId = entity.TaskId,
                Title = entity.Title,
                Description = entity.Description,
                CreationDate = entity.CreationDate,
                CreatorId = entity.Creator?.UserId ?? Guid.Empty,
                DeadLine = entity.DeadLine
            };
        }
        public static B.ManagedTask ToBLL(this D.ManagedTask entity) {

            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new B.ManagedTask(entity.TaskId,entity.Title,entity.Description,entity.DeadLine,entity.CreationDate,entity.CreatorId);
        }
        public static B.ManagedTask ToBLL(this D.ManagedTask entity, B.User creator)
        {

            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new B.ManagedTask(entity.TaskId, entity.Title, entity.Description, entity.DeadLine, entity.CreationDate,creator);
        }
        #endregion
    }
}
