using System;
using System.Net;

namespace CurrentAccount.Account.Service.Exceptions
{
    public class ApiException : Exception
    {
        public string ErrorMessage { get; set; }
        public HttpStatusCode ErrorCode { get; set; }

        public ApiException(string message, HttpStatusCode code)
        {
            ErrorMessage = message;
            ErrorCode = code;
        }
    }
}