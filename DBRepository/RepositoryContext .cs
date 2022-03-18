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

        public DbSet<UserProfileEntity> UserProfiles { get; set; }
        public DbSet<FolderEntity> Folders { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<AuthUserEntity> AuthUsers { get; set; }
        public DbSet<WorkspaceEntity> Workspaces { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserProfileEntity admin = new UserProfileEntity()
            {
                Id = 1,
                AuthUserId = 1,
                Email = "i.tiulkina@mail.ru",
                Name = "Ирина Т",
                NumberPhone = "79527914962",
                Vk = "null",
            };

            UserProfileEntity emp = new UserProfileEntity()
            {
                Id = 2,
                AuthUserId = 2,
                Email = "i.tiulkina@mail.ru",
                Name = "Ирина Т",
                NumberPhone = "79527914962",
                Vk = "null"
            };
            modelBuilder.Entity<Image>().Property(p => p.ImageByte).HasColumnType("image");
            modelBuilder.Entity<AuthUserEntity>().HasData(new AuthUserEntity { Id = 1, Login="admin", Password="admin", Role = UserRole.Admin});
            modelBuilder.Entity<AuthUserEntity>().HasData(new AuthUserEntity { Id = 2, Login = "user", Password = "user", Role = UserRole.User });
            modelBuilder.Entity<UserProfileEntity>().HasData(admin, emp);

            modelBuilder.Entity<WorkspaceEntity>()
                .HasKey(t => new { t.Id, t.UserProfileId, t.ProjectId });
            base.OnModelCreating(modelBuilder);
        }
    }
}