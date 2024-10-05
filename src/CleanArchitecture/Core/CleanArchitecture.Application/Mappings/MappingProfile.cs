﻿using AutoMapper;
using CleanArchitecture.Domain;
using CleanArchitecture.Application.Features.Videos.Queries.GetVideoList;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Video, VideosVm>();
        }
    }
}
