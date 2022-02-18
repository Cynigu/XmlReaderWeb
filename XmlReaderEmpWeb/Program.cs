using DBRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

builder.Services.AddDbContextFactory<RepositoryContext>(options =>options.UseSqlServer(connectionString));
//builder.Services.AddScoped<IRepositoryContextFactory, SqlRepositoryContextFactory>();
//builder.Services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionString));
//builder.Services.AddScoped<IEmployeeRepository>(provider => new EmployeeRepository(provider));
//builder.Services.AddScoped<IWorksRepository>(provider => new SqlWorkEmpRepository(connectionString, provider.GetService<IRepositoryContextFactory>()));
//builder.Services.AddScoped<IFoldersRepository>(provider => new SqlFoldersRepository(connectionString, provider.GetService<IRepositoryContextFactory>()));

//builder.Services.AddSwaggerGen();
var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var factory = services.GetRequiredService<RepositoryContext>();
    factory.Database.Migrate();
}

// Configure the HTTP request pipeline.

app.UseStaticFiles();
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
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.Run();
