using CleanArchitecture.Application.Models.Infraestructure;

namespace CleanArchitecture.Application.Contracts.Infraestructure
{
    public interface IEmailService
    {
        Task<bool> Send(Email email);
    }
}
