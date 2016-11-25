using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Books.App.Core.Storage;

namespace Books.App.Migrations
{
    [DbContext(typeof(LocalDbContext))]
    [Migration("20161124183048_BookFolderPath")]
    partial class BookFolderPath
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Books.App.Core.Storage.Models.BookModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<string>("BookPath");

                    b.Property<string>("CoverPath");

                    b.Property<string>("FolderPath");

                    b.Property<DateTime>("LastOpenedTime");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });
        }
    }
}
