using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTools.Utilities.JsRuntimeStream
{
	public static class JsRuntimeStreamServiceExtensions
	{

		public static IServiceCollection AddJsRuntimeStream(this IServiceCollection services, RemoteJsInteropStreamOptions configuration)
		{
			if (configuration == null)
			{
				throw new ArgumentNullException(nameof(configuration));
			}

			services.AddScoped<IJSRuntimeStream, JSRuntimeStream>();
			services.Configure<RemoteJsInteropStreamOptions>(config => {
				config.MaxBufferSize = configuration.MaxBufferSize;
				config.MaxSegmentSize = configuration.MaxSegmentSize;
				config.SegmentFetchTimeout = configuration.SegmentFetchTimeout;
			});
			return services;
		}

		public static IServiceCollection AddJsRuntimeStream(this IServiceCollection serviceCollection)
		{
			return AddJsRuntimeStream(serviceCollection, new RemoteJsInteropStreamOptions());
		}

		public static IServiceCollection AddJsRuntimeStream(this IServiceCollection serviceCollection, Action<RemoteJsInteropStreamOptions> configuration)
		{
			if (configuration == null)
			{
				throw new ArgumentNullException(nameof(configuration));
			}

			var options = new RemoteJsInteropStreamOptions();
			configuration(options);

			return AddJsRuntimeStream(serviceCollection, options);
		}
	}
}
