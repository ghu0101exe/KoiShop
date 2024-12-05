using KoiShopProject.Repositories;
using KoiShopProject.Repositories.Entities;
using KoiShopProject.Repositories.Interface;
using KoiShopProject.Services.Interface;
using KoiShopProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//DI
builder.Services.AddDbContext<KoiShopDbContext>();
//DI Fish Repositories
builder.Services.AddScoped<IFishRepository, FishRepository>();
//DI Fish Services
builder.Services.AddScoped<IFishService, FishService>();
//DI Fish Repositories
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
//DI Fish Services
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
