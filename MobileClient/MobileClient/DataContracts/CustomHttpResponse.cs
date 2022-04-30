using System.Net;

namespace MobileClient.DataContracts
{
    public class CustomHttpResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public object Data { get; set; }

        public string[] Errors { get; set; }
    }
}
