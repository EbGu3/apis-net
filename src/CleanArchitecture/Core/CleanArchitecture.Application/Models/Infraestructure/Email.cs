namespace CleanArchitecture.Application.Models.Infraestructure
{
    public class Email
    {
        public required string To        { get; set; }
        public required string Subject   { get; set; }
        public required string Body      { get; set; }
    }
}
