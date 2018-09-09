using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenQA.Selenium;

namespace AutomationTest.UITesting.Controls
{
    /// <summary>
    /// Provide interface for UI control.
    /// </summary>
    public interface IControl<T> where T : IWebElement
    {
        ILocator Locator { get; }
        T Element { get; }
        Point Location { get; }
        Size Size { get; }
        Rectangle Rectangle { get; }

        bool Exist();
        bool Exist(int timeout);
        T FindElementEx(ILocator locator);

    }
}
