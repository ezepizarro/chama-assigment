using Chama.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chama.Core.Interfaces
{
    public interface IStudentService
    {
        Task Add(Student student);
    }
}