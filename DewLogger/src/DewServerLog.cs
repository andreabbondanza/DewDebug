using DewCore.RestClient;
using DewInterfaces.DewRestClient;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DewCore.DewLogger
{
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
