using Chama.Core.Entities;
using Chama.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chama.Core.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly IAsyncRepository<Course> _courseRepository;
        private readonly IAsyncRepository<Session> _sessionRepository;
        private readonly IAsyncRepository<Student> _studentRepository;

        private readonly IAsyncRepository<StudentSession> _ssRepository;

        public CoursesService(IAsyncRepository<Course> courseRepository, IAsyncRepository<Session> sessionRepository, IAsyncRepository<StudentSession> ssRepository, IAsyncRepository<Student> studentRepository )
        {
            _courseRepository = courseRepository;
            _sessionRepository = sessionRepository;
            _ssRepository = ssRepository;
            _studentRepository = studentRepository;

        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public bool CheckAvailability(int courseId)
        {
            var session = _sessionRepository.GetWhereAsync(x => x.CourseId == courseId).Result.FirstOrDefault();
 
            return session.MaxCapacity - session.NumberOfStudents + 1 > 0;
        }

        public async Task<StudentSession> AddStudentSessionAsync(int courseId, int studentId)
        {
            var session = _sessionRepository.GetWhereAsync(x => x.CourseId == courseId).Result.FirstOrDefault();
            var student = await _studentRepository.GetByIdAsync(studentId);

            var studentSession = new StudentSession
            {
                SessionId = session.Id,
                StudentId = studentId,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            await _ssRepository.AddAsync(studentSession);

            session.NumberOfStudents += 1;
            session.AvgAge = session.StudentSessions.Sum(x => x.Student.Age) / session.NumberOfStudents;

            if(session.MaxAge < student.Age)
            {
                session.MaxAge = student.Age;
            }

            if (session.MinAge == 0 || session.MinAge > student.Age)
            {
                session.MinAge = student.Age;
            }

            await _sessionRepository.UpdateAsync(session);

            return studentSession;
        }
    }
}
