public class UserLogin
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; } // Consider storing hashed passwords instead of plain text
}