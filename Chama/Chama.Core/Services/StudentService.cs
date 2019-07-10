using Chama.Core.Entities;
using Chama.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chama.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IAsyncRepository<Student> _repository;

        public StudentService(IAsyncRepository<Student> repository)
        {
            _repository = repository;
        }

        public async Task<Student> FindById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Add(Student student)
        {
            //Check availability
            await _repository.Add(student);
        }
    }
}
