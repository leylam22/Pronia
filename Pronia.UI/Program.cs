using Microsoft.EntityFrameworkCore;
using Pronia.DataAccess.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
//builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name:"Default",
    pattern:"{controller=Home}/{action=Index}/{Id?}"
);

app.Run();
