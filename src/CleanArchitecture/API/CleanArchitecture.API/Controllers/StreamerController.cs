using CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.API.Models;
using System.Net;
using CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer;
using CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StreamerController
        (
            IMediator mediator
        )
        : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("create-new")]
        [ProducesResponseType(typeof(Result<CreatedStreamerVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> CreateNewStreamer([FromBody] CreateStreamerCommand command)
        {
            CreatedStreamerVm createdStreamer = await _mediator.Send(command);
            return Ok(new Result<CreatedStreamerVm>()
                        {
                            Message = "Streamer criado con exito!",
                            Value = createdStreamer
                        }
                     );
        }

        [HttpPost("update-properties")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateProperties([FromBody] UpdateStreamerCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("delete-by/id/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteStreamer(int id)
        {
            DeleteStreamerCommand command = new()
            {
                Id = id
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
