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
        private readonly ILoggerManager _logger;
        private readonly ICoursesService _coursesService;
        private readonly IStudentService _studentService;
        private readonly IServiceBusService _serviceBusService;
        private readonly IMapper _mapper;

        public CoursesController(ICoursesService coursesService, IStudentService studentService, IServiceBusService serviceBusService, IMapper mapper, ILoggerManager logger)
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
        public async Task<ActionResult> SignUp([FromBody] CourseSignUpModel model)
        {
            _logger.LogInfo("SignUp called");

            var student = await _studentService.FindById(model.StudentId);
            if (student == null) { return NotFound($"studentId: {model.StudentId}"); };

            //Check Availability
            if (!_coursesService.CheckAvailability(model.CourseId))
            {
                return new JsonResult(new
                {
                    HttpContext.Response.StatusCode,
                    Message = "Course at max capacity"
                });
            }

            var studentSession = await _coursesService.AddStudentSession(model.CourseId, model.StudentId);

            _logger.LogInfo("Student sign up to course created successfully");

            return Ok();
        }

        // Part 2: Scaling out
        // POST: api/Courses/SignUp/MessageBus
        [HttpPost("SignUp/MessageBus")]
        public async Task<ActionResult> SignUpMessageBus([FromBody] CourseSignUpModel model)
        {
            await _serviceBusService.SendMessage(new { model.StudentId, model.CourseId, Message = "QUEUED" });

            return CreatedAtAction(nameof(SignUpMessageBus), "Message Sent");
        }
    }
}