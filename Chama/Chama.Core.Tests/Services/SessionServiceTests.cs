using Chama.Core.Entities;
using Chama.Core.Interfaces;
using Chama.Core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Chama.Core.Tests.Services
{
    public class SessionServiceTests
    {

        private readonly Mock<IAsyncRepository<Session>> _sessionRepository;

        public SessionServiceTests()
        {
            _sessionRepository = new Mock<IAsyncRepository<Session>>();
        }

        [Fact]
        public void ShouldGetAllSessions()
        {
        }

        [Fact]
        public void ShoulGetOneSession()
        {
        }

    }
}
