using System;
using System.Collections.Generic;
using System.Text;

namespace Chama.Core.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
