using DBRepository;
using DBRepository.Factories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using XmlReader.BLL.Service.Interfaces;
using XmlReader.BLL.Service.Services;
using XmlReader.Data.DBRepository.Factories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Авторизация
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = new TimeSpan(3, 1, 0);
});

// Data
//builder.Services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IRepositoryContextFactory>(op => new SqlRepositoryContextFactory(connectionString));

//Service
builder.Services.AddScoped<IComputeObjectXmlService, ComputeObjectXmlService>();
builder.Services.AddScoped<IAccountService>(op => new AccountService(op.GetRequiredService<IRepositoryContextFactory>()));

//Controllers
builder.Services.AddControllers();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddMvc()
    .AddApplicationPart(typeof(XmlReader.WEB.Controllers.ComputeObjectController).Assembly)
    .AddApplicationPart(typeof(XmlReader.WEB.Controllers.AccountController).Assembly)
    .AddControllersAsServices();

var app = builder.Build();

app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "DefaultApi",
        template: "api/{controller}/{action}");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Авторизация
app.UseAuthentication();   // добавление middleware аутентификации 
app.UseAuthorization();   // добавление middleware авторизации 

app.Run();
