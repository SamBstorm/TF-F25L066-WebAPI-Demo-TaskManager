using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DAL.Entities
{
    public class ManagedTask
    {
        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime? DeadLine { get; set; }
    }
}
