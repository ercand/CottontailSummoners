using CottontailApi.Http.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CottontailApi.Commons;
using System.Net.Http;

namespace CottontailApi.Http
{
    public class RiotApiRequester : RequesterBase, IRiotApiRequester
    {
        public RiotApiRequester() : base()
        { }

        public string GetRequestApiCall(string relativeUrl, Enums.Platform platform)
        {
            string url = BuildRequestString(relativeUrl, platform);
            var reqMsg = new HttpRequestMessage(HttpMethod.Get, url);
            var response = GetRequest(reqMsg);

            return GetResponseContent(response);
        }

        public async Task<string> GetRequestApiCallAsync(string relativeUrl, Enums.Platform platform)
        {
            string url = BuildRequestString(relativeUrl, platform);
            var reqMsg = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await GetRequestAsync(reqMsg);

            return await GetResponseContentAsync(response);
        }
    }
}
