﻿using Chama.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chama.Core.Interfaces
{
    public interface ICoursesService
    {
        Task<List<Course>> GetAll();
        bool CheckAvailability(int courseId);
        Task<StudentSession> AddStudentSession(int courseId, int studentId);
    }
}