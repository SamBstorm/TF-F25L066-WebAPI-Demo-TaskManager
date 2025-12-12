using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DAL.Entities;

namespace TaskManager.DAL.Mapper
{
    internal static class Mapper
    {
        #region User
        public static User ToUser(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new User()
            {
                UserId = (Guid)record["UserId"],
                Email = (string)record["Email"],
                Password = "********",
                Role = (string)record["Role"],
                CreationDate = (DateTime)record["CreationDate"],
                //La prochaine ligne concerne le test de nullité d'une donnée de DB, le null c# et le null du SQL sont différents...
                //Si la donnée est de type DBNull, alors c'est un null c#, sinon c'est une donnée à caster.
                DisableDate = (record["DisableDate"] is DBNull) ? null : (DateTime)record["DisableDate"]
            };
        }
        #endregion
        #region ManagedTask
        public static ManagedTask ToManagedTask(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new ManagedTask()
            {
                TaskId = (Guid)record[nameof(ManagedTask.TaskId)],
                Title = (string)record[nameof(ManagedTask.Title)],
                Description = (record[nameof(ManagedTask.Description)] is DBNull) ? null : (string)record[nameof(ManagedTask.Description)],
                CreationDate = (DateTime)record[nameof(ManagedTask.CreationDate)],
                CreatorId = (Guid)record[nameof(ManagedTask.CreatorId)],
                DeadLine = (record[nameof(ManagedTask.DeadLine)] is DBNull) ? null : (DateTime)record[nameof(ManagedTask.DeadLine)]
            };
        }
        #endregion
    }
}
