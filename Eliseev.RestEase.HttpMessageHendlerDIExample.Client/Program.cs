using Eliseev.RestEase.HttpMessageHendlerDIExample.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestEase.HttpClientFactory;

namespace Eliseev.RestEase.HttpMessageHendlerDIExample.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddScoped<Incrementator>();
            builder.Services.AddScoped<TestHeaderHttpClientHandler>();

            builder.Services.AddHttpClient(nameof(RestEase))
                .ConfigureHttpClient(x => x.BaseAddress = new Uri("https://localhost:7262"))
                .AddHttpMessageHandler<TestHeaderHttpClientHandler>()
                .UseWithRestEaseClient<ISampleController>();

            using IHost host = builder.Build();
            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider serviceProvider = serviceScope.ServiceProvider;


            await RequestSampleController(serviceProvider, "1");
            await RequestSampleController(serviceProvider, "2");
            await RequestSampleController(serviceProvider, "3");

            static async Task RequestSampleController(IServiceProvider serviceProvider, string expectedTestHeaderValue)
            {
                var sampleController = serviceProvider.GetRequiredService<ISampleController>();
                var requestTestHeaderValue = await sampleController.GetRequestTestHeaderValue();
                Assert.Equal(expectedTestHeaderValue, requestTestHeaderValue);
            }
        }

        private static class Assert
        {
            internal static void Equal(string expected, string actual)
            {
                if (!expected.Equals(actual))
                {
                    throw new Exception($"Values are not equal: Expected \"{expected}\", Actual \"{actual}\"");
                }
            }
        }
    }
}