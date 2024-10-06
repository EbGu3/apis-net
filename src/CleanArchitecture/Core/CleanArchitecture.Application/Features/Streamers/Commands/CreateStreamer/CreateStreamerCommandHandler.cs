using MediatR;
using AutoMapper;
using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models.Infraestructure;
using CleanArchitecture.Application.Contracts.Infraestructure;

namespace CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandHandler
        (
            IStreamerRepository streamerRepository,
            ILogger<CreateStreamerCommandHandler> logger,
            IEmailService emailService,
            IMapper mapper
        )
        : IRequestHandler<CreateStreamerCommand, CreatedStreamerVm>
    {
        private readonly IStreamerRepository _streamerRepository = streamerRepository;
        private readonly ILogger<CreateStreamerCommandHandler> _logger = logger;
        private readonly IEmailService _emailService = emailService;
        private readonly IMapper _mapper = mapper;

        public async Task<CreatedStreamerVm> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            Streamer? streamerEntity = _mapper.Map<Streamer>(request) ?? throw new ApplicationException("Mapper failed to map StreamerCommand to Streamer entity."); ;

            Streamer newStreamer = await _streamerRepository.AddAsync(streamerEntity);
            _logger.LogInformation("Streamer ID = {}, creado exitosamente", newStreamer.Id);

            await SendEmail(newStreamer);

            return _mapper.Map<CreatedStreamerVm>(newStreamer);
        }

        private async Task<bool> SendEmail(Streamer streamer)
        {
            Email email = new()
            {
                Body = $"La compañia {streamer.Name} se ha creado correctamente",
                Subject = "Mensaje de alerta",
                To = "eb@gmail.com"
            };

            try
            {
                return await _emailService.Send(email);
            }
            catch (Exception ex)
            {
                _logger.LogError("Mail no enviado");
                _logger.LogError("MS: {}, ST: {}", ex.Message, ex.StackTrace);

                return false;
            }
        }
    }
}
