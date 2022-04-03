using DBRepository;
using Microsoft.EntityFrameworkCore;
using XmlReader.BLL.Interfaces;
using XmlReader.BLL.Services;
using DBRepository.Factories;
using XmlReader.BLL.Service.Interfaces;
using XmlReader.BLL.Service.Services;
using XmlReader.BLL.Services.FolderServices;
using XmlReader.Data.DBRepository.Factories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
// Data
builder.Services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IRepositoryContextFactory>(op => new SqlRepositoryContextFactory(connectionString));

// Services
builder.Services.AddScoped<IComputeObjectXmlService, ComputeObjectXmlService>();

//Controllers
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddMvc()
            .AddApplicationPart(typeof(XmlReader.WEB.Controllers.ComputeObjectController).Assembly)
            .AddControllersAsServices();

var app = builder.Build();

//using (var serviceScope = app.Services.CreateScope())
//{
//    var services = serviceScope.ServiceProvider;
//    var factory = services.GetRequiredService<RepositoryContext>();
//    factory.Database.Migrate();
//}

// Configure the HTTP request pipeline.
app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "DefaultApi",
        template: "api/{controller}/{action}");
});

if (app.Environment.IsDevelopment())
{
    // то выводим информацию об ошибке, при наличии ошибки
    app.UseDeveloperExceptionPage();

}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();

app.MapControllers();

app.Run();