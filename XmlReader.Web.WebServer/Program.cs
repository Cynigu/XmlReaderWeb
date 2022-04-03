using DBRepository;
using DBRepository.Factories;
using Microsoft.EntityFrameworkCore;
using XmlReader.BLL.Service.Interfaces;
using XmlReader.BLL.Service.Services;
using XmlReader.Data.DBRepository.Factories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Data
builder.Services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IRepositoryContextFactory>(op => new SqlRepositoryContextFactory(connectionString));

//Service
builder.Services.AddScoped<IComputeObjectXmlService, ComputeObjectXmlService>();

//Controllers
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddMvc()
    .AddApplicationPart(typeof(XmlReader.WEB.Controllers.ComputeObjectController).Assembly)
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

app.Run();
