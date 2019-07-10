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
    public class SessionsController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly ISessionService _sessionService;

        public SessionsController(IMapper mapper, ILoggerManager logger, ISessionService sessionService)
        {
            _logger = logger;
            _sessionService = sessionService;
            _mapper = mapper;
        }

        // Part 3: Querying
        [HttpGet]
        public async Task<ActionResult<List<SessionListModel>>> List()
        {
            var sessions = await _sessionService.GetAll();

            return Ok(_mapper.Map<List<SessionListModel>>(sessions));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SessionDetailModel>> Details(int id)
        {
            var session = await _sessionService.GetById(id);

            return Ok(_mapper.Map<SessionDetailModel>(session));
        }
    }
}