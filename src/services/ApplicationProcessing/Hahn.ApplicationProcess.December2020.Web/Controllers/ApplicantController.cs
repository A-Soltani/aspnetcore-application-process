using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Application.Commands.AddApplicant;
using Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate;
using MediatR;

namespace Hahn.ApplicationProcess.December2020.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicantController(IMediator mediator) =>
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddApplicant([FromBody] AddApplicantCommand addApplicantCommand)
        {
            var applicantId = await _mediator.Send(addApplicantCommand);
            return CreatedAtRoute(nameof(GetApplicant), new { id = applicantId }, new {applicantId = applicantId });
        }

        [HttpGet("{id:int}", Name = nameof(GetApplicant))]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Applicant))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Applicant>> GetApplicant(int id)
        {
            //if (!_repository.TryGetProduct(id, out var product))
            //{
            //    return NotFound();
            //}

            return Ok();
        }


    }
    
}
