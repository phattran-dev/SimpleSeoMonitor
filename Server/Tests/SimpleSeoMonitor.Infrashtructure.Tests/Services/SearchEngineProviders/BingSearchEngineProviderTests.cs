using FluentAssertions;
using Moq;
using Moq.Protected;
using SimpleSeoMonitor.Domain.Shared.Helpers;
using SimpleSeoMonitor.Infrastructure.Services.SearchEngineProviders;
using System.Net;

namespace SimpleSeoMonitor.Infrashtructure.Tests.Services.SearchEngineProviders
{
    public class BingSearchEngineProviderTests
    {
        private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
        private readonly Mock<HttpMessageHandler> _handlerMock;
        private readonly Mock<HttpHelper> _httpHelperMock;
        private readonly BingSearchEngineProvider _provider;
       
        public BingSearchEngineProviderTests()
        {
            _httpClientFactoryMock = new Mock<IHttpClientFactory>();
            _handlerMock = new Mock<HttpMessageHandler>();
            _httpHelperMock = new Mock<HttpHelper>();
            _provider = new BingSearchEngineProvider(_httpClientFactoryMock.Object, _httpHelperMock.Object);
        }

        private void SetupHttpResponse(bool throwException, HttpStatusCode? statusCode = null, string? content = null)
        {
            if (throwException)
                _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new HttpRequestException("Request failed"));
            else
                _handlerMock.Protected()
                    .Setup<Task<HttpResponseMessage>>("SendAsync",
                        ItExpr.IsAny<HttpRequestMessage>(),
                        ItExpr.IsAny<CancellationToken>())
                    .ReturnsAsync(new HttpResponseMessage
                    {
                        StatusCode = statusCode ?? HttpStatusCode.OK,
                        Content = new StringContent(content)
                    });

            var httpClient = new HttpClient(_handlerMock.Object);
            _httpClientFactoryMock.Setup(_ => _.CreateClient("Google")).Returns(httpClient);
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
