using CottontailApi.Commons;
using CottontailApi.Http.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CottontailApi.Exceptions;

namespace CottontailApi.Http
{
    public class RateLimitedRiotApiRequester : RequesterBase, IRateLimitedRiotApiRequester
    {
        private readonly Dictionary<Enums.Platform, RateLimiter> rateLimiters = new Dictionary<Enums.Platform, RateLimiter>();
        private readonly Dictionary<Enums.Platform, int> rateLimitersUsage = new Dictionary<Enums.Platform, int>();
        private static RateLimitedRiotApiRequester _instance;

        // Lock synchronization object
        private static object syncLock = new object();

        public static RateLimitedRiotApiRequester GetInstance()
        {
            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new RateLimitedRiotApiRequester();
                    }
                }
            }
            return _instance;
        }

        private RateLimitedRiotApiRequester() : base()
        {}

        public string GetRequestApiCall(string relativeUrl, Enums.Platform platform, string method)
        {
            string url = BuildRequestString(relativeUrl, platform);
            var reqMsg = new HttpRequestMessage(HttpMethod.Get, url);

            GetRegionRateLimiter(platform).WaitRateLimit(method);

            HttpResponseMessage response;
            try
            {
                var st = new StackTrace(new StackFrame(1));
                Trace.WriteLine(st.GetFrame(0).GetMethod().Name + ": " + method);
                var d = DateTime.UtcNow;
                LogManager.Logger.GetInstance().Info("Begin Response: " + relativeUrl, LogManager.LogOutput.Console);
                //System.Threading.Thread.Sleep(100000);
                response = GetRequest(reqMsg);
                LogManager.Logger.GetInstance().Info("End Response (" + (DateTime.UtcNow - d).TotalMilliseconds + "ms): "+ relativeUrl, LogManager.LogOutput.Console);

                //
                string appLimit = response.Headers.GetValues("X-App-Rate-Limit").FirstOrDefault();
                string appCount = response.Headers.GetValues("X-App-Rate-Limit-Count").FirstOrDefault();
                string methodLimit = response.Headers.GetValues("X-Method-Rate-Limit").FirstOrDefault();
                string methodCount = response.Headers.GetValues("X-Method-Rate-Limit-Count").FirstOrDefault();

                GetRegionRateLimiter(platform).CreateLimit("X-App-Rate-Limit", parseLimitFromHeader(appLimit), "");
                GetRegionRateLimiter(platform).SaveHeader("X-App-Rate-Limit", parseLimitFromHeader(appCount), "");
                GetRegionRateLimiter(platform).CreateLimit("X-Method-Rate-Limit", parseLimitFromHeader(methodLimit), method);
                GetRegionRateLimiter(platform).SaveHeader("X-Method-Rate-Limit", parseLimitFromHeader(methodCount), method);
            }
            catch (RiotApiException e)
            {
                Trace.WriteLine("GetRequestApiCall() Error:" + e.RiotErrorCode + " Caller: "+ new StackFrame(1).GetMethod().Name);

                if(e.RiotErrorCode== Enums.RiotApiErrorCode.RATE_LIMIT_EXCEEDED)
                    GetRegionRateLimiter(platform).SetRetryAfter(e.Header.RetryAfter.Delta.Value);
                return GetRequestApiCall(relativeUrl, platform, method);
            }
            finally
            {

            }

            var result = GetResponseContent(response);

            return result;
        }

        public async Task<string> GetRequestApiCallAsync(string relativeUrl, Enums.Platform platform, string method)
        {
            string url = BuildRequestString(relativeUrl, platform);
            var reqMsg = new HttpRequestMessage(HttpMethod.Get, url);

            await GetRegionRateLimiter(platform).WaitRateLimitAsync(method);

            var response = await GetRequestAsync(reqMsg);

            return await GetResponseContentAsync(response);
        }

        /// <summary>
        /// Returns the respective region's RateLimiter, creating it if needed.
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        private RateLimiter GetRegionRateLimiter(Enums.Platform platform)
        {
            if (!rateLimiters.ContainsKey(platform)) { 
                rateLimiters[platform] = new RateLimiter();
                rateLimitersUsage[platform] = 0;
            }
            return rateLimiters[platform];
        }

        public float GetRateLimiterUsage(Enums.Platform platform)
        {
            return GetRegionRateLimiter(platform).Load() * 100;
        }

        private Dictionary<int, int> parseLimitFromHeader(string headerValue)
        {
            string[] limits = headerValue.Split(',');
            Dictionary<int, int> timeout = new Dictionary<int, int>();
            foreach (string limitPair in limits)
            {
                string[] limit = limitPair.Split(':');
                int call = Int32.Parse(limit[0]);
                int time = Int32.Parse(limit[1]);
                timeout.Add(time, call);
            }

            return timeout;
        }
    }
}
