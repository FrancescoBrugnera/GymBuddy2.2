﻿// <auto-generated />
using System;
using GymBuddy.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GymBuddy.Migrations
{
    [DbContext(typeof(GymBuddyContext))]
    [Migration("20190307185558_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GymBuddy.Data.Entities.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<string>("ClassDescription");

                    b.Property<string>("ClassSize");

                    b.Property<string>("Instructor");

                    b.Property<string>("InstructorNationality");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("GymBuddy.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("OrderDate");

                    b.Property<string>("OrderNumber");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new { Id = 1, OrderDate = new DateTime(2019, 3, 7, 18, 55, 58, 141, DateTimeKind.Utc), OrderNumber = "12345" }
                    );
                });

            modelBuilder.Entity("GymBuddy.Data.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LessonId");

                    b.Property<int?>("OrderId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("GymBuddy.Data.Entities.OrderItem", b =>
                {
                    b.HasOne("GymBuddy.Data.Entities.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId");

                    b.HasOne("GymBuddy.Data.Entities.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}