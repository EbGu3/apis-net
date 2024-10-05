using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Commands
{
    public class StreamerCommand : IRequest<int>
    {
        public required string Name { get; set; }
        public string Url           { get; set; } = string.Empty;
    }
}