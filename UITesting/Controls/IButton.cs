using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest.UITesting.Controls
{
    public interface IButton
    {
        bool Enabled { get; }
        void Click();
        void Click(int xCoordinate, int yCoordinate);
        void DoubleClick();
        void DoubleClick(int xCoordinate, int yCoordinate);
    }
}
