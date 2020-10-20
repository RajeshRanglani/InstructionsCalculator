using Calculator.Engine.Interfaces;
using FluentValidation;
using NUnit.Framework;
using Moq;
using System;
using System.Text;
using Calculator.Engine.Model;

namespace Calculator.Engine.Tests
{
    public class CalculatorEngineTests
    {
        Mock<IValidator<string[]>> _validator;
        IProvide<CalculatorOutput, string[]> _calculatorEngineProvider;
        Mock<IProvide<StringBuilder, string[]>> _instructionsToExpr;
        Mock<IProvide<object, string>> _evaluator;

        [SetUp]
        public void Setup()
        {
            _validator = new Mock<IValidator<string[]>>();
            _evaluator = new Mock<IProvide<object, string>>();
            _instructionsToExpr = new Mock<IProvide<StringBuilder, string[]>>();
        }

        [Test]
        public void CalculatorEngineExample01()
        {
            //Arrange
            var dummy = new string[] { };
            var dummysbData = new StringBuilder();

            _evaluator.Setup(e => e.Provide(string.Empty)).Returns(1);
            _instructionsToExpr.Setup(i => i.Provide(dummy)).Returns(dummysbData);
            _calculatorEngineProvider = new CalculatorEngineProvider(_validator.Object, _evaluator.Object, _instructionsToExpr.Object);

            //Act
            var expected = _calculatorEngineProvider.Provide(dummy);

            //Assert
            Assert.AreEqual(expected.Output, 1);

        }
    }
}