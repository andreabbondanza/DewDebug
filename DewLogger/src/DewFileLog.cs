using DewCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DewLogger
{
    /// <summary>
    /// Log into a file
    /// </summary>
    public class DewFileLog : IDewLogger
    {
        /// <summary>
        /// Log file path
        /// </summary>
        public readonly string Path;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path"></param>
        public DewFileLog(string path)
        {
            this.Path = path;
        }
        /// <summary>
        /// Write text
        /// </summary>
        /// <param name="text"></param>
        public void Write(string text)
        {
            System.IO.File.AppendAllText(this.Path, text);
        }
        /// <summary>
        /// Write formatted text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="args"></param>
        public void Write(string text, object[] args)
        {
            System.IO.File.AppendAllText(this.Path, String.Format(text, args));
        }
        /// <summary>
        /// Write text and new line
        /// </summary>
        /// <param name="text"></param>
        public void WriteLine(string text)
        {
            System.IO.File.AppendAllLines(this.Path, new List<string>() { text });
        }
        /// <summary>
        /// Write formatted text and new line
        /// </summary>
        /// <param name="text"></param>
        /// <param name="args"></param>
        public void WriteLine(string text, object[] args)
        {
            System.IO.File.AppendAllLines(this.Path, new List<string>() { String.Format(text, args) });
        }
    }
}
