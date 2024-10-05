using MediatR;
using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideoList
{
    public class GetVideoListQueryHandler 
        (
            IVideoRepository videoRepository,
            IMapper mapper
        ) 
        : IRequestHandler<GetVideoListQuery, List<VideosVm>>
    {
        private readonly IVideoRepository _videoRepository = videoRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<VideosVm>> Handle(GetVideoListQuery request, CancellationToken cancellationToken)
        {
            var videoList = await _videoRepository.GetVideoByName(request.UserName);

            return _mapper.Map<List<VideosVm>>(videoList);
        }
    }
}
