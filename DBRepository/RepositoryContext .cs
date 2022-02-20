using Microsoft.EntityFrameworkCore;
using Models;
using Models.auth;

namespace DBRepository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<WorkEmployee> WorkEmployees { get; set; }
        public DbSet<AuthUser> AuthUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthUser>().HasData(new AuthUser { Id = 1, Login="admin", Password="qwerty123", Role="admin"});
            base.OnModelCreating(modelBuilder);
        }
    }
}