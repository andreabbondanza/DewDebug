using DewLogger.Interfaces;
using System;

namespace DewCore.DewLogger
{
    /// <summary>
    /// Log into the console
    /// </summary>
    public class DewConsole : IDewLogger
    {
        /// <summary>
        /// Write text
        /// </summary>
        /// <param name="text"></param>
        public void Write(string text)
        {
            Console.Write(text);
        }
        /// <summary>
        /// Write formatted text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="args"></param>
        public void Write(string text, object[] args)
        {
            Console.Write(text, args);
        }
        /// <summary>
        /// Write text and new line
        /// </summary>
        /// <param name="text"></param>
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
        /// <summary>
        /// Write formatted text and new line
        /// </summary>
        /// <param name="text"></param>
        /// <param name="args"></param>
        public void WriteLine(string text, object[] args)
        {
            Console.WriteLine(text, args);
        }
    }
}
