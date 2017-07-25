using CottontailApi.Commons;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CottontailApi.Exceptions;

namespace CottontailApi.Http
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class RequesterBase
    {
        protected string rootDomain;
        private readonly HttpClient httpClient;
        

        protected RequesterBase()
        {
            httpClient = new HttpClient();
        }

        /// <summary>
        /// Send a get request synchronously.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="RiotApiException">Thrown if an Http error occurs. Contains the Http error code and error message.</exception>
        protected HttpResponseMessage GetRequest(HttpRequestMessage request)
        {
            var response = httpClient.GetAsync(request.RequestUri).Result;
            if (!response.IsSuccessStatusCode)
            {
                CheckRequestFailure(response.StatusCode, response.Headers);
            }
            return response;
        }

        /// <summary>
        /// Send a get request asynchronously.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="RiotApiException">Thrown if an Http error occurs. Contains the Http error code and error message.</exception>
        protected async Task<HttpResponseMessage> GetRequestAsync(HttpRequestMessage request)
        {
            var response = await httpClient.GetAsync(request.RequestUri);
            if (!response.IsSuccessStatusCode)
            {
                   CheckRequestFailure(response.StatusCode, response.Headers);
            }
            return response;
        }

        protected string GetResponseContent(HttpResponseMessage response)
        {
            string result;

            using (var content = response.Content)
            {
                result = content.ReadAsStringAsync().Result;
            }
            return result;
        }

        protected async Task<string> GetResponseContentAsync(HttpResponseMessage response)
        {
            Task<string> result = null;
            using (response)
            {
                using (var content = response.Content)
                {
                    result = content.ReadAsStringAsync();
                }
            }
            return await result;
        }

        protected string BuildRequestString(string relativeUrl, Enums.Platform platform)
        {
            string platfromStr = GenericConverter.PlatformIdToString(platform).ToLower();
            string url = string.Format("https://{0}.api.riotgames.com{1}", platfromStr, relativeUrl);

            return url;
        }

        protected void CheckRequestFailure(HttpStatusCode statusCode, HttpResponseHeaders header)
        {
            switch (statusCode)
            {
                case HttpStatusCode.BadRequest:
                    throw new CottontailApi.Exceptions.RiotApiException(Commons.Enums.RiotApiErrorCode.BAD_REQUEST, header);
                case HttpStatusCode.Unauthorized:
                    throw new CottontailApi.Exceptions.RiotApiException(Commons.Enums.RiotApiErrorCode.UNAUTHORIZED, header);
                case HttpStatusCode.Forbidden:
                    throw new CottontailApi.Exceptions.RiotApiException(Commons.Enums.RiotApiErrorCode.FORBIDDEN, header);
                case HttpStatusCode.NotFound:
                    throw new CottontailApi.Exceptions.RiotApiException(Commons.Enums.RiotApiErrorCode.NOT_FOUND, header);
                case HttpStatusCode.UnsupportedMediaType:
                    throw new CottontailApi.Exceptions.RiotApiException(Commons.Enums.RiotApiErrorCode.UNSUPPORTED_MEDIA_TYPE, header);
                case (HttpStatusCode)429:
                    throw new CottontailApi.Exceptions.RiotApiException(Commons.Enums.RiotApiErrorCode.RATE_LIMIT_EXCEEDED, header);
                case HttpStatusCode.InternalServerError:
                    throw new CottontailApi.Exceptions.RiotApiException(Commons.Enums.RiotApiErrorCode.INTERNAL_SERVER_ERROR, header);
                case HttpStatusCode.BadGateway:
                    throw new CottontailApi.Exceptions.RiotApiException(Commons.Enums.RiotApiErrorCode.BAD_GETWAY, header);
                case HttpStatusCode.ServiceUnavailable:
                    throw new CottontailApi.Exceptions.RiotApiException(Commons.Enums.RiotApiErrorCode.SERVICE_UNAVAILABLE, header);
                case HttpStatusCode.GatewayTimeout:
                    throw new CottontailApi.Exceptions.RiotApiException(Commons.Enums.RiotApiErrorCode.GATEWAY_TIMEOUT, header);
                default:
                    throw new CottontailApi.Exceptions.RiotApiException(Commons.Enums.RiotApiErrorCode.UNKNOWN, header);
            }
        }
    }
}
