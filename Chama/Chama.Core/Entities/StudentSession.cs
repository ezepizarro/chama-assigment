using System;
using System.Collections.Generic;
using System.Text;

namespace Chama.Core.Entities
{
    public class StudentSession : BaseEntity
    {
        public int SessionId { get; set; }
        public virtual Session Session { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
