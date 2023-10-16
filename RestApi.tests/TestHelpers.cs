using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;

namespace RestApi.tests
{
    public class TestHelpers
    {
        private const int _expectedMaxElapsedMilliseconds = 1000;
        public const string _jsonMediaType = "application/json";
        public static readonly JsonSerializerOptions _jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };

        public static async Task AssertResponseWithContentAsync<T>(Stopwatch stopwatch, HttpResponseMessage response, HttpStatusCode expectedStatusCode, T expectedContent)
        {
            AssertCommonResponseParts(stopwatch, response, expectedStatusCode);
            Assert.Equal(_jsonMediaType, response.Content.Headers.ContentType?.MediaType);
            Assert.Equal(expectedContent, await JsonSerializer.DeserializeAsync<T?>(await response.Content.ReadAsStreamAsync(), _jsonSerializerOptions));

        }

        public static void AssertCommonResponseParts(Stopwatch stopwatch, HttpResponseMessage response, HttpStatusCode expectedStatusCode)
        {
            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.True(stopwatch.ElapsedMilliseconds < _expectedMaxElapsedMilliseconds);
        }

        public static StringContent GetJsonStringContent<T>(T content) => new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, _jsonMediaType);
        
    }
}
