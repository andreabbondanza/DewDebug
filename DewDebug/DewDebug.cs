using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DewCore.RestClient;

namespace DewCore
{
    /// <summary>
    /// Debug interface
    /// </summary>
    public interface IDewLogger
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
        void WriteLine(string text, object[] args);
        /// <summary>
        /// Enable and disalbe debug
        /// </summary>
        /// <param name="text"></param>
    }
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
            System.Diagnostics.Debug.Write(text);
        }
        /// <summary>
        /// Write formatted text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="args"></param>
        public void Write(string text, object[] args)
        {

            System.Diagnostics.Debug.Write(String.Format(text, args));
        }
        /// <summary>
        /// Write text and new line
        /// </summary>
        /// <param name="text"></param>
        public void WriteLine(string text)
        {
            System.Diagnostics.Debug.WriteLine(text);
        }
        /// <summary>
        /// Write formatted text and new line
        /// </summary>
        /// <param name="text"></param>
        /// <param name="args"></param>
        public void WriteLine(string text, object[] args)
        {
            System.Diagnostics.Debug.Write(String.Format(text, args));
        }
    }

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
    /// <summary>
    /// Log to a server
    /// </summary>
    public class DewServerLog
    {
        /// <summary>
        /// Log file path
        /// </summary>
        public readonly string Url;
        private RESTClient client = new RESTClient();
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url"></param>
        public DewServerLog(string url)
        {
            this.Url = url;
        }
        /// <summary>
        /// Send text to server
        /// </summary>
        /// <param name="text"></param>
        public void Write(string text)
        {
            RESTRequest request = new RESTRequest();
            request.SetMethod(Method.POST);
            request.SetUrl(this.Url);
            request.AddQueryArgs("type", "single");
            var stringContent = new StringContent(Regex.Escape(@"{ ""text"":""" + text + @""" }"));
            request.AddContent(stringContent);
            RESTClient client = new RESTClient();
            using (RESTResponse response = (RESTResponse)client.PerformRequest(request).Result)
            {
                if (response.GetHttpStatusCodeType() == HttpStatusType.Error || response.GetHttpStatusCodeType() == HttpStatusType.Fault)
                    throw new InvalidOperationException();
            }
        }
        /// <summary>
        /// Send formatted text to server
        /// </summary>
        /// <param name="text"></param>
        /// <param name="args"></param>
        public void Write(string text, object[] args)
        {
            RESTRequest request = new RESTRequest();
            request.SetMethod(Method.POST);
            request.SetUrl(this.Url);
            request.AddQueryArgs("type", "single");
            var stringContent = new StringContent(Regex.Escape(@"{ ""text"":""" + String.Format(text, args) + @""" }"));
            request.AddContent(stringContent);
            RESTClient client = new RESTClient();
            using (RESTResponse response = (RESTResponse)client.PerformRequest(request).Result)
            {
                if (response.GetHttpStatusCodeType() == HttpStatusType.Error || response.GetHttpStatusCodeType() == HttpStatusType.Fault)
                    throw new InvalidOperationException();
            }
        }
        /// <summary>
        /// Send text to server
        /// </summary>
        /// <param name="text"></param>
        public void WriteLine(string text)
        {
            RESTRequest request = new RESTRequest();
            request.SetMethod(Method.POST);
            request.SetUrl(this.Url);
            request.AddQueryArgs("type", "multiline");
            var stringContent = new StringContent(Regex.Escape(@"{ ""text"":""" + text + @""" }"));
            request.AddContent(stringContent);
            RESTClient client = new RESTClient();
            using (RESTResponse response = (RESTResponse)client.PerformRequest(request).Result)
            {
                if (response.GetHttpStatusCodeType() == HttpStatusType.Error || response.GetHttpStatusCodeType() == HttpStatusType.Fault)
                    throw new InvalidOperationException();
            }
        }
        /// <summary>
        /// Write formatted text and new line
        /// </summary>
        /// <param name="text"></param>
        /// <param name="args"></param>
        public void WriteLine(string text, object[] args)
        {
            RESTRequest request = new RESTRequest();
            request.SetMethod(Method.POST);
            request.SetUrl(this.Url);
            request.AddQueryArgs("type", "multiline");
            var stringContent = new StringContent(Regex.Escape(@"{ ""text"":""" + String.Format(text, args) + @""" }"));
            request.AddContent(stringContent);
            RESTClient client = new RESTClient();
            using (RESTResponse response = (RESTResponse)client.PerformRequest(request).Result)
            {
                if (response.GetHttpStatusCodeType() == HttpStatusType.Error || response.GetHttpStatusCodeType() == HttpStatusType.Fault)
                    throw new InvalidOperationException();
            }
        }
        /// <summary>
        /// Send text to server
        /// </summary>
        /// <param name="text"></param>
        public async Task WriteAsync(string text)
        {
            RESTRequest request = new RESTRequest();
            request.SetMethod(Method.POST);
            request.SetUrl(this.Url);
            request.AddQueryArgs("type", "single");
            var stringContent = new StringContent(Regex.Escape(@"{ ""text"":""" + text + @""" }"));
            request.AddContent(stringContent);
            RESTClient client = new RESTClient();
            using (RESTResponse response = (RESTResponse)await client.PerformRequest(request))
            {
                if (response.GetHttpStatusCodeType() == HttpStatusType.Error || response.GetHttpStatusCodeType() == HttpStatusType.Fault)
                    throw new InvalidOperationException();
            }
        }
        /// <summary>
        /// Send formatted text to server
        /// </summary>
        /// <param name="text"></param>
        /// <param name="args"></param>
        public async Task WriteAsync(string text, object[] args)
        {
            RESTRequest request = new RESTRequest();
            request.SetMethod(Method.POST);
            request.SetUrl(this.Url);
            request.AddQueryArgs("type", "single");
            var stringContent = new StringContent(Regex.Escape(@"{ ""text"":""" + String.Format(text, args) + @""" }"));
            request.AddContent(stringContent);
            RESTClient client = new RESTClient();
            using (RESTResponse response = (RESTResponse)await client.PerformRequest(request))
            {
                if (response.GetHttpStatusCodeType() == HttpStatusType.Error || response.GetHttpStatusCodeType() == HttpStatusType.Fault)
                    throw new InvalidOperationException();
            }
        }
        /// <summary>
        /// Send text to server
        /// </summary>
        /// <param name="text"></param>
        public async Task WriteLineAsync(string text)
        {
            RESTRequest request = new RESTRequest();
            request.SetMethod(Method.POST);
            request.SetUrl(this.Url);
            request.AddQueryArgs("type", "multiline");
            var stringContent = new StringContent(Regex.Escape(@"{ ""text"":""" + text + @""" }"));
            request.AddContent(stringContent);
            RESTClient client = new RESTClient();
            using (RESTResponse response = (RESTResponse)await client.PerformRequest(request))
            {
                if (response.GetHttpStatusCodeType() == HttpStatusType.Error || response.GetHttpStatusCodeType() == HttpStatusType.Fault)
                    throw new InvalidOperationException();
            }
        }
        /// <summary>
        /// Write formatted text and new line
        /// </summary>
        /// <param name="text"></param>
        /// <param name="args"></param>
        public async Task WriteLineAsync(string text, object[] args)
        {
            RESTRequest request = new RESTRequest();
            request.SetMethod(Method.POST);
            request.SetUrl(this.Url);
            request.AddQueryArgs("type", "multiline");
            var stringContent = new StringContent(Regex.Escape(@"{ ""text"":""" + String.Format(text, args) + @""" }"));
            request.AddContent(stringContent);
            RESTClient client = new RESTClient();
            using (RESTResponse response = (RESTResponse)await client.PerformRequest(request))
            {
                if (response.GetHttpStatusCodeType() == HttpStatusType.Error || response.GetHttpStatusCodeType() == HttpStatusType.Fault)
                    throw new InvalidOperationException();
            }
        }
    }
}
