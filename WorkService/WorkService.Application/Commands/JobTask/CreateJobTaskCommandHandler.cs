using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WorkService.Application.Commands.JobCommands;
using WorkService.Application.Commands.JobTask.Models;
using WorkService.Core.Extensions;
using WorkService.Core.ServiceLocation;
using WorkService.Infrastructure.JobModule.Repositories;

namespace WorkService.Application.Commands.JobTask
{
    public class CreateJobTaskCommandHandler : IRequestHandler<CreateJobTaskCommand, CreateJobTaskResult>
    {
        private readonly IJobTaskRepository _jobTaskRepository;

        public CreateJobTaskCommandHandler(IJobTaskRepository jobTaskRepository) 
        {
            _jobTaskRepository = jobTaskRepository;
        }

        public async Task<CreateJobTaskResult> Handle(CreateJobTaskCommand request, CancellationToken cancellationToken)
        {

             var result = await _jobTaskRepository.GetByIdAsync("15232017294195623014529255450166");


            return await Task.FromResult(new CreateJobTaskResult { });

        }
    }
}
