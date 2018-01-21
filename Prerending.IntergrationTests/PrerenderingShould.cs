using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NFluent;
using Prerendering;
using Prerending.IntergrationTests.SupportingClasses;
using Xunit;

namespace Prerending.IntergrationTests
{
    public class PrerenderingShould //: IntegrationTestsBase<Startup>
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public PrerenderingShould( )
        {
            // Arrange
            _server = new TestServer( new WebHostBuilder()
                                     .UseStartup<Startup>() );

            _client = _server.CreateClient();
            _client.BaseAddress = new Uri( "http://localhost:63816/" );

        }
        [Fact]
        public async Task ReturnHello()
        {
            // Act
            //var response =  Client.GetAsync( "/" ).Result;
            var response = await _server.CreateRequest( "/" )
                .SendAsync( "GET" );

            //var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            //Check.That(responseString ).HasContent().And.Contains("hello");
        }
    }
}
