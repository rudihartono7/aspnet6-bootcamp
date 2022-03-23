using Alkademi.Bootcamp.HelloWebApp.Models;

namespace Alkademi.Bootcamp.HelloWebApp.Services
{
    public class TweetService : ITweetService
    {
        List<Tweet> _tweets;
        public TweetService()
        {
            _tweets = new List<Tweet>
            {
                new Tweet(1, "Title", "Bootcamp alkademi"),
                new Tweet(2, "Title 1", "Bootcamp alkademi"),
                new Tweet(3, "Title 2", "Bootcamp alkademi"),
                new Tweet(4, "Title 2", "Bootcamp alkademi"),
                new Tweet(4, "Title 2", "Bootcamp alkademi"),
                new Tweet(4, "Title 2", "Bootcamp alkademi"),
                new Tweet(4, "Title 2", "Bootcamp alkademi"),
                new Tweet(4, "Title 2", "Bootcamp alkademi"),
                new Tweet(4, "Title 2", "Bootcamp alkademi"),
                new Tweet(4, "Title 2", "Bootcamp alkademi"),
                new Tweet(4, "Title 2", "Bootcamp alkademi"),
                new Tweet(4, "Title 2", "Bootcamp alkademi"),
                new Tweet(4, "Title 2", "Bootcamp alkademi"),
                new Tweet(4, "Title 2", "Bootcamp alkademi"),
                new Tweet(4, "Title 2", "Bootcamp alkademi"),
                new Tweet(4, "Title 2", "Bootcamp alkademi"),
                new Tweet(4, "Title 2", "Bootcamp alkademi"),
                new Tweet(4, "Title 2", "Bootcamp alkademi"),
                new Tweet(4, "Title 2", "Bootcamp alkademi"),
                new Tweet(4, "Title 2", "Bootcamp alkademi"),
                new Tweet(4, "Title 2", "Bootcamp alkademi"),
            };
        }
        public int Add(TweetViewModel request)
        {
            throw new NotImplementedException();
        }

        public List<TweetViewModel> GetTweets()
        {
            List<TweetViewModel> tweetViewModels = new List<TweetViewModel>();

            foreach (var item in _tweets)
            {
                tweetViewModels.Add(new TweetViewModel(item.Id, item.Title, item.Title));
            }

            return tweetViewModels;
        }
    }
}
