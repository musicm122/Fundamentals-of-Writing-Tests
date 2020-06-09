using System.Collections.Generic;

namespace HelloTests.Tests
{
    public class StubExporter : IExportable
    {
        public string ValueToReturn { get; set; } = string.Empty;
        public string Export(IEnumerable<FizzBuzzResult> results)
        {
            return ValueToReturn;
        }
    }
}