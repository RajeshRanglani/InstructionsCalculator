using Calculator.Engine.Interfaces;
using System;
using System.Data;

namespace Calculator.Engine
{
    public class EvalProvider : IProvide<object,string>
    {
        public object Provide(string expression)
        {
            object output = null;
            try
            {   if (string.IsNullOrWhiteSpace(expression))
                    return output;

                output = new DataTable().Compute(expression, string.Empty);
            }
            catch (Exception)
            {   
            }
            return output;
        }

        public object Provide<T>(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return default(T);
            return (T)Convert.ChangeType(Provide(data), typeof(T));
        }
    }
}
