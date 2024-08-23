using DeviceHandler.DTOs;
using DeviceHandler.Repositories.ConflictDetection;

namespace Tests
{
    public class ConflictDetectorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetConflictedDevices()
        {
            //arrange
            var detector = new ConflictDetector();
            var deviceInfos = new[]
            {
                Create("123", true, "a"),
                Create("123", false, "b"),
                Create("124", false, "c"),
                Create("124", false, "d"),
                Create("125", false, "f"),
            };

            //act
            var conflicts = await detector.GetConflictedDevices(deviceInfos);

            //assert
            Assert.That(conflicts, Has.Length.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(conflicts[0].Key, Is.EqualTo("123"));
                Assert.That(conflicts[0].Count(), Is.EqualTo(2));
            });
        }

        private static DeviceInfo Create(string code, bool isOnline, string serialNumber)
        {
            return new DeviceInfo()
            {
                Device = new Device()
                {
                    IsOnline = isOnline,
                    SerialNumber = serialNumber
                },
                Brigade = new Brigade()
                {
                    Code = code
                }
            };
        }
    }
}