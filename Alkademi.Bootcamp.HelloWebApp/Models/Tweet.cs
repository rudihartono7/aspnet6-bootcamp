namespace Alkademi.Bootcamp.HelloWebApp.Models;

public class Tweet
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int UserID { get; set; }
    public int TotalLike { get; set; }

    public Tweet(int id, string title, string desc)
    {
        if(id == 0){
            Id = new Random().Next();
        } else {
            Id = id;
        }

        Title = title;
    }
}
