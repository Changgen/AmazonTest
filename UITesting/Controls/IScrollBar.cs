using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest.UITesting.Controls
{
    public interface IScrollBar
    {
        string Orientation { get; }
        void ScrollIntoView();
        void ScrollToTop();
        void ScrollToBottom();
    }
}
