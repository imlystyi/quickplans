#region Usings

using System.Text;

#endregion

namespace QuickPlans.Services
{
    /// <summary>
    /// Represents the asynchronous writing in file and reading from it.
    /// </summary>
    internal static class AsyncIO
    {
        #region Methods

        /// <summary>
        /// Asynchronously writes the given text to a file with the given path. 
        /// </summary>
        /// <param name="path">The file path.</param>
        /// <param name="text">The text to write.</param>
        /// <returns>The <see cref="Task"/> that must be called for writing.</returns>
        public static async Task Write(string path, string text)
        {
            // Encoding the text to write it using a FileStream.
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            using FileStream fs = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true);

            await fs.WriteAsync(encodedText);
        }

        /// <summary>
        /// Asynchronously reads the text from a file with the given path.
        /// </summary>
        /// <param name="path">The file path.</param>
        /// <returns>The <see cref="string"/> text from the file.</returns>
        public static async Task<string> Read(string path)
        {
            using FileStream fs = new(path, FileMode.Open, FileAccess.Read, FileShare.None, 4096, true);
            StringBuilder sb = new();

            byte[] buffer = new byte[0x1000];
            int numRead;

            // Reading from a file until it reaches the end.
            while ((numRead = await fs.ReadAsync(buffer)) != 0)
            {
                string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                sb.Append(text);
            }

            return sb.ToString();
        }

        #endregion
    }
}
