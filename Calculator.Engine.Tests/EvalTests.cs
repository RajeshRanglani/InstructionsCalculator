using Calculator.Engine.Interfaces;
using FluentValidation;
using NUnit.Framework;
using System;
using System.Text;

namespace Calculator.Engine.Tests
{
    public class EvalTests
    {
        IProvide<object, string> _evaluator;

        [SetUp]
        public void Setup()
        {   _evaluator = new EvalProvider();
        }

        [Test]
        public void NoDataProvidedToEval()
        {
            //Act
            string data = string.Empty;

            //Arrange
            var actual =_evaluator.Provide(data);

            //Assert
            Assert.IsNull(actual,$"Expected null, value is {actual}.");
        }

        [Test]
        public void InvalidDataProvidedToEval()
        {
            //Act
            string data = "This string cannot be computed.";

            //Arrange
            var actual = _evaluator.Provide(data);

            //Assert
            Assert.IsNull(actual, $"Expected null, value is {actual}.");
        }

        [Test]
        public void ValidDataProvidedToEvalWithoutParenthesis()
        {
            //Act
            string data = "3+2*5";

            //Arrange
            var actual = _evaluator.Provide(data);

            //Assert
            Assert.AreEqual(13, actual, $"Expected 13, value is {actual}.");
        }

        [Test]
        public void ValidDataProvidedToEvalWithParenthesis()
        {
            //Act
            string data = "(3 + 2)*5";

            //Arrange
            var actual = _evaluator.Provide(data);

            //Assert
            Assert.AreEqual(25, actual, $"Expected 25, value is {actual}.");
        }

        [Test]
        public void ValidDataProvidedToEvalWithANegativeNumber()
        {
            //Act
            string data = "3+2*5+-1";

            //Arrange
            var actual = _evaluator.Provide(data);

            //Assert
            Assert.AreEqual(12, actual, $"Expected 12, value is {actual}.");
        }

    }
}