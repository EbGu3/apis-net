using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommand : IRequest<int>
    {
        public required int Id          { get; set; }
        public required string Name     { get; set; }
        public string Url               { get; set; } = string.Empty; 
    }
}
