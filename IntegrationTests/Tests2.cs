﻿using ExampleApp;
using IntegrationTests.Factories;
using System.Text.Json;

namespace IntegrationTests
{
    [Collection(nameof(TestCollection))]
    public class Tests2
    {
        private readonly ExampleAppFactory _factory;
        
        public Tests2(ExampleAppFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Test()
        {
            var response = await _factory.Client.GetAsync("/WeatherForecast");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var weatherForecasts = JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(content);

            Assert.NotNull(weatherForecasts);
            Assert.NotEmpty(weatherForecasts);
        }
    }
}
