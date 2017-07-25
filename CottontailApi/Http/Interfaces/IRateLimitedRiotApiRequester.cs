using CottontailApi.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottontailApi.Http.Interfaces
{
    public interface IRateLimitedRiotApiRequester
    {
        string GetRequestApiCall(string relativeUrl, Enums.Platform platform, string method);
        Task<string> GetRequestApiCallAsync(string relativeUrl, Enums.Platform platform, string method);
        float GetRateLimiterUsage(Enums.Platform platform);
    }
}
