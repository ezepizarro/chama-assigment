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
        private readonly ILoggerManager _logger;
        private readonly IStudentService _studentService;
        private readonly IServiceBusService _serviceBusService;
        private readonly IMapper _mapper;

        public StudentsController(ILoggerManager logger, IStudentService studentService, IServiceBusService serviceBusService, IMapper mapper)
        {
            _logger = logger;
            _studentService = studentService;
            _serviceBusService = serviceBusService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _serviceBusService.SendMessage(new { StudentId = 1, Message = "QUEUED" });

            return new string[] { "value1", "value2" };
        }

        // POST: api/Students
        [HttpPost]
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