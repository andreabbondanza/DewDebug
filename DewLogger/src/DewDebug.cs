using DewCore;
using DewInterfaces;
using DewInterfaces.DewLogger;
using System;
using System.Diagnostics;

namespace DewCore.DewLogger
{
    /// <summary>
    /// Log into debug output
    /// </summary>
    public class DewDebug : IDewLogger
    {
        /// <summary>
        /// Write text
        /// </summary>
        /// <param name="text"></param>
        public void Write(string text)
        {
            Debug.Write(text);
        }
        /// <summary>
        /// Write formatted text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="args"></param>
        public void Write(string text, object[] args)
        {
            Debug.Write(String.Format(text, args));
        }
        /// <summary>
        /// Write text and new line
        /// </summary>
        /// <param name="text"></param>
        public void WriteLine(string text)
        {
            Debug.WriteLine(text);
        }
        /// <summary>
        /// Write formatted text and new line
        /// </summary>
        /// <param name="text"></param>
        /// <param name="args"></param>
        public void WriteLine(string text, object[] args)
        {
            Debug.Write(String.Format(text, args));
        }
    }
}
