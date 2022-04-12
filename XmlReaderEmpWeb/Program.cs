using DBRepository.Factories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Formatting.Compact;
using XmlReader.BLL.Service.Interfaces;
using XmlReader.BLL.Service.Services;
using XmlReader.Data.DBRepository.Factories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// логгирование 
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Debug(new RenderedCompactJsonFormatter())
    .WriteTo.File("logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

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

// Services
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

app.UseHttpsRedirection();
app.MapControllers();

// Авторизация
app.UseAuthentication();   // добавление middleware аутентификации 
app.UseAuthorization();   // добавление middleware авторизации 

app.Run();