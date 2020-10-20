using Calculator.Engine;
using Calculator.Engine.Interfaces;
using NUnit.Framework;
using System;
using System.Text;

namespace Calculator.Tests
{
    public class CalculatorEngineTests
    {
        IProvide<StringBuilder, string[]> operationsProvider;

        [SetUp]
        public void Setup()
        {
           operationsProvider= new TextProvider();
        }

        [Test]

        public void FileHasNoLines()
        {
            void CheckFileHasNoValues()
            {
                //Arrange
                string[] data = null;

                //Act
                operationsProvider.Provide(data);
            }

            //Assert
            Assert.Throws(typeof(NullReferenceException), CheckFileHasNoValues);
        }
    }
}