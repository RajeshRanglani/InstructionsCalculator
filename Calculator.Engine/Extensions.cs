using System.Text;
using System.Text.RegularExpressions;

namespace Calculator.Engine
{
    public static class Extensions
    {
        public static string ExtractNumberfromString(this string sData)
        {
            var resultString = Regex.Match(sData, @"-?\d+").Value;
            if (string.IsNullOrEmpty(resultString)) return "";
            return resultString;
        }

        public static void TransformStringToIncludeParentheses(this StringBuilder sData)
        {
            var matches = Regex.Matches(sData.ToString(), @"-?\d+");
            if (matches.Count > 0)
            {
                sData.Insert(matches[0].Index, "(");
                sData.Insert(matches[1].Index + matches[1].Length+1, ")");
            }
        }

        public static bool IsMatchOperationInLine(this string sData, string operation)
        {   return Regex.IsMatch(sData, $@"^\b{operation}\b");
        }

    }
}
