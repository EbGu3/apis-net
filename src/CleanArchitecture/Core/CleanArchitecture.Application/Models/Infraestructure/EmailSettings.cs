namespace CleanArchitecture.Application.Models.Infraestructure
{
    public class EmailSettings
    {
        public required string ApiKey        { get; set; }
        public required string FromAddress   { get; set; }
        public required string FromName      { get; set; }
    }
}
