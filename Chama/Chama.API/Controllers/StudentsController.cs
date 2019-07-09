using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chama.Core.Entities;
using Chama.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chama.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IStudentService _studentService;
        public StudentsController(ILoggerManager logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }
    }
}