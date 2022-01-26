using System.Net;

namespace SchoolStudyAgain.Interface
{
    public class CustomHttpResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public object Data { get; set; }

        public string[] Errors { get; set; }
    }
}
