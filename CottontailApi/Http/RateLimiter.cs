using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CottontailApi.Http
{
    public class RateLimiter
    {
        private List<RateLimit> limits;
        private Dictionary<RateLimit, DateTime> firstCallTimer;
        private Dictionary<RateLimit, int> requestCount;
        public float UsageRateLimiter { get; set; }
        private DateTime UsageTimer { get; set; }

        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1);

        /// <summary>Stores the retryAfter time if a request returns 429.</summary>
        private DateTime retryAfter = DateTime.MinValue;

        public RateLimiter()
        {
            this.limits = new List<RateLimit>();
            this.firstCallTimer = new Dictionary<RateLimit, DateTime>();
            this.requestCount = new Dictionary<RateLimit, int>();

            this.UsageRateLimiter = 0;
            this.UsageTimer = DateTime.UtcNow;
        }

        /// <summary>
        /// Create limit for each specific endpoint
        /// </summary>
        /// <param name="type">Limit type (App, Method)</param>
        /// <param name="limit">Limit value</param>
        /// <param name="method">Endpoint name</param>
        public void CreateLimit(string type, Dictionary<int, int> limit, string method)
        {
            foreach (var tempLimit in limit)
            {
                if (this.limits.Any(l => l.TypeName == type && l.MethodName == method && TimeSpan.FromSeconds(tempLimit.Key) == l.Interval && tempLimit.Value == l.MaxRequest) == false)
                {
                    var rl = new RateLimit(tempLimit.Value, TimeSpan.FromSeconds(tempLimit.Key), type, method);
                    this.limits.Add(rl);
                    this.firstCallTimer.Add(rl, DateTime.UtcNow);
                    this.requestCount.Add(rl, 0);
                    LogManager.Logger.GetInstance().Info($"Region limiter created: {rl.TypeName}-{rl.MethodName}({rl.MaxRequest}:{rl.Interval.TotalSeconds}) second", LogManager.LogOutput.Console);
                }
            }
        }

        /// <summary>
        /// Save limit for each specific endpoint
        /// </summary>
        /// <param name="type">Limit type (App, Method)</param>
        /// <param name="limit">Limit value</param>
        /// <param name="method">Endpoint name</param>
        public void SaveHeader(string type, Dictionary<int, int> limit, string method)
        {
            foreach (var newLimit in limit)
            {
                var limitToUpdate = limits.Where(l => l.TypeName == type && l.MethodName == method && TimeSpan.FromSeconds(newLimit.Key) == l.Interval).Single();
                if (limitToUpdate != null)
                {
                    var oldCount = requestCount[limitToUpdate];
                    var newCount = newLimit.Value;

                    if (oldCount + 1 < newCount)
                    {
                        requestCount[limitToUpdate] = newCount;
                        LogManager.Logger.GetInstance().Info("limit " + limitToUpdate.MethodName + " has changed from " + oldCount + " to " + newCount, LogManager.LogOutput.Console);
                    }
                }
            }
        }

        /// <summary>
        /// Blocks until a request can be made.
        /// </summary>
        public void WaitRateLimit(string method)
        {
            semaphore.Wait();
            try
            {
                Task.Delay(CheckLimit(method)).Wait();
                UpdateLimit(method);
            }
            finally
            {
                semaphore.Release();
            }
        }

        /// <summary>
        /// Creates a task that blocks until a request can be made. 
        /// </summary>
        /// <returns></returns>
        public async Task WaitRateLimitAsync(string method)
        {
            await semaphore.WaitAsync();
            try
            {
                await Task.Delay(CheckLimit(method));
                UpdateLimit(method);
            }
            finally
            {
                semaphore.Release();
            }
        }

        /// <summary>
        /// Sets the retry after delay when a request returns 429.
        /// 
        /// Note that this won't affect a (single) request that has already called HandleRateLimitAsync and is currently waiting.
        /// </summary>
        /// <param name="delay"></param>
        public void SetRetryAfter(TimeSpan delay)
        {
            retryAfter = DateTime.UtcNow + delay;
        }

        private TimeSpan CheckLimit(string method)
        {
            DateTime now = DateTime.UtcNow;
            TimeSpan finalDelay = TimeSpan.Zero;

            foreach (var limit in limits.Where(l => l.MethodName == method || l.TypeName == "X-App-Rate-Limit"))
            {
                if (requestCount[limit] >= limit.MaxRequest)
                {
                    var t = firstCallTimer[limit];
                    var tempDelay = t + limit.Interval - now;
                    if (tempDelay > finalDelay)
                        finalDelay = tempDelay;
                }
            }
            //
            var tempRetryrAfter = retryAfter - now;
            if (tempRetryrAfter > finalDelay)
            {
                finalDelay = tempRetryrAfter;
                LogManager.Logger.GetInstance().Info($"Wait rate limit: wait {finalDelay.TotalSeconds} second", LogManager.LogOutput.Console);
            }

            return finalDelay;
        }

        /// <summary>
        /// Update the rate limit
        /// </summary>
        private void UpdateLimit(string method)
        {
            var now = DateTime.UtcNow;
            foreach (var limit in limits.Where(l => l.MethodName == method || l.TypeName == "X-App-Rate-Limit"))
            {
                if (now - firstCallTimer[limit] > limit.Interval)
                {
                    // Calculate rate limiter usage
                    if (limit.TypeName == "X-App-Rate-Limit" && limit.Interval == TimeSpan.FromSeconds(120))
                    {
                        UsageRateLimiter = (float)requestCount[limit] / (float)limit.MaxRequest;
                        UsageTimer = now;
                    }

                    firstCallTimer[limit] = now;
                    requestCount[limit] = 0;
                }
                requestCount[limit]++;
            }
        }

        public float Load()
        {
            Dictionary<int, float> tempUsage = new Dictionary<int, float>();
            foreach (var tempLimit in limits.Where(rt => rt.TypeName == "X-App-Rate-Limit"))
            {
                float result = 0;

                if (DateTime.UtcNow - firstCallTimer[tempLimit] < tempLimit.Interval)
                    result=(float)requestCount[tempLimit] / (float)tempLimit.MaxRequest;

                tempUsage[(int)tempLimit.Interval.TotalSeconds] = result;
            }

            return tempUsage.ContainsKey(120)?tempUsage[120]:0;

//             var r = limits.Where(rt => rt.TypeName == "X-App-Rate-Limit" && rt.Interval == TimeSpan.FromSeconds(120)).SingleOrDefault();
// 
//             if (r != null && DateTime.UtcNow-firstCallTimer[r]<r.Interval)
//                 return (float)requestCount[r] / (float)r.MaxRequest;
//             else
//                 return 0;
        }
    }

    internal class RateLimit
    {
        public string TypeName { get; set; }
        public string MethodName { get; set; }
        public int MaxRequest { get; set; }
        public TimeSpan Interval { get; set; }

        public RateLimit(int maxRequest, TimeSpan interval, string typeName, string methodName)
        {
            this.MaxRequest = maxRequest;
            this.Interval = interval;
            this.TypeName = typeName;
            this.MethodName = methodName;
        }
        public override bool Equals(object obj)
        {
            var c = (obj as RateLimit);
            return this.TypeName.Equals(c.TypeName) && this.MethodName.Equals(c.MethodName) && this.Interval.TotalSeconds == c.Interval.TotalSeconds && this.MaxRequest == c.MaxRequest;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
