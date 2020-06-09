using HelloTests.Services.Implementation;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace HelloTests.Tests
{
    public class FizzBuzzEvaluatorTests
    {
        private Mock<IExportable> MockExporter { get; set; } = new Mock<IExportable>();

        public FizzBuzzEvaluatorTests()
        {
            MockExporter
                .Setup(e => e.Export(It.IsAny<IEnumerable<FizzBuzzResult>>()))
                .Returns("");
        }

        // With Mock
        [Fact]
        public void Mock_ReturnsNumbersThatAreDivisibleByThree()
        {
            MockExporter
                .Setup(e => e.Export(It.IsAny<IEnumerable<FizzBuzzResult>>()))
                .Returns("");

            //Arrange
            int[] inputData = new int[] { 1, 3, 5, 7, 9, 12 };
            int[] expectedOutput = new int[] { 3, 9, 12 };
            var fbEval = new FizzBuzzEvaluator(MockExporter.Object);

            // Act
            var actualOutput = fbEval.FilterByFizz(inputData);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        // With stub
        [Fact]
        public void Stub_ReturnsNumbersThatAreDivisibleByThree()
        {
            //Arrange
            int[] inputData = new int[] { 1, 3, 5, 7, 9, 12 };
            int[] expectedOutput = new int[] { 3, 9, 12 };
            var stubExporter = new StubExporter();
            var fbEval = new FizzBuzzEvaluator(stubExporter);

            // Act
            var actualOutput = fbEval.FilterByFizz(inputData);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        // With spy
        [Fact]
        public void Spy_ShouldNotCallExport()
        {
            //Arrange
            int[] inputData = new int[] { 1, 3, 5, 7, 9, 12 };
            int[] expectedOutput = new int[] { 3, 9, 12 };
            var spyExport = new SpyExporter();
            var fbEval = new FizzBuzzEvaluator(spyExport);

            // Act
            var actualOutput = fbEval.FilterByFizz(inputData);

            // Assert
            Assert.False(spyExport.ExportIsCalled);
        }

        // With Dummy
        [Fact]
        public void Dummy_ReturnsNumbersThatAreDivisibleByFive()
        {
            //Arrange
            int[] inputData = new int[] { 1, 3, 5, 7, 9, 12 };
            int[] expectedOutput = new int[] { 5 };
            // Dummy does not have any bearying on the outcome of the test.
            IExportable dummy = new TextExport();
            var fbEval = new FizzBuzzEvaluator(dummy);

            // Act
            var actualOutput = fbEval.FilterByBuzz(inputData);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        // Using Theory
        [Theory]
        [InlineData(new[] { 1, 3, 5, 7, 9, 12 }, new[] { 5 })]
        [InlineData(new[] { 0, 5, 10, 15, 20, 12, 10 }, new[] { 0, 5, 10, 15, 20, 10 })]
        [InlineData(new[] { 0, 1, 3, 4 }, new int[] { 0 })]
        public void ReturnsNumbersThatAreDivisibleByFive(int[] inputData, int[] expectedOutput)
        {
            //Arrange
            var fbEval = new FizzBuzzEvaluator(MockExporter.Object);

            // Act
            var actualOutput = fbEval.FilterByBuzz(inputData);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ThrowsNullRefIfExportNotProvided()
        {
            Assert.Throws<ArgumentNullException>(() => new FizzBuzzEvaluator(null));
        }
    }
}