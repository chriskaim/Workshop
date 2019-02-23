using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkshopCsharp;

namespace WorkshopCsharpTests
{
    [TestClass]
    public class MomentTests
    {
        [TestMethod]
        public void ThreeArgumentConstructorTest()
        {
            // arrange
            Moment time = new Moment(05, 22, 30);

            // act
            byte hours = time.Hours;
            byte minutes = time.Minutes;
            byte seconds = time.Seconds;
            byte expectedHours = 5;
            byte expectedMinutes = 22;
            byte expectedSeconds = 30;

            // assert
            Assert.AreEqual(hours, expectedHours);
            Assert.AreEqual(minutes, expectedMinutes);
            Assert.AreEqual(seconds, expectedSeconds);
        }

        [TestMethod]
        public void TwoArgumentConstructorTest()
        {
            // arrange
            Moment time = new Moment(05, 22);

            // act
            byte hours = time.Hours;
            byte minutes = time.Minutes;
            byte seconds = time.Seconds;
            byte expectedHours = 5;
            byte expectedMinutes = 22;
            byte expectedSeconds = 0;

            // assert
            Assert.AreEqual(hours, expectedHours);
            Assert.AreEqual(minutes, expectedMinutes);
            Assert.AreEqual(seconds, expectedSeconds);
        }

        [TestMethod]
        public void OneArgumentConstructorTest()
        {
            // arrange
            Moment time = new Moment(05);

            // act
            byte hours = time.Hours;
            byte minutes = time.Minutes;
            byte seconds = time.Seconds;
            byte expectedHours = 5;
            byte expectedMinutes = 0;
            byte expectedSeconds = 0;

            // assert
            Assert.AreEqual(hours, expectedHours);
            Assert.AreEqual(minutes, expectedMinutes);
            Assert.AreEqual(seconds, expectedSeconds);
        }

        [TestMethod]
        public void StringArgumentConstructorTest()
        {
            // arrange
            Moment time = new Moment("22:50:23");

            // act
            byte hours = time.Hours;
            byte minutes = time.Minutes;
            byte seconds = time.Seconds;
            byte expectedHours = 22;
            byte expectedMinutes = 50;
            byte expectedSeconds = 23;

            // assert
            Assert.AreEqual(hours, expectedHours);
            Assert.AreEqual(minutes, expectedMinutes);
            Assert.AreEqual(seconds, expectedSeconds);
        }

        [TestMethod]
        public void ToStringTest()
        {
            // arrange
            Moment time = new Moment(5, 22, 53);

            // act
            string toStringResult = time.ToString();
            string expectedToStringResult = "05:22:53";

            // assert
            Assert.AreEqual(toStringResult, expectedToStringResult);
        }

        [TestMethod]
        public void EqualsIsTrueTest()
        {
            // arrange
            Moment t1 = new Moment(10, 23, 24);
            Moment t2 = new Moment(10, 23, 24);

            // act
            bool result = t1.Equals(t2);

            // assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void EqualsIsFalseTest()
        {
            // arrange
            Moment t1 = new Moment(10, 23, 24);
            Moment t2 = new Moment(10, 15, 24);

            // act
            bool result = t1.Equals(t2);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CompareToGreatherThanTest()
        {
            // arrange
            Moment t1 = new Moment(12, 23, 44);
            Moment t2 = new Moment(12, 15, 44);

            // act
            int result = t1.CompareTo(t2);

            // assert
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void CompareToLessThanTest()
        {
            // arrange
            Moment t1 = new Moment(13, 13, 44);
            Moment t2 = new Moment(13, 29, 44);

            // act
            int result = t1.CompareTo(t2);

            // assert
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void CompareToEqualsTest()
        {
            // arrange
            Moment t1 = new Moment(13, 29, 44);
            Moment t2 = new Moment(13, 29, 44);

            // act
            int result = t1.CompareTo(t2);

            // assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void OperatorEqualTest()
        {
            // arrange
            Moment t1 = new Moment(13, 29, 44);
            Moment t2 = new Moment(13, 29, 44);

            // act
            bool result = t1 == t2;

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OperatorNotEqualTest()
        {
            // arrange
            Moment t1 = new Moment(13, 10, 44);
            Moment t2 = new Moment(12, 29, 44);

            // act
            bool result = t1 != t2;

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OperatorGreatherThanTest()
        {
            // arrange
            Moment t1 = new Moment(12, 23, 44);
            Moment t2 = new Moment(12, 15, 44);

            // act
            bool result = t1 > t2;

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OperatorLessThanTest()
        {
            // arrange
            Moment t1 = new Moment(13, 13, 44);
            Moment t2 = new Moment(13, 29, 44);

            // act
            bool result = t1 < t2;

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OperatorGreatherThanOrEqualTest1()
        {
            // arrange
            Moment t1 = new Moment(12, 23, 44);
            Moment t2 = new Moment(12, 15, 44);

            // act
            bool result = t1 >= t2;

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OperatorGreatherThanOrEqualTest2()
        {
            // arrange
            Moment t1 = new Moment(12, 15, 44);
            Moment t2 = new Moment(12, 15, 44);

            // act
            bool result = t1 >= t2;

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OperatorLessThanOrEqualTest1()
        {
            // arrange
            Moment t1 = new Moment(13, 13, 44);
            Moment t2 = new Moment(13, 29, 44);

            // act
            bool result = t1 <= t2;

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OperatorLessThanOrEqualTest2()
        {
            // arrange
            Moment t1 = new Moment(13, 29, 44);
            Moment t2 = new Moment(13, 29, 44);

            // act
            bool result = t1 <= t2;

            // assert
            Assert.IsTrue(result);
        }
    }
}
