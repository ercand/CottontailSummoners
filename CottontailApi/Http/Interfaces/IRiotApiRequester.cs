using CottontailApi.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottontailApi.Http.Interfaces
{
    public interface IRiotApiRequester
    {
        string GetRequestApiCall(string relativeUrl, Enums.Platform platform);
        Task<string> GetRequestApiCallAsync(string relativeUrl, Enums.Platform platform);
    }
}
