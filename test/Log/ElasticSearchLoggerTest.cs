using System;
using PipServices3.Commons.Config;
using PipServices3.Commons.Convert;
using Xunit;

namespace PipServices3.ElasticSearch.Log
{
    public sealed class ElasticSearchLoggerTest: IDisposable
    {
        private readonly bool _enabled;
        private readonly TestElasticSearchLogger _logger;
        private readonly LoggerFixture _fixture;
        private readonly ElasticSearchLoggerFixture _esFixture;

        private string _dateFormat = "yyyyMMdd";

        public ElasticSearchLoggerTest()
        {
            var ELASTICSEARCH_ENABLED = Environment.GetEnvironmentVariable("ELASTICSEARCH_ENABLED") ?? "true";
            var ELASTICSEARCH_SERVICE_HOST = Environment.GetEnvironmentVariable("ELASTICSEARCH_SERVICE_HOST") ?? "localhost";
            var ELASTICSEARCH_SERVICE_PORT = Environment.GetEnvironmentVariable("ELASTICSEARCH_SERVICE_PORT") ?? "9200";

            _enabled = BooleanConverter.ToBoolean(ELASTICSEARCH_ENABLED);

            if (_enabled)
            {
                _logger = new TestElasticSearchLogger();
                _logger.Configure(ConfigParams.FromTuples(
                    "level", "trace",
                    "source", "test",
                    "index", "log",
                    "date_format", _dateFormat,
                    "daily", true,
                    "connection.host", ELASTICSEARCH_SERVICE_HOST,
                    "connection.port", ELASTICSEARCH_SERVICE_PORT
                ));

                _fixture = new LoggerFixture(_logger);
                _esFixture = new ElasticSearchLoggerFixture(_logger);

                _logger.OpenAsync(null).Wait();
                // _logger.OpenAsync(null).Wait();
            }
        }

        public void Dispose()
        {
            if (_logger != null)
            {
                _logger.CloseAsync(null).Wait();
            }
        }

        [Theory]
        [InlineData("yyyyMMdd")]
        [InlineData("yyyy.MM.dd")]
        [InlineData("yyyy.M.dd")]
        public void TestSimpleLogging(string dateFormat)
        {
            if (_enabled)
            {
                _dateFormat = dateFormat;

                _fixture.TestSimpleLogging();
                _esFixture.TestSimpleLogging();
            }
        }

        [Theory]
        [InlineData("yyyyMMdd")]
        [InlineData("yyyy.MM.dd")]
        [InlineData("yyyy.M.dd")]
        public void TestErrorLogging(string dateFormat)
        {
            if (_enabled)
            {
                _dateFormat = dateFormat;

                _fixture.TestErrorLogging();
                _esFixture.TestErrorLogging();
            }
        }
    }
}
