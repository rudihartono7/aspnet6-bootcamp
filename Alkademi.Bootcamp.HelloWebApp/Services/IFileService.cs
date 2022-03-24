using Alkademi.Bootcamp.HelloWebApp.Models;

namespace Alkademi.Bootcamp.HelloWebApp.Services
{
    public interface IFileService
    {
        Task<List<TweetViewModel>> Read();
        Task Write(TweetViewModel request);
    }
}
