using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Api.Tests.Infrastructure
{
    public class StockTrackerApiTestsFixture : IDisposable
    {

        //Tanım: Fixture, testlerin çalıştırılmasında kullanılan ortak veri ve durumları içerir. Yani, API uygulaması ayağa kalkarken Program.cs içindeki bütün konfigürasyonlar uygulanmalıdır.
        //Test ortamında ihtiyaç duyulan servislerin konfigürasyonları burada yapılır.

        private readonly WebApplicationFactory<Program> _factory;
        public HttpClient Client { get; }
        public Mock<IMediator> MediatorMock { get; } = new Mock<IMediator>();
        public StockTrackerApiTestsFixture()
        {
            _factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureTestServices(services =>
                     {
                         services.AddSingleton<IMediator>(MediatorMock.Object);
                         //Eğer EF Core - inmemory kullanılacaksa burada tanımlanmalıdır.
                         services.AddLogging(config=>config.SetMinimumLevel(LogLevel.Warning));


                     });
                });
            Client = _factory.CreateClient();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public void Dispose()
        {
            Client.Dispose();
            _factory.Dispose();
        }
    }
   
}
