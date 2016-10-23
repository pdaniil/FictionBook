using System.IO;
using System.Threading.Tasks;


namespace Library.FictionBook
{
    public interface IFictionBookReader
    {
        /// <summary>
        /// Read file from string
        /// </summary>
        /// <param name="xml">Fiction book content as string</param>
        /// <returns></returns>
        Task<FictionBook> ReadAsync(string xml);

        /// <summary>
        /// Read file from stream
        /// </summary>
        /// <param name="stream">Fiction book as stream</param>
        /// <param name="settings">Fiction book load settings</param>
        /// <returns></returns>
        Task<FictionBook> ReadAsync(Stream stream, ReadSettings settings);
    }
}