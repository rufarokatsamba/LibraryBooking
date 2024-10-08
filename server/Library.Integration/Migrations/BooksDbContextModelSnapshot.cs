﻿// <auto-generated />
using System;
using Library.Integration.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library.Integration.Migrations
{
    [DbContext(typeof(BooksDbContext))]
    partial class BooksDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Library.Integration.Books.Models.SqlBookModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Available")
                        .HasColumnType("int");

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Edition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("57dafdad-9412-49aa-94c0-ab9610949d11"),
                            Author = "Book 1 Author",
                            Available = 1,
                            BookName = "Book 1",
                            Category = 0,
                            Edition = "First Edition",
                            Isbn = "123",
                            Publisher = "Book 1 Publishers"
                        },
                        new
                        {
                            Id = new Guid("b7194eb7-02d7-4e75-bb1d-802417e1c80d"),
                            Author = "Book 2 Author",
                            Available = 1,
                            BookName = "Book 2",
                            Category = 0,
                            Edition = "First Edition",
                            Isbn = "1234",
                            Publisher = "Book 2 Publishers"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
