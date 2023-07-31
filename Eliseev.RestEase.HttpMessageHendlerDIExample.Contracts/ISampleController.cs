using RestEase;

namespace Eliseev.RestEase.HttpMessageHendlerDIExample.Contracts
{
    [BasePath(Routes.BasePath)]
    public interface ISampleController
    {
        public static class Routes
        {
            public const string BasePath = "sample";
        }
        
        [Get]
        Task<string> GetRequestTestHeaderValue();
    }
}