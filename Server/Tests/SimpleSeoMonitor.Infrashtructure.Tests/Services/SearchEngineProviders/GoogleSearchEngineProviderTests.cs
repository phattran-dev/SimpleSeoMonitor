using FluentAssertions;
using Moq;
using SimpleSeoMonitor.Domain.Shared.Helpers.Interfaces;
using SimpleSeoMonitor.Infrastructure.Services.SearchEngineProviders;

namespace SimpleSeoMonitor.Infrashtructure.Tests.Services.SearchEngineProviders
{
    public class GoogleSearchEngineProviderTests
    {
        private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
        private readonly Mock<IHttpHelper> _httpHelperMock;
        private readonly Mock<IRegexHelper> _regexHelperMock;
        private readonly GoogleSearchEngineProvider _provider;
        public GoogleSearchEngineProviderTests()
        {
            _httpClientFactoryMock = new Mock<IHttpClientFactory>();
            _httpHelperMock = new Mock<IHttpHelper>();
            _regexHelperMock = new Mock<IRegexHelper>();
            _provider = new GoogleSearchEngineProvider(_httpClientFactoryMock.Object, _httpHelperMock.Object, _regexHelperMock.Object);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "test keyword")]
        [InlineData("https://test.com", null)]
        [InlineData("not valid url format", null)]
        public async Task GetSEOIndexesAsync_ShouldThrowException_WhenInputParametersInvalid(string url, string keyword)
        {
            // Act
            Func<Task> act = async () => await _provider.GetSEOIndexesAsync(url, keyword, 100);

            // Assert
            await act.Should().ThrowAsync<Exception>();
        }
    }
}
