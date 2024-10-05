using MediatR;
using AutoMapper;
using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Contracts.Persistence;

namespace CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandler 
        (
            IStreamerRepository streamerRepository,
            ILogger<DeleteStreamerCommandHandler> logger,
            IMapper mapper
        )
        : IRequestHandler<DeleteStreamerCommand, bool>
    {
        private readonly IStreamerRepository _streamerRepository = streamerRepository;
        private readonly ILogger<DeleteStreamerCommandHandler> _logger = logger;
        private readonly IMapper _mapper = mapper;

        public async Task<bool> Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
        {
            Streamer? streamerToDelete = await _streamerRepository.GetByIdAsync(request.Id);
            if (streamerToDelete == null)
                NotFoundRecord(request.Id);

           await _streamerRepository.DeleteAsync(streamerToDelete!);
           _logger.LogInformation("Streamer, eliminado. ID = {}", request.Id);
            return true;
        }

        private NotFoundException NotFoundRecord(int id)
        {
            _logger.LogError("Streamer, no encontrado. ID = {}", id);
            throw new NotFoundException(nameof(Streamer), id);
        }
    }
}
