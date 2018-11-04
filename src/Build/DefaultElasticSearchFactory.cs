using System;
using PipServices3.Components.Build;
using PipServices3.Commons.Refer;
using PipServices3.ElasticSearch.Log;

namespace PipServices3.ElasticSearch.Build
{
    /// <summary>
    /// Creates ElasticSearch components by their descriptors.
    /// </summary>
    /// See <a href="https://rawgit.com/pip-services3-dotnet/pip-services3-elasticsearch-dotnet/master/doc/api/class_pip_services_1_1_elastic_search_1_1_log_1_1_elastic_search_logger.html">ElasticSearchLogger</a>
    public class DefaultElasticSearchFactory: Factory
    {
        public static readonly Descriptor Descriptor = new Descriptor("pip-services3", "factory", "elasticsearch", "default", "1.0");
        public static readonly Descriptor ElasticSearchLoggerDescriptor = new Descriptor("pip-services3", "logger", "elasticsearch", "*", "1.0");

        /// <summary>
        /// Create a new instance of the factory.
        /// </summary>
        public DefaultElasticSearchFactory()
        {
            RegisterAsType(DefaultElasticSearchFactory.ElasticSearchLoggerDescriptor, typeof(ElasticSearchLogger));
        }
    }
}
