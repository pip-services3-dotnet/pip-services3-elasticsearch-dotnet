using System;
using PipServices.Components.Build;
using PipServices.Commons.Refer;
using PipServices.ElasticSearch.Log;

namespace PipServices.ElasticSearch.Build
{
    /// <summary>
    /// Creates ElasticSearch components by their descriptors.
    /// </summary>
    /// See <a href="https://rawgit.com/pip-services-dotnet/pip-services-elasticsearch-dotnet/master/doc/api/class_pip_services_1_1_elastic_search_1_1_log_1_1_elastic_search_logger.html">ElasticSearchLogger</a>
    public class DefaultElasticSearchFactory: Factory
    {
        public static readonly Descriptor Descriptor = new Descriptor("pip-services", "factory", "elasticsearch", "default", "1.0");
        public static readonly Descriptor ElasticSearchLoggerDescriptor = new Descriptor("pip-services", "logger", "elasticsearch", "*", "1.0");

        /// <summary>
        /// Create a new instance of the factory.
        /// </summary>
        public DefaultElasticSearchFactory()
        {
            RegisterAsType(DefaultElasticSearchFactory.ElasticSearchLoggerDescriptor, typeof(ElasticSearchLogger));
        }
    }
}
