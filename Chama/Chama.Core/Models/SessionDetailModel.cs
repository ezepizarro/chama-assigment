﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Chama.Core.Models
{
    public class SessionDetailModel
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int AvgAge { get; set; }
        public int NumberOfStudents { get; set; }
        public int MaxCapacity { get; set; }
        public TeacherModel Teacher { get; set; }
        public List<StudentSessionModel> StudentSessions { get; set; }
    }
}
