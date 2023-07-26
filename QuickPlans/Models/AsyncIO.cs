/* Copyright 2023 imlystyi
* Licensed under the Apache License, Version 2.0 (the "License"); 
* you may not use this file except in compliance with the License. 
* You may obtain a copy of the License at 
* http://www.apache.org/licenses/LICENSE-2.0
* Unless required by applicable law or agreed to in writing, 
* software distributed under the License is distributed on an "AS IS" 
* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express 
* or implied. See the License for the specific language governing 
* permissions and limitations under the License. */
using System.Text;

namespace QuickPlans.Models;

/// <summary>
/// Provides methods for asynchronous writing to and reading from a file.
/// </summary>
internal static class AsyncIO
{
    /// <summary>
    /// Asynchronously writes the given text to a file with the given path.
    /// </summary>
    /// <param name="path">The file path.</param>
    /// <param name="text">The text to write.</param>
    /// <returns>The <see cref="Task"/> that must be called for writing.</returns>
    public static async Task Write(string path, string text)
    {
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
}
