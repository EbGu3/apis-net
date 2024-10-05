using MediatR;

namespace CleanArchitecture.Application
                           .Features
                           .Videos
                           .Queries
                           .GetVideoList
{
    public class GetVideoListQuery
        (
            string username
        ) : IRequest<List<VideosVm>>
    {
        public string UserName { get; set; } = username 
                            ?? throw new ArgumentException(nameof(username));

    }
}
