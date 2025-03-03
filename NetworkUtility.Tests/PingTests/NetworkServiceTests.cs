using System.Net.NetworkInformation;
using NetworkUtility.Ping;
using FluentAssertions;
using Xunit;
using FluentAssertions.Extensions;
using NetworkUtility.DNS;
using FakeItEasy;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        private readonly IDNS _dNS;
        private readonly NetworkService _pingService;

        public NetworkServiceTests()
        {
            //Dependencies
            _dNS = A.Fake<IDNS>();

            //SUT (System Under Test)
            _pingService = new NetworkService(_dNS);
        }

        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            //Arrange - variables, classes, mocks
            A.CallTo(() => _dNS.SendDNS()).Returns(true);

            //Act
            var result = _pingService.SendPing();

            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeNullOrEmpty();
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        public void NetwokService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            //Arrange

            //Act
            var result = _pingService.PingTimeout(a, b);

            //Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(int.MinValue, 0);
        }

        [Fact]
        public void NetworkService_LastPingDate_ReturnDateTime()
        {
            //Arrange

            //Act
            var result = _pingService.LastPingDate();

            //Assert
            result.Should().BeBefore(1.March(2030));
            result.Should().BeAfter(1.March(2024));
        }

        [Fact]
        public void NetworkService_LastPing_PingOptions()
        {
            //Arrange
            var expectedResult = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            //Act
            var result = _pingService.PingOptions();

            //Assert WARNING: "Be" careful
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expectedResult);
            result.Ttl.Should().Be(1);
        }

        [Fact]
        public void NetworkService_MostRecentPings_ReturnObjectList()
        {
            //Arrange
            var expectedResult = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            //Act
            var result = _pingService.MostRecentPings();

            //Assert WARNING: "Be" careful
            result.Should().BeOfType<List<PingOptions>>();
            result.Should().ContainEquivalentOf(expectedResult);
            result.Should().Contain(x => x.DontFragment == true);
        }
    }
}