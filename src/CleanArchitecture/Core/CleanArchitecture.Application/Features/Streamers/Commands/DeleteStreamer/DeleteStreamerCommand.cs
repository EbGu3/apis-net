using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
