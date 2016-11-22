namespace Program
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Serialization;

    class Program
    {        
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode; ;

            var path = @"I:\Books";
            var files = Directory.GetFiles(path, "*.fb2");

            Console.WriteLine("Total files found: " + files.Length);

            //ProcessParallel(files);
            Process(files);

            Console.ReadKey();
        }

        /// <summary>
        /// Processes the specified files.
        /// </summary>
        /// <param name="files">The files.</param>
        private static void Process(string[] files)
        {
            var counter = new Stopwatch();

            Console.WriteLine("Processing files in one thread.");

            counter.Start();

            foreach (var file in files)
            {
                ProcessFile(file);
            }

            counter.Stop();

            Console.WriteLine("Elapsed time to process all books:" + counter.Elapsed.ToString("g"));
            Console.WriteLine("Time per book" + new TimeSpan(counter.ElapsedTicks / files.Length).ToString("g"));
        }

        /// <summary>
        /// Processes the parallel.
        /// </summary>
        /// <param name="files">The files.</param>
        private static void ProcessParallel(string[] files)
        {
            var counter = new Stopwatch();

            Console.WriteLine("Processing files in parallel.");

            counter.Start();

            Parallel.ForEach(
                files,
                ProcessFile);

            counter.Stop();

            Console.WriteLine("Elapsed time to process all books:" + counter.Elapsed.ToString("g"));
            Console.WriteLine("Time per book" + new TimeSpan(counter.ElapsedTicks / files.Length).ToString("g"));
        }

        /// <summary>
        /// Processes the file.
        /// </summary>
        /// <param name="file">The file.</param>
        private static void ProcessFile(string file)
        {
            try
            {
                var book = Deserialize<FictionBook.FictionBook>(file);
                var titleInfo = book.Description.TitleInfo;
                Console.WriteLine(titleInfo.BookTitle);
                Console.WriteLine("\t" + titleInfo.Author[0].Items[0] + " " + titleInfo.Author[0].Items[1]);
                Console.WriteLine("\t" + titleInfo.Date);

                //foreach (var fictionBookBody in book.Body)
                //{
                //    foreach (var sectionType in fictionBookBody.Section)
                //    {
                //        foreach (var baseFormatingStyle in sectionType.Items)
                //        {
                //            if (baseFormatingStyle is PType)
                //            {
                //                var bF = baseFormatingStyle as PType;
                //                Console.WriteLine(bF.Text);

                //                if (bF.Items != null)
                //                {

                //                    foreach (var formatingStyle in bF.Items)
                //                    {
                //                        if (formatingStyle is PType)
                //                        {
                //                            var bFf = formatingStyle as PType;
                //                            Console.WriteLine(bFf.Text);
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during reading: " + file);
            }
            finally
            {
                
            }
        }

        /// <summary>
        /// The deserialize.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public static T Deserialize<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Oops. Selected file not found.");
            }

            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var settings = new XmlReaderSettings
                {
                    CheckCharacters = true,
                    IgnoreComments = true,
                    IgnoreWhitespace = true
                };
                using (var reader = XmlReader.Create(stream, settings))
                {
                    var result = (T)xmlSerializer.Deserialize(reader);
                    return result;
                }
            }
        }
    }
}
