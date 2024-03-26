using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register the DbContext with the ASP.NET Core DI container.
// Replace "YourConnectionString" with your actual connection string.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("BudgetTrackerDatabase"), 
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("BudgetTrackerDatabase"))));

// Optionally, if using IDbContext interface
builder.Services.AddScoped<IDbContext>(provider => provider.GetService<ApplicationDbContext>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
