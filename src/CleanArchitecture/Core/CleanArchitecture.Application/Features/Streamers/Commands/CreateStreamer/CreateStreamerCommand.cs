using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommand : IRequest<int>
    {
        public required string Name { get; set; }
        public string Url { get; set; } = string.Empty;
    }
}