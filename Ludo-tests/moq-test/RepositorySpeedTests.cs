using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Diagnostics;
using System.Threading;

namespace Ludo_tests
{
    [TestClass]
    public class RepositorySpeedTests
    {
        [TestMethod]
        public void CompareMockAndRealRepositorySpeed()
        {
            var stopwatch = new Stopwatch();

            // MOCKED REPO
            var mockRepo = new Mock<IPlayerRepository>();
            mockRepo.Setup(r => r.GetPlayerByName("Alice"))
                    .Returns(new Player { Name = "Alice", Color = "Red" });

            stopwatch.Start();
            var mockPlayer = mockRepo.Object.GetPlayerByName("Alice");
            stopwatch.Stop();
            var mockTime = stopwatch.ElapsedMilliseconds;

            // REAL REPO (simuleret langsom)
            var realRepo = new FakePlayerRepository();

            stopwatch.Restart();
            var realPlayer = realRepo.GetPlayerByName("Alice");
            stopwatch.Stop();
            var realTime = stopwatch.ElapsedMilliseconds;

            Debug.WriteLine(" MOCKING VS REAL TEST ");
            Debug.WriteLine($"Mock: {mockTime} ms");
            Debug.WriteLine($"Real: {realTime} ms");

            Assert.AreEqual(mockPlayer.Name, realPlayer.Name);
            Assert.IsTrue(realTime > mockTime);
        }
    }
}
