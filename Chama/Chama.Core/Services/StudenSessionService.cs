using Chama.Core.Entities;
using Chama.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chama.Core.Services
{
    public class StudentSessionService : IStudentSessionService
    {
        private readonly IAsyncRepository<StudentSession> _stusRepository;
        private readonly IAsyncRepository<Session> _sessionRepository;


        public StudentSessionService(IAsyncRepository<StudentSession> stusrepository, IAsyncRepository<Session> sessionRepository)
        {
            _stusRepository = stusrepository;
            _sessionRepository = sessionRepository;
        }

        public async Task<bool> CheckIfAlreadySignedIn(int studentId, int courseId)
        {
            var session = await _sessionRepository.FirstOrDefaultAsync(x => x.CourseId == courseId);
            return await _stusRepository.FirstOrDefaultAsync(x => x.StudentId == studentId && x.SessionId == session.Id) != null;
        }
    }
}
