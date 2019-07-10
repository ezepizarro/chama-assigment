using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Chama.Core.Entities;
using Chama.Core.Interfaces;
using Chama.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;

namespace Chama.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ILoggerManagerService _logger;
        private readonly IStudentService _studentService;
        private readonly IServiceBusService _serviceBusService;
        private readonly IMapper _mapper;

        public StudentsController(ILoggerManagerService logger, IStudentService studentService, IServiceBusService serviceBusService, IMapper mapper)
        {
            _logger = logger;
            _studentService = studentService;
            _serviceBusService = serviceBusService;
            _mapper = mapper;
        }

        // POST: api/Students
        [HttpPost]
        [ProducesResponseType(typeof(Student), StatusCodes.Status201Created)]
        public async Task<ActionResult<Student>> Post(CreateStudentModel studentModel)
        {
            _logger.LogInfo("Student creation called");

            var student = _mapper.Map<Student>(studentModel);

            await _studentService.Add(student);

            _logger.LogInfo("Student created successfully");

            return CreatedAtAction(nameof(Post), student);
        }
    }
}