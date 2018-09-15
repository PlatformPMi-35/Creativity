using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Program
{
    /// <summary>
    /// Represents the interaction with a file.
    /// </summary>
    public interface IFileManager
    {
        /// <summary>
        /// Method for load information from file.
        /// </summary>
        /// <param name="reader"> A stream to read information </param>
        void Read(StreamReader reader);

        /// <summary>
        /// Save information in file.
        /// </summary>
        /// <param name="writer"> A stream to write information </param>
        void Write(StreamWriter writer);
    }
}
