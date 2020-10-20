using Calculator.Engine;
using Calculator.Engine.Interfaces;
using System;
using System.IO;
using System.Text;
using FluentValidation;
using Calculator.Engine.Validator;
using Microsoft.Extensions.DependencyInjection;
using Calculator.Engine.Model;

namespace Calculator
{
    class Program
    {

        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            BuildService();

            IValidator<string[]> validator = _serviceProvider.GetService<IValidator<string[]>>();
            IProvide<object, string> evaluator = _serviceProvider.GetService<IProvide<object, string>>();
            IProvide<StringBuilder, string[]> instructiontoexpr = _serviceProvider.GetService<IProvide<StringBuilder, string[]>>();


            Console.WriteLine("Welcome to the calculator");
            Console.WriteLine("Please enter a fully qualified filename.");
            var fileDetail = Console.ReadLine();
            try
            {
                ReadFile(fileDetail, validator, evaluator, instructiontoexpr);
            }
            catch (Exception ex)
             {   Console.WriteLine(ex.Message); 
            }
        }

        private static void BuildService()
        {
            var serviceProvider = new ServiceCollection();
            serviceProvider.AddSingleton<IValidator<string[]>, CalculatorValidator>();
            serviceProvider.AddSingleton<IProvide<object, string>, EvalProvider>();
            serviceProvider.AddSingleton<IProvide<StringBuilder, string[]>, InstructionToExprProvider>();

            _serviceProvider = serviceProvider.BuildServiceProvider(true);
        }

        public static void ReadFile(string fileDetail, IValidator<string[]> validator, IProvide<object, string> evaluator, IProvide<StringBuilder, string[]> instructiontoexpr)
        {
            IProvide<CalculatorOutput, string[]> calculatorProvider = new CalculatorEngineProvider(validator, evaluator, instructiontoexpr);
            var file = File.ReadAllLinesAsync(fileDetail);
            var calcOutput = calculatorProvider.Provide(file.Result);

            Console.WriteLine(calcOutput.Explain);
        }
    }
}
