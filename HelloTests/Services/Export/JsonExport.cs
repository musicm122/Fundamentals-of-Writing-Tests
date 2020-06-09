using System.Collections.Generic;
using System.Text.Json;

namespace HelloTests.Services.Implementation
{
    public class JsonExport : IExportable
    {
        public string Export(IEnumerable<FizzBuzzResult> results) =>
            JsonSerializer.Serialize(results, new JsonSerializerOptions() { WriteIndented = true });
    }
}