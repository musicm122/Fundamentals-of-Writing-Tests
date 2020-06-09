using System.Collections.Generic;

namespace HelloTests.Tests
{
    public class SpyExporter : IExportable
    {
        public bool ExportIsCalled = false;

        public string Export(IEnumerable<FizzBuzzResult> results)
        {
            ExportIsCalled = true;
            return string.Empty;
        }
    }
}