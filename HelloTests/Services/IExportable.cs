using System.Collections;
using System.Collections.Generic;

namespace HelloTests
{
    public interface IExportable
    {
        string Export(IEnumerable<FizzBuzzResult> results);
    }
}