using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Chama.Core.Interfaces;
using Chama.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chama.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ILoggerManagerService _logger;
        private readonly ICoursesService _coursesService;
        private readonly IStudentService _studentService;
        private readonly IServiceBusService _serviceBusService;
        private readonly IMapper _mapper;

        public CoursesController(ICoursesService coursesService, IStudentService studentService, IServiceBusService serviceBusService, IMapper mapper, ILoggerManagerService logger)
        {
            _coursesService = coursesService;
            _studentService = studentService;
            _serviceBusService = serviceBusService;
            _logger = logger;
            _mapper = mapper;
        }

        // Part 1: API for signing up
        // POST: api/Courses/SignUp
        [HttpPost("SignUp")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public async Task<ActionResult> SignUp([FromBody] CourseSignUpModel model)
        {
            _logger.LogTrace("Post to SignUp");
            _logger.LogInfo($"SignUp called: {model}");

            //Check if student exists
            var student = await _studentService.FindById(model.StudentId);
            if (student == null) {
                _logger.LogWarn($"Sign Up | Student not found {model.StudentId}");
                return NotFound(new
                {
                    StatusCodes.Status404NotFound,
                    Message = "Student not found " + model.StudentId
                });
            };

            //Check Availability
            if (!_coursesService.CheckAvailabilityAsync(model.CourseId).Result)
            {
                _logger.LogWarn($"Sign Up | Max capacity reached {model.CourseId}");
                return new JsonResult(new
                {
                    StatusCodes.Status200OK,
                    Message = "Course at max capacity"
                });
            }

            //Add student to session
            await _coursesService.AddStudentSessionAsync(model.CourseId, model.StudentId);

            _logger.LogInfo("Student sign up to course created successfully");

            return CreatedAtAction(nameof(SignUp), "Student Signed up");
        }

        // Part 2: Scaling out
        // POST: api/Courses/SignUp/MessageBus
        [HttpPost("SignUp/MessageBus")]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public async Task<ActionResult> SignUpMessageBus([FromBody] CourseSignUpModel model)
        {
            _logger.LogTrace("Post to SignUp/MessageBus");

            var student = await _studentService.FindById(model.StudentId);
            if (student == null)
            {
                _logger.LogWarn($"Sign Up MessageBus | Student not found {model.StudentId}");
                return NotFound(new
                {
                    StatusCodes.Status404NotFound,
                    Message = "Student not found " + model.StudentId
                });
            };

            await _serviceBusService.SendMessage(new { model.StudentId, model.CourseId, student.Email });

            _logger.LogInfo("Student sign up send to message bus successfully");

            return CreatedAtAction(nameof(SignUpMessageBus), "Message Sent");
        }

    }
}