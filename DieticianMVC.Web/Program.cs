using DieticianMVC.Application;
using DieticianMVC.Application.ViewModels.Patient;
using DieticianMVC.Infrastructure;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Context>();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();


builder.Services.AddControllersWithViews();
    //.AddFluentValidation();

builder.Services.AddRazorPages();

//builder.Services.AddTransient<IValidator<NewPatientVm>, NewPatientValidation>();

var app = builder.Build();
var loggerFactory = app.Services.GetService<ILoggerFactory>();

// Configure the HTTP request pipeline.

loggerFactory.AddFile("Logs/myLog-{Date}.txt");

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseDatabaseErrorPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
