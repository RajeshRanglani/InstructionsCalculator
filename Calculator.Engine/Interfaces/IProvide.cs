using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Engine.Interfaces
{
    public interface IProvide<U,V>
    {
        public U Provide(V data);

    }
}
