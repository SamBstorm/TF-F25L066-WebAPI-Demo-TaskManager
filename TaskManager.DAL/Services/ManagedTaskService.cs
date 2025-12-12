using System.Data;
using System.Data.Common;
using TaskManager.Common.Repositories;
using TaskManager.DAL.Entities;
using TaskManager.DAL.Mapper;

namespace TaskManager.DAL.Services
{
    public class ManagedTaskService : BaseService, ITaskRepository<ManagedTask>
    {
        public ManagedTaskService(DbConnection connection) : base(connection) { }

        public bool Delete(Guid taskId)
        {
            using (DbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Task_Delete";
                command.CommandType = CommandType.StoredProcedure;
                AddParam(command, nameof(taskId), taskId);
                _connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public IEnumerable<ManagedTask> Get()
        {
            using (DbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Task_Get_All";
                command.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return reader.ToManagedTask();
                    }
                }
            }
        }

        public ManagedTask Get(Guid taskId)
        {
            using (DbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Task_Get";
                command.CommandType = CommandType.StoredProcedure;
                AddParam(command, nameof(taskId), taskId);
                _connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.ToManagedTask();
                    }
                    throw new ArgumentOutOfRangeException(nameof(taskId));
                }
            }
        }

        public Guid Insert(ManagedTask entity)
        {
            using (DbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Task_Insert";
                command.CommandType = CommandType.StoredProcedure;
                AddParam(command, nameof(entity.Title), entity.Title);
                AddParam(command, nameof(entity.Description), entity.Description ?? (object)DBNull.Value);
                AddParam(command, nameof(entity.CreatorId), entity.CreatorId);
                AddParam(command, nameof(entity.DeadLine), entity.DeadLine ?? (object)DBNull.Value);
                _connection.Open();
                return (Guid)command.ExecuteScalar();
            }
        }

        public bool Update(Guid taskId, ManagedTask entity)
        {
            using (DbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Task_Update";
                command.CommandType = CommandType.StoredProcedure;
                AddParam(command, nameof(taskId), taskId);
                AddParam(command, nameof(entity.Title), entity.Title);
                AddParam(command, nameof(entity.Description), entity.Description ?? (object)DBNull.Value);
                AddParam(command, nameof(entity.DeadLine), entity.DeadLine ?? (object)DBNull.Value);
                _connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
