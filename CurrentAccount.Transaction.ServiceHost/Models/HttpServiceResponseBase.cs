using System.Net;

namespace CurrentAccount.Transaction.ServiceHost.Models
{
    public class HttpServiceResponseBase
    {
        public ErrorModel Error { get; set; }
    }

    public class HttpServiceResponseBase<TData>
    {
        public TData Data { get; set; }
        public HttpStatusCode Code { get; set; }
    }

    public class ErrorModel
    {
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}