using Microsoft.EntityFrameworkCore;
using SupperCRMExample.DataAccess;
using SupperCRMExample.DataAccess.Context;
using SupperCRMExample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>( options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));//builder üzerinden appsettings.json dosyasýndaki connection stringi alýyoruz
});
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ICleintRepository, ClientRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
