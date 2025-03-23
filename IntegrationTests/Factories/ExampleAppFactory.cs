using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTests.Factories
{
    [CollectionDefinition(nameof(TestCollection))]
    public class TestCollection : ICollectionFixture<ExampleAppFactory>;

    public class ExampleAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        public HttpClient Client { get; private set; } = default!;
  
        public Task InitializeAsync()
        {
            Client = CreateClient();
            Console.WriteLine("InitializeAsync hit.");
            return Task.CompletedTask;
        }

        Task IAsyncLifetime.DisposeAsync()
        {
            Client.Dispose();
            Console.WriteLine("DisposeAsync hit.");
            return Task.CompletedTask;
        }
    }
}
