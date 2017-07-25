using System;
using System.Net.Http.Headers;
using System.Runtime.Serialization;

namespace CottontailApi.Exceptions
{
    /// <summary>
    /// Classe che contiene le eccezzioni generate dalle chiamate alle API Riot
    /// https://developer.riotgames.com/docs/response-codes
    /// </summary>
    public class RiotApiException : Exception
    {
        public CottontailApi.Commons.Enums.RiotApiErrorCode RiotErrorCode { get; set; }
        public HttpResponseHeaders Header { get; set; }

        public RiotApiException(CottontailApi.Commons.Enums.RiotApiErrorCode errorCode, HttpResponseHeaders header)
            : base() { this.RiotErrorCode = errorCode; this.Header = header; }

        public RiotApiException(string message, CottontailApi.Commons.Enums.RiotApiErrorCode errorCode, HttpResponseHeaders header)
            : base(message) { this.RiotErrorCode = errorCode; this.Header = header; }

        public RiotApiException(string message, Exception inner, CottontailApi.Commons.Enums.RiotApiErrorCode errorCode, HttpResponseHeaders header)
            : base(message, inner) { this.RiotErrorCode = errorCode; this.Header = header; }

        protected RiotApiException(SerializationInfo info, StreamingContext context, CottontailApi.Commons.Enums.RiotApiErrorCode errorCode, HttpResponseHeaders header)
            : base(info, context) { this.RiotErrorCode = errorCode; this.Header = header; }
    }
}
