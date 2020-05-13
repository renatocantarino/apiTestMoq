using core.Data.DbContext;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Api.Integration.Base
{
    [Collection("Base collection")]
    public abstract class BaseIntegrationTest
    {
        protected readonly HttpClient Client;
        protected readonly TestServer Server;
        protected readonly DataContext TestMainContext;

        protected BaseIntegrationTest(BaseTestFixture fixture)
        {
            Fixture = fixture;

            TestMainContext = fixture.TestMainContext;
            Server = fixture.Server;
            Client = fixture.Client;

            ClearDb().Wait();
        }

        protected BaseTestFixture Fixture { get; }

        protected StringContent GenerateRequestContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        private async Task ClearDb()
        {
            var commands = new[]
            {
                "EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'",
                "EXEC sp_MSForEachTable 'SET QUOTED_IDENTIFIER ON; DELETE FROM ?'",
                "EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'"
            };

            await TestMainContext.Database.OpenConnectionAsync();

            foreach (var command in commands)
            {
                await TestMainContext.Database.ExecuteSqlCommandAsync(command);
            }

            TestMainContext.Database.CloseConnection();
        }
    }
}