using Chama.Core.Entities;
using Chama.Core.Interfaces;
using Chama.Core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Chama.Core.Tests.Services
{
    public class CoursesServiceTests
    {
        private readonly Mock<IAsyncRepository<Course>> _courseRepository;
        private readonly Mock<IAsyncRepository<Session>> _sessionRepository;
        private readonly Mock<IAsyncRepository<StudentSession>> _ssRepository;
        private readonly Mock<IAsyncRepository<Student>> _studentRepository;

        public CoursesServiceTests()
        {
            _courseRepository = new Mock<IAsyncRepository<Course>>();
            _sessionRepository = new Mock<IAsyncRepository<Session>>();
            _ssRepository = new Mock<IAsyncRepository<StudentSession>>();
            _studentRepository = new Mock<IAsyncRepository<Student>>();

        }

        [Fact]
        public async Task ShouldReturnTrueIfThereIsAvailability()
        {
            //ARRANGE

            const int courseId = 1;
            var session = new Session
            {
                CourseId = 1,
                MaxCapacity = 3,
                NumberOfStudents = 1
            };

            _sessionRepository.Setup(s => s.FirstOrDefaultAsync(It.IsAny<Expression<Func<Session, bool>>>())).Returns(Task.FromResult(session));
            //_studentRepository.Setup(s => s.GetByIdAsync(1)).Returns(Task.FromResult(new Student { Id = 1, Age = 32, FirstName = "Carlos" }));

            var sut = new CoursesService(_courseRepository.Object,
                _sessionRepository.Object,
                _ssRepository.Object,
                _studentRepository.Object);

            //ACT
            var res = await sut.CheckAvailabilityAsync(courseId);

            //ASSERT
            Assert.True(res);
        }

        [Fact]
        public async Task ShouldReturnFalseIfThereIsNotAvailability()
        {
            //ARRANGE

            const int courseId = 1;
            var session = new Session
            {
                CourseId = 1,
                MaxCapacity = 2,
                NumberOfStudents = 1
            };

            _sessionRepository.Setup(s => s.FirstOrDefaultAsync(It.IsAny<Expression<Func<Session, bool>>>())).Returns(Task.FromResult(session));

            var sut = new CoursesService(_courseRepository.Object,
                _sessionRepository.Object,
                _ssRepository.Object,
                _studentRepository.Object);

            //ACT
            var res = await sut.CheckAvailabilityAsync(courseId);

            //ASSERT
            Assert.False(res);
        }

    }
}