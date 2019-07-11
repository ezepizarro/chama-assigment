using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chama.Core.Interfaces
{
    public interface IStudentSessionService
    {
        Task<bool> CheckIfAlreadySignedIn(int studentId, int courseId);
    }
}