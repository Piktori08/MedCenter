using Microsoft.EntityFrameworkCore;
using Med_Center.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MedCenterContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("MedCenterContext") ??
    throw new InvalidOperationException("Connection string not found")));


builder.Services.AddAuthorization();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

  app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
