using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Alkademi.Bootcamp.HelloWebApp.Models;

namespace Alkademi.Bootcamp.HelloWebApp.Controllers;

public class HomeController : Controller
{
    List<Tweet> _listTweet = new List<Tweet>();
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _listTweet = new List<Tweet>(){
            new Tweet(1, "WhatsApp cofounder: It's time to delete Facebook", "WhatsApp cofounder: It's time to delete Facebook")
            {
                LinkImage = "https://pbs.twimg.com/media/FFQ0STjXEAIfXSh?format=jpg&name=small",
                User = new User(1, "tweet", "https://pbs.twimg.com/profile_images/1289705957/img_400x400.jpg"),
            },
            new Tweet(2, "WhatsApp cofounder: It's time to delete Facebook", "WhatsApp cofounder: It's time to delete Facebook 1")
            {
                LinkImage = "https://pbs.twimg.com/media/FFQ0STjXEAIfXSh?format=jpg&name=small",
                User = new User(1, "tweet", "https://pbs.twimg.com/profile_images/1289705957/img_400x400.jpg"),
            },
            new Tweet(3, "WhatsApp cofounder: It's time to delete Facebook", "WhatsApp cofounder: It's time to delete Facebook 2")
            {
                LinkImage = "https://pbs.twimg.com/media/FFQ0STjXEAIfXSh?format=jpg&name=small",
                User = new User(1, "tweet", "https://pbs.twimg.com/profile_images/1289705957/img_400x400.jpg"),
            },
            new Tweet(4, "XtremMerch", "Ladies and gentlemen, today's MVP: Mbak Rara Istiani the Rain Handler.")
            {
                LinkImage = "https://pbs.twimg.com/media/FOWrR78VUAQ7ibj?format=jpg&name=medium",
                User = new User(2, "XtremMerch", "https://pbs.twimg.com/profile_images/1505084861073162240/yn1xId58_400x400.jpg"),
            },
        };
    }

    public IActionResult Index()
    {

        ViewData["ListTweet"] = _listTweet;
        ViewBag.ListTweet = _listTweet;

        return View(_listTweet);
    }

    /// <summary>
    /// Page detail of tweet
    ///base_url/{Controller}/{method}/{username}
    /// </summary>
    /// <param name="username">id of user</param>
    /// <returns></returns>
    [Route("home/detail/{username}")]
    public IActionResult Detail(string username)
    {
        //get data from list tweet by username
        var datas = _listTweet.Where(x=> x != null && x.User != null && x.User.Username.Contains(username, StringComparison.OrdinalIgnoreCase)).ToList();

       return View(datas); 
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
