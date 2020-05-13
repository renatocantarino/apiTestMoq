using core.Data.DbContext;
using System;
using System.Net.Http;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using core.Api;

namespace Tests.Api.Integration.Base
{
    public class BaseTestFixture : IDisposable
    {
        public readonly HttpClient Client;
        public readonly TestServer Server;
        public readonly DataContext TestMainContext;

        public BaseTestFixture()
        {
            Server = new TestServer(
                WebHost.CreateDefaultBuilder()
                    .UseEnvironment("Testing")
                    .UseStartup<Startup>());

            TestMainContext = Server.Host.Services.GetService(typeof(DataContext)) as DataContext;

            Client = Server.CreateClient();

            SetupDatabase();
        }

        public void Dispose()
        {
            TestMainContext.Dispose();
            Client.Dispose();
            Server.Dispose();
        }

        private void SetupDatabase()
        {
            try
            {
                //Prepare database
            }
            catch
            {
                //TODO: Add a better logging
                // Does nothing
            }
        }
    }
}