using AutoMapper;
using CleanArchitecture.Domain;
using CleanArchitecture.Application.Features.Videos.Queries.GetVideoList;
using CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Video, VideosVm>();
            CreateMap<CreateStreamerCommand, Streamer>();
            CreateMap<CreateStreamerCommand, CreatedStreamerVm>();
        }
    }
}
