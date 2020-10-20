using FluentValidation;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator.Engine.Validator
{
    public class CalculatorValidator :AbstractValidator<string[]>
    {
           private const string apply = "apply";
           public CalculatorValidator()
           {
                RuleFor(v => v).Must(NotEmpty).WithMessage("The file does not contain any instructions.");
                RuleFor(v => v).Must(ContainsApplyOperation).WithMessage("The file does not contain the apply operation.");
                RuleForEach(v => v).Must(ContainsAnOperationPerLine).WithMessage("Operation missing at line {CollectionIndex}.");
                RuleForEach(v => v).Must(ContainsASingleOperationPerLine).WithMessage("More than one operation at line {CollectionIndex}.");

            }

        private bool NotEmpty(string[] arg)
        {
            return arg.Length>0;
        }


        private bool ContainsApplyOperation(string[] arg)
        {   return arg.Any(a => a.IsMatchOperationInLine(apply));
        }

        private bool ContainsAnOperationPerLine(string arg)
        {
            return Operators.Operations.Any(oper => arg.IsMatchOperationInLine(oper.Value));
        }

        private bool ContainsASingleOperationPerLine(string arg)
        {
            return Operators.Operations.Any(oper => Regex.Matches(arg, $@"^\b{oper.Value}\b").Count()<=1);
        }

    }
}
