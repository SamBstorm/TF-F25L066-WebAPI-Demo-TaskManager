using System.Data;
using System.Data.Common;
using TaskManager.Common.Repositories;
using TaskManager.DAL.Entities;
using TaskManager.DAL.Mapper;

namespace TaskManager.DAL.Services
{
    public class UserService : BaseService, IUserRepository<User>
    {
        public UserService(DbConnection connection) : base(connection) { }

        public async IAsyncEnumerable<User> Get()
        {
            using (DbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_User_Get_All";
                command.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return reader.ToUser();
                    }
                }
            }
        }

        public User Get(Guid userId)
        {
            using (DbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_User_Get";
                command.CommandType = CommandType.StoredProcedure;
                AddParam(command,nameof(userId), userId);
                _connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.ToUser();
                    }
                    throw new ArgumentOutOfRangeException(nameof(userId));
                }
            }
        }

        public Guid Insert(User entity)
        {
            using (DbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_User_Insert";
                command.CommandType = CommandType.StoredProcedure;
                AddParam(command,nameof(entity.Email), entity.Email);
                AddParam(command,nameof(entity.Password), entity.Password);
                _connection.Open();
                return (Guid)command.ExecuteScalar();
            }
        }

        public bool Delete(Guid userId)
        {
            using (DbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_User_Delete";
                command.CommandType = CommandType.StoredProcedure;
                AddParam(command, nameof(userId), userId);
                _connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public User CheckPassword(string email, string password)
        {
            using (DbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_User_CheckPassword";
                command.CommandType = CommandType.StoredProcedure;
                AddParam(command, nameof(email), email);
                AddParam(command, nameof(password), password);
                _connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.ToUser();
                    }
                    throw new InvalidOperationException();
                }
            }
        }

        public User GetCreator(Guid taskId)
        {
            using (DbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_User_Get_Creator_ByTaskId";
                command.CommandType = CommandType.StoredProcedure;
                AddParam(command, nameof(taskId), taskId);
                _connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.ToUser();
                    }
                    throw new ArgumentOutOfRangeException(nameof(taskId));
                }
            }
        }
    }
}
