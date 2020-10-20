using Calculator.Engine.Interfaces;
using FluentValidation;
using NUnit.Framework;
using System;
using System.Text;

namespace Calculator.Engine.Tests
{
    public class InstructionToExprTests
    {
        IProvide<StringBuilder, string[]> _instructionsToExpr;

        [SetUp]
        public void Setup()
        {   _instructionsToExpr = new InstructionToExprProvider();
        }

        [Test]
        public void InstrtoExprMissingOperation()
        {
            //Arrange
            string[] data = new string[] {
                "a 2",
                "multiply 3",
                };

            //Act
            var actual = _instructionsToExpr.Provide(data);
            //Assert
            Assert.AreEqual("*3", actual.ToString(), $"Expected *3, actual is {actual.ToString()}");
        }

        [Test]
        public void InstrtoExprMissingNumber()
        {
            //Arrange
            string[] data = new string[] {
                "add ",
                "multiply 3",
                };

            //Act
            var actual = _instructionsToExpr.Provide(data);
            //Assert
            Assert.AreEqual("*3", actual.ToString(), $"Expected *3, actual is {actual.ToString()}");
        }



        [Test]
        public void InstrtoExprExample01()
        {
            //Arrange
            string[] data = new string[] {
                "add 2",
                "multiply 3"
                };

            //Act
            var actual = _instructionsToExpr.Provide(data);
            //Assert
            Assert.AreEqual("+2*3",actual.ToString(),$"Expected +2*3, actual is {actual.ToString()}");
        }

        [Test]
        public void InstrtoExprWithApply()
        {
            //Arrange
            string[] data = new string[] {
                "add 2",
                "multiply 3",
                "apply 10"
                };

            //Act
            var actual = _instructionsToExpr.Provide(data);
            //Assert
            Assert.AreEqual("(10+2)*3", actual.ToString(), $"Expected (10+2)*3, actual is {actual.ToString()}");
        }

        [Test]
        public void InstrtoExprWithApplyExample02()
        {
            //Arrange
            string[] data = new string[] {
                "add 2500",
                "multiply 3",
                "apply 10"
                };

            //Act
            var actual = _instructionsToExpr.Provide(data);
            //Assert
            Assert.AreEqual("(10+2500)*3", actual.ToString(), $"Expected (10+2500)*3, actual is {actual.ToString()}");
        }

        [Test]
        public void InstrtoExprWithApplyExample03()
        {
            //Arrange
            string[] data = new string[] {
                "add -5",
                "multiply 30",
                "apply -1"
                };

            //Act
            var actual = _instructionsToExpr.Provide(data);
            //Assert
            Assert.AreEqual("(-1+-5)*30", actual.ToString(), $"Expected (-1+-5)*30, actual is {actual.ToString()}");
        }

        [Test]
        public void InstrtoExprWithApplyExample04()
        {
            //Arrange
            string[] data = new string[] {
                "add 5",
                "multiply 30",
                "apply -1"
                };

            //Act
            var actual = _instructionsToExpr.Provide(data);
            //Assert
            Assert.AreEqual("(-1+5)*30", actual.ToString(), $"Expected (-1+5)*30, actual is {actual.ToString()}");
        }

        [Test]
        public void InstrtoExprWithApplyExample05()
        {
            //Arrange
            string[] data = new string[] {
                "multiply 0",
                "add 1",
                "apply 1"
                };

            //Act
            var actual = _instructionsToExpr.Provide(data);
            //Assert
            Assert.AreEqual("(1*0)+1", actual.ToString(), $"Expected (1*0)+1, actual is {actual.ToString()}");
        }
    }
}