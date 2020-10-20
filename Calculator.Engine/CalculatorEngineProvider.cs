using Calculator.Engine.Interfaces;
using Calculator.Engine.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.Engine
{
    public class CalculatorEngineProvider : IProvide<CalculatorOutput, string[]>
    {

        private readonly IValidator<string[]> _validator;
        private readonly IProvide<object,string> _evaluator;
        private readonly IProvide<StringBuilder, string[]> _instructionToExpr;

        public CalculatorEngineProvider(IValidator<string[]> validator, IProvide<object, string> evaluator, IProvide<StringBuilder, string[]> instructionToExpr)
        {
            _validator = validator;
            _evaluator = evaluator;
            _instructionToExpr = instructionToExpr;
        }

        public CalculatorOutput Provide(string[] data)
        {
            if (data is null) throw new NullReferenceException("The file contains no data");
            _validator.ValidateAndThrow(data);
            var sbData = _instructionToExpr.Provide(data);
            var outputEval = _evaluator.Provide(sbData.ToString());

            return new CalculatorOutput() {Expression=sbData.ToString(), Output= outputEval,Explain=$"{sbData.ToString()}={outputEval?.ToString()}" };

        }
    }
}
