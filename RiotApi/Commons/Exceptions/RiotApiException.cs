using System;
using System.Net;
using System.Runtime.Serialization;

namespace RiotApi.Commons.Exceptions
{
    /// <summary>
    /// Classe che contiene le eccezzioni generate dalle chiamate alle API Riot
    /// https://developer.riotgames.com/docs/response-codes
    /// </summary>
    public class RiotApiException : Exception
    {
        public RiotApi.Commons.Enums.RiotApiErrorCode RiotErrorCode { get; set; }
        

        public RiotApiException(RiotApi.Commons.Enums.RiotApiErrorCode errorCode)
            : base() { this.RiotErrorCode = errorCode; }

        public RiotApiException(string message, RiotApi.Commons.Enums.RiotApiErrorCode errorCode)
            : base(message) { this.RiotErrorCode = errorCode; }

        public RiotApiException(string message, Exception inner, RiotApi.Commons.Enums.RiotApiErrorCode errorCode)
            : base(message, inner) { this.RiotErrorCode = errorCode; }

        protected RiotApiException(SerializationInfo info, StreamingContext context, RiotApi.Commons.Enums.RiotApiErrorCode errorCode)
            : base(info, context) { this.RiotErrorCode = errorCode;  }
    }
}
