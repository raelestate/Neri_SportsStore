using Microsoft.EntityFrameworkCore;
using Neri_SportsStore;
using Neri_SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);

//
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(opts =>
{
	opts.UseSqlServer(
		builder.Configuration["ConnectionStrings:SportsStoreConnection"]);
});


builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

//
app.UseStaticFiles();
app.MapControllerRoute("catpage",
	"{category}/Page{productPage:int}",
	new { Controller = "Home", action = "Index" });

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

//

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

//
app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);


app.Run();
