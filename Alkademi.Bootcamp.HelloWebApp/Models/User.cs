namespace Alkademi.Bootcamp.HelloWebApp.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string ProfileImageLink { get; set; }
    public User(int id, string username, string profileImageLink)
    {
        Id = id;
        Username = username;
        ProfileImageLink = profileImageLink;
    }
}
