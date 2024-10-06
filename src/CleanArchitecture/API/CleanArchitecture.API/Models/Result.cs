namespace CleanArchitecture.API.Models
{
    public class Result<T> where T : class
    {
        public T? Value                  { get; set; }
        public required string Message   { get; set; }
    }
}
