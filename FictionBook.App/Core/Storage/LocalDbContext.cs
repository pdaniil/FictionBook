using Books.App.Core.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.App.Core.Storage
{
    public class LocalDbContext : DbContext
    {
        public DbSet<BookModel> Books { get; set; }

        #region Overrides of DbContext

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Books.db");
        }

        #endregion
    }
}