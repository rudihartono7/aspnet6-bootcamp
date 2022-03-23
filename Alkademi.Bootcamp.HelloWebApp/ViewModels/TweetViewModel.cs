using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Alkademi.Bootcamp.HelloWebApp.Models;

public class TweetViewModel
{
    [DisplayName("Nomor ")]
    [Required]
    public int Id { get; set; }
    [MaxLength(5)]
    public string Title { get; set; }
    public string Desc { get; set; }
    public int TotalRetweet { get; set; }
    public string LinkImage { get; set; }
    public User User { get; set; }
    private int TotalLike { get; set; }
    public TweetViewModel()
    {

    }
    public TweetViewModel(int id, string title, string desc)
    {
        if(id == 0){
            Id = new Random().Next();
        } else {
            Id = id;
        }

        Title = title;
        Desc = desc;
    }

    public void PostBy(User user){
        User = user;
    }
}
