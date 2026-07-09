using EmployeeDirectory.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Ambil Connection String dari appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Daftarkan AppDbContext ke sistem Dependency Injection .NET
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Gunakan routing bawaan
app.UseRouting();

app.UseAuthorization();

// AKTIF DI .NET 10: Mengoptimalkan pengiriman aset statis (CSS, JS, Gambar) di wwwroot
app.MapStaticAssets();

app.MapGet("/", async context =>
{
    context.Response.Redirect("/employees");
    await Task.CompletedTask;
});
// 3. Ubah default route tanpa menyertakan .WithStaticAssets() di ujungnya
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employees}/{action=Index}/{id?}");

app.Run();
