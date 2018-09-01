using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AutomationTest.UITesting.Controls
{
    /// <summary>
    /// Provide interface for driver context.
    /// </summary>
    public interface IDriverContext
    {
        string Title { get; }
        string CurrentWindowHandle { get; }
        Rectangle Rectangle { get; }

        bool Exist();
        bool Exist(int timeout);
        void SetActive();
        void SetActive(int timeout);
        void Maximize();
        void Minimize();
        void Close();
        void Click(Point coordinate);
        //void Click(IControl control);
        void ContextClick(Point coordinate);
        //void ContextClick(IControl control);
        void DoubleClick(Point coordinate);
        //void DoubleClick(IControl control);
        void MoveMouseTo(Point coordinate);
        void MoveMouseByOffset(int xOffset, int yOffset);
        void DragAndDropTo();
        void DragAndDropByOffset();
    }
}
