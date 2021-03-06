﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DewCore.Abstract.Logger
{
    /// <summary>
    /// Debug interface
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Write in output the string
        /// </summary>
        /// <param name="text"></param>
        void Write(string text);
        /// <summary>
        /// Write in output the string with args
        /// </summary>
        /// <param name="text"></param>
        /// <param name="args"></param>
        void Write(string text, object[] args);
        /// <summary>
        /// Write in output the string with a new line
        /// </summary>
        /// <param name="text"></param>
        void WriteLine(string text);
        /// <summary>
        /// Write in output the string with args and a new line
        /// </summary>
        /// <param name="text"></param>
        /// /// <param name="args"></param>
        void WriteLine(string text, object[] args);
    }
}
