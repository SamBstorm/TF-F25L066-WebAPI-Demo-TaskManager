using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.EF.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public Guid Salt { get; set; }
        public string Role { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DisableDate { get; set; }
    }
}
