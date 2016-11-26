namespace Books.App.Core.Database
{
    using Microsoft.EntityFrameworkCore;

    using Models.Database;

    public class LocalDbContext 
        : DbContext
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