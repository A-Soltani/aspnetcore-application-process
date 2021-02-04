using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Application.Commands.AddApplicant;
using Hahn.ApplicationProcess.December2020.Application.Commands.DeleteApplicant;
using Hahn.ApplicationProcess.December2020.Application.Commands.UpdateApplicant;
using Hahn.ApplicationProcess.December2020.Application.Queries.GetApplicant;
using Hahn.ApplicationProcess.December2020.Application.Queries.GetApplicants;
using Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate;
using Hahn.ApplicationProcess.December2020.Web.DTOs;
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
            return CreatedAtRoute(nameof(GetApplicant), new { id = applicantId }, new { applicantId });
        }

        [HttpGet("{id:int}", Name = nameof(GetApplicant))]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Applicant))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApplicantDto>> GetApplicant(int id)
        {
            var applicant = await _mediator.Send(new GetApplicantQuery() { ApplicantId = id });
            if (applicant == null)
                return NotFound(new { Message = $"Applicant with id {id} not found." });

            var applicantDto = MapApplicantToDto(applicant);

            return Ok(applicantDto);
        }

        [HttpGet("list")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Applicant))]
        public async Task<ActionResult<IEnumerable<ApplicantDto>>> GetApplicants()
        {
            var applicants = await _mediator.Send(new GetApplicantsQuery() );

            var applicantList = applicants.Select(MapApplicantToDto);
            return Ok(applicantList);
        }

        private ApplicantDto MapApplicantToDto(Applicant applicant) =>
            new ApplicantDto()
            {
                Id = applicant.Id,
                CountryOfOrigin = applicant.Address.Country,
                City = applicant.Address.City,
                FullAddress = applicant.Address.FullAddress,
                Name = applicant.Name,
                EmailAddress = applicant.EmailAddress,
                FamilyName = applicant.FamilyName,
                Age = applicant.Age
            };

        [HttpPut("update")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateApplicant([FromBody] UpdateApplicantCommand updateApplicantCommand)
        {
            await _mediator.Send(updateApplicantCommand);

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteApplicant(int id)
        {
            await _mediator.Send(new DeleteApplicantCommand { ApplicantId = id });

            return NoContent();
        }

    }

}
