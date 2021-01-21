using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JsRuntimeStream
{
	internal class JsRuntimeStreamInfo
	{
		public string Identifier { get; set; }

		public long Size { get; set; }

		public object?[]? Arguments { get; set; }
	}
}
