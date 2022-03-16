using Microsoft.EntityFrameworkCore;
using Models;
using Models.auth;

namespace DBRepository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<WorkEmployee> WorkEmployees { get; set; }
        public DbSet<AuthUser> AuthUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Employee admin = new Employee()
            {
                Id = 1,
                AuthUserId = 1,
                IsAdmin = true,
                Email = "i.tiulkina@mail.ru",
                Name = "Ирина Т",
                NumberPhone = "79527914962",
                Vk = "null"
            };

            Employee emp = new Employee()
            {
                Id = 2,
                AuthUserId = 2,
                IsAdmin = false,
                Email = "i.tiulkina@mail.ru",
                Name = "Ирина Т",
                NumberPhone = "79527914962",
                Vk = "null"
            };
            modelBuilder.Entity<AuthUser>().HasData(new AuthUser { Id = 1, Login="admin", Password="admin", Role="admin"});
            modelBuilder.Entity<AuthUser>().HasData(new AuthUser { Id = 2, Login = "emp", Password = "emp", Role = "employee" });
            modelBuilder.Entity<Employee>().HasData(admin, emp);
            base.OnModelCreating(modelBuilder);
        }
    }
}