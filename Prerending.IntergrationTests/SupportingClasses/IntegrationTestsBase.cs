using System;
using System.Net.Http;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Prerendering;

namespace Prerending.IntergrationTests.SupportingClasses
{
    public class IntegrationTestsBase<TStartup> : IDisposable
        where TStartup : class
    {
        private readonly TestServer _server;

        public IntegrationTestsBase( )
        {
            var host = WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>();
                       

            this._server = new TestServer( host );
            this.Client = this._server.CreateClient();
            this.Client.BaseAddress = new Uri( "http://localhost:63816/" );
        }

        public HttpClient Client { get; }

        public void Dispose( )
        {
            this.Client.Dispose();
            this._server.Dispose();
        }

        protected virtual void ConfigureServices( IServiceCollection services )
        { }
    }
}