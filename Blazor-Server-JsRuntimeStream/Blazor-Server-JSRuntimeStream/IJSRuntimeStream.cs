using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JsRuntimeStream
{
	public interface IJSRuntimeStream
	{
		Task<Stream> InvokeReadStream(string identifier, CancellationToken token, params object?[]? args);
	}
}
