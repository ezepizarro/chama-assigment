using System;
using System.Collections.Generic;
using System.Text;

namespace Chama.Core.Entities
{
    public class Session : BaseEntity
    {
        public int MaxCapacity { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int AvgAge { get; set; }
        public int NumberOfStudents { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}