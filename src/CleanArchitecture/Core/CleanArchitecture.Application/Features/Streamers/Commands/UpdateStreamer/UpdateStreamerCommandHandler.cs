using MediatR;
using AutoMapper;
using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;

namespace CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandHandler 
        (
            ILogger<UpdateStreamerCommandHandler> logger,
            IStreamerRepository streamerRepository,
            IMapper mapper
        )
        : IRequestHandler<UpdateStreamerCommand, int>
    {
        private readonly IStreamerRepository _streamerRepository = streamerRepository;
        private readonly ILogger<UpdateStreamerCommandHandler> _logger = logger;
        private readonly IMapper _mapper = mapper;

        public async Task<int> Handle(UpdateStreamerCommand request, CancellationToken cancellationToken)
        {
            Streamer? streamerToUpdate = await _streamerRepository
                                                .GetByIdAsync(request.Id);

            if (streamerToUpdate is null)
                NotFoundRecord(request.Id);

            // <Origen>, <Destino>, <ClaseOrigen>, <ClaseDestino>
            _mapper.Map(request, streamerToUpdate, typeof(UpdateStreamerCommand), typeof(Streamer));
            await _streamerRepository.UpdateAsync(streamerToUpdate!);
            _logger.LogInformation("La operacion de actualizacion del Streamer ID = {} fue exitosa", streamerToUpdate!.Id);
            
            return streamerToUpdate.Id;
        }

        private NotFoundException NotFoundRecord (int id)
        {
            _logger.LogError("Streamer, no encontrado. ID = {}", id);
            throw new NotFoundException(nameof(Streamer), id);
        }
    }
}
