using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsRuntimeStream
{
    internal static class RemoteJsInteropStreamJsFunctions
    {
        private const string JsFunctionsPrefix = "JsIntropStreamFunctions.";

        public const string Init = JsFunctionsPrefix + "init";

        public const string Destroy = JsFunctionsPrefix + "destroy";

        public const string ReadData = JsFunctionsPrefix + "readData";
    }
}
