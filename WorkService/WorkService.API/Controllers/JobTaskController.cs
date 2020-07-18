using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkService.Application.Commands.JobCommands;
using WorkService.Application.Commands.JobTask.Models;

namespace WorkService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobTaskController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<CreateJobTaskResult> CreateJobTask([FromBody]CreateJobTaskCommand cmd) 
        {
            return await _mediator.Send(cmd,base.HttpContext.RequestAborted);
        }

    }
}
