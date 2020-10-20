using Calculator.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.Engine
{
    public class InstructionToExprProvider : IProvide<StringBuilder, string[]>
    {
        private const string apply = "apply";
        
        public StringBuilder Provide(string[] data)
        {
            var strData = new StringBuilder();
            var insertParentheses = false;
            foreach (var line in data)
            {
                var oper = Operators.Operations.FirstOrDefault(a => line.IsMatchOperationInLine(a.Key));
                if ((oper.Key is null) || (string.IsNullOrEmpty(line.ExtractNumberfromString()))) continue;

                if (line.IsMatchOperationInLine(apply))
                {   strData.Insert(0, line.ExtractNumberfromString());
                    insertParentheses = true;
                }
                else
                {   strData.Append(oper.Value);
                    strData.Append(line.ExtractNumberfromString());
                }
            }

            if (insertParentheses) strData.TransformStringToIncludeParentheses();
            return strData;
        }
    }
}
