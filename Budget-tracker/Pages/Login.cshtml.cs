using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class LoginModel : PageModel
{
    private readonly IDbContext _context;

    public LoginModel(IDbContext context)
    {
        _context = context;
    }

    public string Message { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(string username, string password)
    {
        
        var user = await _context.UserLogin.FirstOrDefaultAsync(m => m.Username == username);

        if (user == null || user.Password != password) // Consider using more secure password comparison
        {
            Message = "Invalid login attempt";
            return Page();
        }

        // Implement your session or authentication mechanism here

        return RedirectToPage("Index"); // Redirect to the main page after successful login
    }
}