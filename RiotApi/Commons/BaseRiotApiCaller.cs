using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Commons
{
    public abstract class BaseRiotApiCaller
    {
        public BaseRiotApiCaller() { }
        protected WebRequest PrepareWebRequest(string riotCallPath)
        {
            HttpWebRequest request;

            request = (HttpWebRequest)WebRequest.Create(riotCallPath);
            request.Method = "GET";

            return request;
        }
        protected WebResponse GetResponse(WebRequest request)
        {
            return request.GetResponse();
        }
        protected async Task<WebResponse> GetResponseAsync(WebRequest request)
        {
            try
            {
                return await request.GetResponseAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ddd");
                throw;
            }
        }

//        public virtual string MakeApiCall(string requestUrl, Enums.Region region)
//         {
//             throw new NotImplementedException();
//             string result = null;
// 
//             // Creare la request
// 
//             //      Attivare semaphore
// 
//             //          controllare e attendere il rate limit
// 
//             //          eseguire la GetResponse
// 
//             //          Prendere il timer della call
// 
//             //      Stoppare il semaphore
// 
//             // Leggere lo stream dati json
// 
//             WebRequest request = PrepareWebRequest(requestUrl);
//             return result;
//         }
//         public virtual async Task<string> MakeApiCallAsync(string requestUrl, Enums.Region region)
//         {
//             return await Task.FromResult<string>("");
//         }
        public abstract string MakeApiCall(string requestUrl, Enums.Region region);
        public abstract Task<string> MakeApiCallAsync(string requestUrl, Enums.Region region);
    }
}
