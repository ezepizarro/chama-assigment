using System;
using System.Collections.Generic;
using System.Text;

namespace Chama.Core.Entities
{
    public class Teacher : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}