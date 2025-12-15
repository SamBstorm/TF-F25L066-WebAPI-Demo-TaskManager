using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.EF.Mapper
{
    internal static class Mapper
    {
        #region User
        public static DAL.Entities.User ToDAL(this EF.Models.User entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new DAL.Entities.User()
            {
                UserId = entity.UserId,
                Email = entity.Email,
                Password = "********",
                Role = entity.Role,
                CreationDate = entity.CreationDate,
                DisableDate = entity.DisableDate
            };
        }

        //public static EF.Models.User ToEF(this DAL.Entities.User entity, Func<string, Guid, byte[]> saltAndHashFunction)
        //{
        //    if (entity is null) throw new ArgumentNullException(nameof(entity));
        //    return new EF.Models.User()
        //    {
        //        UserId = entity.UserId,
        //        Email = entity.Email,
        //        Password = ,
        //        Role = entity.Role,
        //        CreationDate = entity.CreationDate,
        //        DisableDate = entity.DisableDate
        //    };
        //}
        #endregion
    }
}
