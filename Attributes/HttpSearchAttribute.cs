using Microsoft.AspNetCore.Mvc.Routing;

namespace HTTPSearch_POC.Attributes
{
    public class HttpSearchAttribute : HttpMethodAttribute
    {
        private static readonly string[] _supportedMethods = new[] { "SEARCH" };

        public HttpSearchAttribute() : base(_supportedMethods) { }

        public HttpSearchAttribute(string template) : base(_supportedMethods, template) { }
    }
   
}
