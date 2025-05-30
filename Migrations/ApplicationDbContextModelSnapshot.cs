﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoTracker.Data;

#nullable disable

namespace TodoTracker.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskModelTaskCategory", b =>
                {
                    b.Property<int>("TasksId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.HasKey("TasksId", "CategoriesId");

                    b.HasIndex("CategoriesId");

                    b.ToTable("TaskModelTaskCategory");

                    b.HasData(
                        new
                        {
                            TasksId = 1,
                            CategoriesId = 1
                        },
                        new
                        {
                            TasksId = 1,
                            CategoriesId = 3
                        },
                        new
                        {
                            TasksId = 2,
                            CategoriesId = 2
                        },
                        new
                        {
                            TasksId = 3,
                            CategoriesId = 4
                        },
                        new
                        {
                            TasksId = 4,
                            CategoriesId = 5
                        },
                        new
                        {
                            TasksId = 5,
                            CategoriesId = 1
                        },
                        new
                        {
                            TasksId = 5,
                            CategoriesId = 3
                        });
                });

            modelBuilder.Entity("TodoTracker.Models.TaskCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Work"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Personal"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Urgent"
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Health"
                        },
                        new
                        {
                            Id = 5,
                            CategoryName = "Learning"
                        });
                });

            modelBuilder.Entity("TodoTracker.Models.TaskModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TaskAssignDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaskDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsCompleted = false,
                            TaskAssignDate = new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TaskDescription = "Complete the annual financial report",
                            TaskTitle = "Finish report"
                        },
                        new
                        {
                            Id = 2,
                            IsCompleted = false,
                            TaskAssignDate = new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TaskDescription = "Milk, eggs, bread",
                            TaskTitle = "Buy groceries"
                        },
                        new
                        {
                            Id = 3,
                            IsCompleted = false,
                            TaskAssignDate = new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TaskDescription = "Routine check-up",
                            TaskTitle = "Doctor appointment"
                        },
                        new
                        {
                            Id = 4,
                            IsCompleted = false,
                            TaskAssignDate = new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TaskDescription = "Go through the Microsoft EF Core documentation",
                            TaskTitle = "Study EF Core"
                        },
                        new
                        {
                            Id = 5,
                            IsCompleted = false,
                            TaskAssignDate = new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TaskDescription = "Resolve issues in the API endpoints",
                            TaskTitle = "Fix bugs in project"
                        });
                });

            modelBuilder.Entity("TaskModelTaskCategory", b =>
                {
                    b.HasOne("TodoTracker.Models.TaskCategory", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TodoTracker.Models.TaskModel", null)
                        .WithMany()
                        .HasForeignKey("TasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
