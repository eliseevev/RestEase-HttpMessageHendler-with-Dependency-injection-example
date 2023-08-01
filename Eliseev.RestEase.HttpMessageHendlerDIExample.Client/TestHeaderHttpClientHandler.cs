using Eliseev.RestEase.HttpMessageHendlerDIExample.Contracts;

namespace Eliseev.RestEase.HttpMessageHendlerDIExample.Client
{
    internal class TestHeaderHttpClientHandler : DelegatingHandler
    {
        private readonly Incrementator incrementator;

        public TestHeaderHttpClientHandler(Incrementator incrementator)
        {
            this.incrementator = incrementator;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add(HttpHeaders.TestHeader, incrementator.GetNext().ToString());
            return base.SendAsync(request, cancellationToken);
        }
    }
}
