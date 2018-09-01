using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest.UITesting.Controls
{
    public interface ILocator
    {
        LocateMethod Method { get; }
        string Value { get; }
    }
}
