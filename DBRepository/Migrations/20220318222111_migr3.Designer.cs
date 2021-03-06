// <auto-generated />
using System;
using DBRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace XmlReader.Data.DBRepository.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20220318222111_migr3")]
    partial class migr3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Models.auth.AuthUserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AuthUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "admin",
                            Password = "admin",
                            Role = 0
                        },
                        new
                        {
                            Id = 2,
                            Login = "user",
                            Password = "user",
                            Role = 1
                        });
                });

            modelBuilder.Entity("Models.FolderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountFactFiles")
                        .HasColumnType("int");

                    b.Property<int>("CountFactObject")
                        .HasColumnType("int");

                    b.Property<int>("CountPlanFiles")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("UserProfileId")
                        .HasColumnType("int");

                    b.Property<int>("WorkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FolderId")
                        .HasColumnType("int");

                    b.Property<byte[]>("ImageByte")
                        .IsRequired()
                        .HasColumnType("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Models.ProjectEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Models.UserProfileEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthUserId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vk")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthUserId")
                        .IsUnique();

                    b.ToTable("UserProfiles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthUserId = 1,
                            Email = "i.tiulkina@mail.ru",
                            Name = "Ирина Т",
                            NumberPhone = "79527914962",
                            Vk = "null"
                        },
                        new
                        {
                            Id = 2,
                            AuthUserId = 2,
                            Email = "i.tiulkina@mail.ru",
                            Name = "Ирина Т",
                            NumberPhone = "79527914962",
                            Vk = "null"
                        });
                });

            modelBuilder.Entity("Models.WorkspaceEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("UserProfileId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectRole")
                        .HasColumnType("int");

                    b.HasKey("Id", "UserProfileId", "ProjectId");

                    b.HasIndex("ProjectId")
                        .IsUnique();

                    b.HasIndex("UserProfileId");

                    b.ToTable("Workspaces");
                });

            modelBuilder.Entity("Models.FolderEntity", b =>
                {
                    b.HasOne("Models.ProjectEntity", "Project")
                        .WithMany("Folders")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.UserProfileEntity", "UserProfile")
                        .WithMany("Folders")
                        .HasForeignKey("UserProfileId");

                    b.Navigation("Project");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("Models.Image", b =>
                {
                    b.HasOne("Models.FolderEntity", "Folder")
                        .WithMany("Image")
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Folder");
                });

            modelBuilder.Entity("Models.UserProfileEntity", b =>
                {
                    b.HasOne("Models.auth.AuthUserEntity", "AuthUser")
                        .WithOne("UserProfile")
                        .HasForeignKey("Models.UserProfileEntity", "AuthUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthUser");
                });

            modelBuilder.Entity("Models.WorkspaceEntity", b =>
                {
                    b.HasOne("Models.ProjectEntity", "Project")
                        .WithOne("Workspace")
                        .HasForeignKey("Models.WorkspaceEntity", "ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.UserProfileEntity", "UserProfile")
                        .WithMany("Workspaces")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("Models.auth.AuthUserEntity", b =>
                {
                    b.Navigation("UserProfile")
                        .IsRequired();
                });

            modelBuilder.Entity("Models.FolderEntity", b =>
                {
                    b.Navigation("Image");
                });

            modelBuilder.Entity("Models.ProjectEntity", b =>
                {
                    b.Navigation("Folders");

                    b.Navigation("Workspace")
                        .IsRequired();
                });

            modelBuilder.Entity("Models.UserProfileEntity", b =>
                {
                    b.Navigation("Folders");

                    b.Navigation("Workspaces");
                });
#pragma warning restore 612, 618
        }
    }
}
