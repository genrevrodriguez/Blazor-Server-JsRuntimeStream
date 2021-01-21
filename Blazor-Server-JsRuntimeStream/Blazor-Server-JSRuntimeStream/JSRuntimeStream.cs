using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JsRuntimeStream
{
	public class JSRuntimeStream : IJSRuntimeStream
	{
		private readonly IOptions<RemoteJsInteropStreamOptions> options;
		private readonly IJSRuntime jsRuntime;

		public JSRuntimeStream(
			IOptions<RemoteJsInteropStreamOptions> options,
			IJSRuntime jsRuntime)
		{
			this.options = options;
			this.jsRuntime = jsRuntime;
		}

		public async Task<Stream> InvokeReadStream(string identifier, CancellationToken token, params object?[]? args)
		{
			var jsRuntimeStreamInfo = await jsRuntime.InvokeAsync<JsRuntimeStreamInfo>(RemoteJsInteropStreamJsFunctions.Init, token, identifier, args);
			return new RemoteJSInteropStream(jsRuntime, jsRuntimeStreamInfo, options.Value, token);
		}
	}
}
