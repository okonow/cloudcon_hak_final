﻿using Contracts.ApplyJobContracts;
using MassTransit;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ServicesSaga.Controllers;
using WorkflowGamificationWebApp.Server.Dtos;

namespace WorkflowGamificationWebApp.Server.Controllers
{
    [ApiController]
    public class JobController(IRequestClient<FinishJobSagaCommand> requestClient) : BaseController
    {
        private readonly IRequestClient<FinishJobSagaCommand> _requestClient = requestClient;

        [HttpPost]
        public async Task<IActionResult> ApplyJobAsync([FromBody] ApplyJobRequest request)
        {
            var (jobFinished, jobNotFinished) = await _requestClient.GetResponse<JobFinishedEvent, JobNotFinishedEvent>(new()
            {
                JobId = request.JobId,
                DirectorId = request.DirectorId
            });

            if (jobFinished.IsCompletedSuccessfully)
            {
                var response = await jobFinished;
                return Ok(response.Message.DirectorId);
            }
            else
            {
                var response = await jobNotFinished;
                return BadRequest(response.Message.Errors);
            }
        }
    }
}
