using Chama.Core.Entities;
using Chama.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chama.Core.Services
{
    public class SessionService : ISessionService
    {
        private readonly IAsyncRepository<Session> _sessionRepository;

        public SessionService(IAsyncRepository<Session> sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<List<Session>> GetAll()
        {
            return await _sessionRepository.GetAllAsync();
        }

        public async Task<Session> GetById(int id)
        {
            return await _sessionRepository.GetByIdAsync(id);
        }
    }
}
