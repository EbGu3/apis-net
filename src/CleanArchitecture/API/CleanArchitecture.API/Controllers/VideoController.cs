using CleanArchitecture.Application.Features.Videos.Queries.GetVideoList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CleanArchitecture.API.Models;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VideoController 
        (
            IMediator mediator
        )
        : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("find-by/user-created/{userName}")]
        [ProducesResponseType(typeof(Result<IEnumerable<VideosVm>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<VideosVm>>> FindVideosByUserCreated (string userName)
        {
            GetVideoListQuery query = new(userName);
            List<VideosVm> videos = await _mediator.Send(query);
            return Ok(new Result<IEnumerable<VideosVm>>()
                        {
                            Message = "Videos encontrados!",
                            Value = videos
                        }
                     );
        }
    }
}
