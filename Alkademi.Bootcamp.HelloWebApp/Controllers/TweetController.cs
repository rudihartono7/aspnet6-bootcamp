using Alkademi.Bootcamp.HelloWebApp.Models;
using Alkademi.Bootcamp.HelloWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alkademi.Bootcamp.HelloWebApp.Controllers
{
    public class TweetController : Controller
    {
        List<TweetViewModel> _listTweet = new List<TweetViewModel>();
        private readonly ITweetService _tweetService;
        public TweetController(ITweetService tweetService)
        {
            _tweetService = tweetService;
            _listTweet = new List<TweetViewModel>(){
            new TweetViewModel(1, "WhatsApp cofounder: It's time to delete Facebook", "WhatsApp cofounder: It's time to delete Facebook")
            {
                LinkImage = "https://pbs.twimg.com/media/FFQ0STjXEAIfXSh?format=jpg&name=small",
                User = new User(1, "TweetViewModel", "https://pbs.twimg.com/profile_images/1289705957/img_400x400.jpg"),
            },
            new TweetViewModel(2, "WhatsApp cofounder: It's time to delete Facebook", "WhatsApp cofounder: It's time to delete Facebook 1")
            {
                LinkImage = "https://pbs.twimg.com/media/FFQ0STjXEAIfXSh?format=jpg&name=small",
                User = new User(1, "TweetViewModel", "https://pbs.twimg.com/profile_images/1289705957/img_400x400.jpg"),
            },
            new TweetViewModel(3, "WhatsApp cofounder: It's time to delete Facebook", "WhatsApp cofounder: It's time to delete Facebook 2")
            {
                LinkImage = "https://pbs.twimg.com/media/FFQ0STjXEAIfXSh?format=jpg&name=small",
                User = new User(1, "TweetViewModel", "https://pbs.twimg.com/profile_images/1289705957/img_400x400.jpg"),
            },
            new TweetViewModel(4, "XtremMerch", "Ladies and gentlemen, today's MVP: Mbak Rara Istiani the Rain Handler.")
            {
                LinkImage = "https://pbs.twimg.com/media/FOWrR78VUAQ7ibj?format=jpg&name=medium",
                User = new User(2, "XtremMerch", "https://pbs.twimg.com/profile_images/1505084861073162240/yn1xId58_400x400.jpg"),
            },
        };
        }
        // GET: TweetController
        public ActionResult Index()
        {
            return View(_tweetService.GetTweets());
        }

        // GET: TweetController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TweetController/Create
        public ActionResult Create()
        {
            return View(new TweetViewModel(1, "Tweet ", "Tweet desc"));
        }

        // POST: TweetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TweetViewModel collection)
        {
            if(!ModelState.IsValid)
            {
                return View(collection);
            }

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: TweetController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TweetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TweetController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TweetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
