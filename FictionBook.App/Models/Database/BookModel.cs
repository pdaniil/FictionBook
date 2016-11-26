namespace Books.App.Models.Database
{
    using System;
    using System.IO;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Windows.Storage;

    public class BookModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }

        public string BookPath { get; set; }
        public string CoverPath { get; set; }
        public string FolderPath { get; set; }

        [NotMapped]
        public string CoverImage => Path.Combine(ApplicationData.Current.LocalFolder.Path, CoverPath);

        public DateTime LastOpenedTime { get; set; }
    }
}