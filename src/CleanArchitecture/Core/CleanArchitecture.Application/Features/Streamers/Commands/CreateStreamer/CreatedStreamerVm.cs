namespace CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreatedStreamerVm
    {
        public int Id                   { get; set; }
        public required string Name     { get; set; }
        public string Url               { get; set; } = string.Empty;
    }
}
