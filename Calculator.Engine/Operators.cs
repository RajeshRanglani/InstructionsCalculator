using System.Collections.Generic;

namespace Calculator.Engine
{
    public static class Operators
    {
        public static Dictionary<string, string> Operations = new Dictionary<string, string>()
        {   {"add","+"},
            {"subtract","-" },
            {"multiply","*"},
            {"divide","/" },
            {"apply","" }
        };
    }
}
