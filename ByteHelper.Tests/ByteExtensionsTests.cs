using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ByteHelper.Tests
{

    [TestClass]
    public class ByteExtensionsTests
    {

        #region GetBytes Tests


        [TestMethod]
        public void GivenNullByteArray_WhenGetBytes_ReturnEmptyByteArray()
        {
            byte[] bytes = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var result = bytes.GetBytes(0, 1);
            result.Length.Should().Be(0);
        }

        [TestMethod]
        public void GivenEmptyByteArray_WhenGetBytes_ReturnEmptyByteArray()
        {
            byte[] bytes = { };
            var result = bytes.GetBytes(0, 1);
            result.Length.Should().Be(0);
        }

        [TestMethod]
        public void GivenStartAtLowerThanZero_WhenGetBytes_ReturnEmptyByteArray()
        {
            byte[] bytes = { };

            var result = bytes.GetBytes(0, -1);

            result.Length.Should().Be(0);
        }

        [TestMethod]
        public void GivenStartAtEqualsToOrGreaterThanArrayLength_WhenGetBytes_ReturnEmptyByteArray()
        {
            byte[] bytes = { 1 };

            var result = bytes.GetBytes(1, 1);

            result.Length.Should().Be(0);
        }

        [TestMethod]
        public void GivenStartAtPlusLengthGreaterThanArrayLength_WhenGetBytes_ReturnEmptyByteArray()
        {
            byte[] bytes = { 1, 2 };

            var result = bytes.GetBytes(0, 3);

            result.Length.Should().Be(0);
        }

        [TestMethod]
        public void GivenDataInArray_WhenGetBytes_ReturnByteArray()
        {
            const int expectedNumber1 = 1;
            const int expectedNumber2 = 2;
            const int expectedNumber3 = 3;
            byte[] bytes = { expectedNumber1, expectedNumber2, expectedNumber3 };

            var result = bytes.GetBytes(0, 3);

            result.Length.Should().Be(3);
            result[0].Should().Be(expectedNumber1);
            result[1].Should().Be(expectedNumber2);
            result[2].Should().Be(expectedNumber3);

            result = bytes.GetBytes(2, 1);

            result.Length.Should().Be(1);
            result[0].Should().Be(expectedNumber3);

            result = bytes.GetBytes(0, 1);

            result.Length.Should().Be(1);
            result[0].Should().Be(expectedNumber1);

            result = bytes.GetBytes(1, 1);

            result.Length.Should().Be(1);
            result[0].Should().Be(expectedNumber2);
        }

        #endregion

        #region AppendBytes tests

        [TestMethod]
        public void GivenTwoNullArrays_WhenAppendBytes_ReturnsEmptyArray()
        {

            byte[] firstArray = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var result = firstArray.AppendBytes(null);

            result.Should().NotBeNull();
            result.Length.Should().Be(0);

        }

        [TestMethod]
        public void GivenNullSource_WhenAppendBytes_ReturnsArray()
        {

            byte[] firstArray = null;
            byte[] secondArray = { 1 };

            // ReSharper disable once ExpressionIsAlwaysNull
            var result = firstArray.AppendBytes(secondArray);

            result.Length.Should().Be(1);
            result[0].Should().Be(1);

        }

        [TestMethod]
        public void GivenNullBytesToAppend_WhenAppendBytes_ReturnsArray()
        {

            byte[] firstArray = { 1 };

            var result = firstArray.AppendBytes(null);

            result.Length.Should().Be(1);
            result[0].Should().Be(1);

        }

        [TestMethod]
        public void GivenTwoArrays_WhenAppendBytes_ReturnsArray()
        {

            byte[] firstArray = { 1 };
            byte[] secondArray = { 2 };

            var result = firstArray.AppendBytes(secondArray);

            result.Length.Should().Be(2);
            result[0].Should().Be(1);
            result[1].Should().Be(2);

        }

        #endregion

    }
}
