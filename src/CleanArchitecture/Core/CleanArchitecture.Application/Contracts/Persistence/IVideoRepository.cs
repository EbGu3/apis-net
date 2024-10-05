using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    /// <summary>
    /// Esta es una interface personalizada
    /// Es decir para cada solicitu de cliente
    /// hacer una interface personalizable
    /// </summary>
    public interface IVideoRepository : IAsyncRepository<Video>
    {
        Task<Video> GetVideosByName (string name);
    }
}
