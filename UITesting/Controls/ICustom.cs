using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AutomationTest.UITesting.Controls
{
    public interface ICustom
    {
        void Click(int xCoordinate, int yCoordinate);
        void ContextClick(int xCoordinate, int yCoordinate);
        void DoubleClick(int xCoordinate, int yCoordinate);
        void MoveMouseTo(int xCoordinate, int yCoordinate);
        void MoveMouseByOffset(int xOffset, int yOffset);
    }
}
