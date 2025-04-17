using System.Net;
using System.Net.Http.Json;
using LudoGame.Api.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LudoGame.Api.Tests
{

    [TestClass]
    public class ApiTests
    {
        private static WebApplicationFactory<Program>? _factory;
        private static HttpClient? _client;

        [ClassInitialize]
        public static void Init(TestContext _)
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [ClassCleanup]
        public static void Clean()
        {
            _client?.Dispose();
            _factory?.Dispose();
        }

        [TestMethod]
        public async Task PostGames_ShouldReturnCreated()
        {
            var body = new CreateGameRequest(new[] { "Red", "Green" });

            var resp = await _client!.PostAsJsonAsync("/api/games", body);

            Assert.AreEqual(HttpStatusCode.Created, resp.StatusCode);
        }
    }
}
