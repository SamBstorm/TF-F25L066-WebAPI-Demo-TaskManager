using System.Data.Common;

namespace TaskManager.DAL.Services
{
    public abstract class BaseService
    {
        protected readonly DbConnection _connection;

        public BaseService (DbConnection connection)
        {
            _connection = connection;
        }

        protected void AddParam(DbCommand command, string paramName, object? paramValue)
        {
            DbParameter param = command.CreateParameter();
            param.ParameterName = paramName;
            param.Value = paramValue ?? DBNull.Value;
            command.Parameters.Add(param);
        }
    }
}
