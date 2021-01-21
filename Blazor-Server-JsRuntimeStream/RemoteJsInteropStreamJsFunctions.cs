using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsRuntimeStream
{
    internal static class RemoteJsInteropStreamJsFunctions
    {
        private const string JsFunctionsPrefix = "JsIntropStreamFunctions.";

        public const string GetMemorySize = JsFunctionsPrefix + "getMemorySize";

        public const string ReadData = JsFunctionsPrefix + "readData";
    }
}
