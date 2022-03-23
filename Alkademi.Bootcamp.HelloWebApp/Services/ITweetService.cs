using Alkademi.Bootcamp.HelloWebApp.Models;

namespace Alkademi.Bootcamp.HelloWebApp.Services
{
    public interface ITweetService
    {
        List<TweetViewModel> GetTweets();
        int Add(TweetViewModel request);
    }
}
