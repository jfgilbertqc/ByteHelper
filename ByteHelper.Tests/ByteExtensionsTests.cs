using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JFG.ByteHelper.Tests
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
        public void GivenStartAtPlusLengthGreaterThanArrayLength_WhenGetBytes_ReturnSourceArrayFromStartAtToEnd()
        {
            byte[] bytes = { 1, 2 };

            var result = bytes.GetBytes(0, 3);

            result.Length.Should().Be(2);
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

        #region InsertBytes tests

        [TestMethod]
        public void GivenNullArray_WhenInsertBytes_ReturnEmptyArray()
        {
            byte[] bytes = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var result = bytes.InsertBytes(new byte[] { 1 }, 1);

            result.Length.Should().Be(0);

        }

        [TestMethod]
        public void GivenEmptyArray_WhenInsertBytes_ReturnEmptyArray()
        {
            byte[] bytes = { };

            var result = bytes.InsertBytes(new byte[] { 1 }, 1);

            result.Length.Should().Be(0);

        }

        [TestMethod]
        public void GivenNullArrayToInsert_WhenInsertBytes_ReturnFirstArray()
        {
            const int expecteNumber1 = 1;
            const int expecteNumber2 = 2;
            const int expecteNumber3 = 3;
            byte[] bytes = { expecteNumber1, expecteNumber2, expecteNumber3 };

            var result = bytes.InsertBytes(null, 1);

            result.Length.Should().Be(bytes.Length);
            result[0].Should().Be(expecteNumber1);
            result[1].Should().Be(expecteNumber2);
            result[2].Should().Be(expecteNumber3);

        }

        [TestMethod]
        public void GivenEmptyArrayToInsert_WhenInsertBytes_ReturnFirstArray()
        {

            const int expecteNumber1 = 1;
            const int expecteNumber2 = 2;
            const int expecteNumber3 = 3;
            byte[] bytes = { expecteNumber1, expecteNumber2, expecteNumber3 };

            var result = bytes.InsertBytes(new byte[] { }, 1);

            result.Length.Should().Be(bytes.Length);
            result[0].Should().Be(expecteNumber1);
            result[1].Should().Be(expecteNumber2);
            result[2].Should().Be(expecteNumber3);

        }

        [TestMethod]
        public void GivenInsertAtOutOfBounds_WhenInsertBytes_ReturnFirstArray()
        {

            const int expecteNumber1 = 1;
            const int expecteNumber2 = 2;
            const int expecteNumber3 = 3;
            byte[] bytes = { expecteNumber1, expecteNumber2, expecteNumber3 };

            var result = bytes.InsertBytes(new byte[] { 1 }, 4);

            result.Length.Should().Be(bytes.Length);
            result[0].Should().Be(expecteNumber1);
            result[1].Should().Be(expecteNumber2);
            result[2].Should().Be(expecteNumber3);

        }

        [TestMethod]
        public void GivenDataToInsert_WhenInsertBytes_ReturnEntireData()
        {

            const int expecteNumber1 = 1;
            const int expecteNumber2 = 2;
            const int expecteNumber3 = 3;
            byte[] bytes = { expecteNumber1, expecteNumber2, expecteNumber3 };
            const int expecteInsertedNumber1 = 4;
            const int expecteInsertedNumber2 = 5;

            var insertedData = new byte[] { expecteInsertedNumber1, expecteInsertedNumber2 };

            var result = bytes.InsertBytes(insertedData, 2);
            result.Length.Should().Be(bytes.Length + insertedData.Length);
            result[0].Should().Be(expecteNumber1);
            result[1].Should().Be(expecteNumber2);
            result[2].Should().Be(expecteInsertedNumber1);
            result[3].Should().Be(expecteInsertedNumber2);
            result[4].Should().Be(expecteNumber3);

        }
        #endregion

        #region RemoveBytes tests

        [TestMethod]
        public void GivenNullArray_WhenRemove_ReturnEmptyByteArray()
        {

            byte[] bytes = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var result = bytes.RemoveBytes(0, 10);

            result.Length.Should().Be(0);

        }


        [TestMethod]
        public void GivenEmtpyArray_WhenRemove_ReturnEmptyByteArray()
        {

            byte[] bytes = { };

            var result = bytes.RemoveBytes(0, 10);

            result.Length.Should().Be(0);

        }

        [TestMethod]
        public void GivenRemoveAtOutOfBounds_WhenRemove_ReturnSourceArray()
        {

            const int expecteNumber1 = 1;
            const int expecteNumber2 = 2;
            const int expecteNumber3 = 3;
            byte[] bytes = { expecteNumber1, expecteNumber2, expecteNumber3 };

            var result = bytes.RemoveBytes(-1, 10);

            result.Length.Should().Be(3);
            result[0].Should().Be(expecteNumber1);
            result[1].Should().Be(expecteNumber2);
            result[2].Should().Be(expecteNumber3);

            result = bytes.RemoveBytes(4, 10);

            result.Length.Should().Be(3);
            result[0].Should().Be(expecteNumber1);
            result[1].Should().Be(expecteNumber2);
            result[2].Should().Be(expecteNumber3);

        }

        [TestMethod]
        public void GivenRemoveAtPlusLengthGreaterThanDataLength_WhenRemove_ReturnSourceArrayUpToRemoveAt()
        {

            const int expecteNumber1 = 1;
            const int expecteNumber2 = 2;
            const int expecteNumber3 = 3;
            byte[] bytes = { expecteNumber1, expecteNumber2, expecteNumber3 };

            var result = bytes.RemoveBytes(1, 10);

            result.Length.Should().Be(2);
            result[0].Should().Be(expecteNumber1);

        }

        [TestMethod]
        public void GivenLengthZeroOrNegative_WhenRemove_ReturnSourceArray()
        {
            const int expecteNumber1 = 1;
            const int expecteNumber2 = 2;
            const int expecteNumber3 = 3;
            byte[] bytes = { expecteNumber1, expecteNumber2, expecteNumber3 };

            var result = bytes.RemoveBytes(0, -1);

            result.Length.Should().Be(3);
            result[0].Should().Be(expecteNumber1);
            result[1].Should().Be(expecteNumber2);
            result[2].Should().Be(expecteNumber3);

            result = bytes.RemoveBytes(0, 0);

            result.Length.Should().Be(3);
            result[0].Should().Be(expecteNumber1);
            result[1].Should().Be(expecteNumber2);
            result[2].Should().Be(expecteNumber3);
        }

        [TestMethod]
        public void GivenDataToRemove_WhenRemove_ReturnSourceWithoutDataRemoved()
        {

            const int expecteNumber1 = 1;
            const int expecteNumber2 = 2;
            const int expecteNumber3 = 3;
            const int expecteNumber4 = 4;
            const int expecteNumber5 = 5;
            byte[] bytes = { expecteNumber1, expecteNumber2, expecteNumber3, expecteNumber4, expecteNumber5 };

            var result = bytes.RemoveBytes(2, 2);

            result.Length.Should().Be(3);
            result[0].Should().Be(expecteNumber1);
            result[1].Should().Be(expecteNumber2);
            result[2].Should().Be(expecteNumber5);

            bytes = new byte[] { expecteNumber1, expecteNumber2, expecteNumber3, expecteNumber4, expecteNumber5 };

            result = bytes.RemoveBytes(0, 5);
            result.Length.Should().Be(0);

            bytes = new byte[] { expecteNumber1, expecteNumber2, expecteNumber3, expecteNumber4, expecteNumber5 };

            result = bytes.RemoveBytes(3, 1);

            result.Length.Should().Be(4);
            result[0].Should().Be(expecteNumber1);
            result[1].Should().Be(expecteNumber2);
            result[2].Should().Be(expecteNumber3);
            result[3].Should().Be(expecteNumber5);


        }
        #endregion
    }
}

