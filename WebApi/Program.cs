
using Infrastructure.AutoMapper;
using Infrastructure.Data;
using Infrastructure.Interfaces.IBranchServices;
using Infrastructure.Interfaces.ICarServices;
using Infrastructure.Interfaces.ICustomerServices;
using Infrastructure.Interfaces.IRentalsServices;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Infrastructure.Services.Branchs;
using Infrastructure.Services.Cars;
using Infrastructure.Services.Customers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();  // если у тебя есть расширение

builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity configuration
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;  
})
.AddEntityFrameworkStores<DataContext>()
.AddDefaultTokenProviders();

// Authentication cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "MyCookie";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
        options.SlidingExpiration = true;
    });

builder.Services.AddAuthorization();

// Services
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IRentalService, RentalService>();

// builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();  

builder.Services.AddAutoMapper(typeof(InfrastructureProfile));

// Repositories
builder.Services.AddScoped<IRentalRepositories, RentalRepositories>();
builder.Services.AddScoped<ICarRepositories, CarRepositories>();
builder.Services.AddScoped<ICustomerRepositories, CustomerRepositories>();
builder.Services.AddScoped<IBranchRepositories, BranchRepositories>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "My API"));
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
