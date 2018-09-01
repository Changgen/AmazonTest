using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest.UITesting.Controls
{
    public abstract class ApplicationBase : HtmlDriverContext
    {
        protected string url;

        public ApplicationBase()
        {
            this.waitTimeout = GlobalSettings.Config.ApplicationActiveTimeout;
        }

        public ApplicationBase(string url) 
            : this()
        {
            this.url = url;
            GoToUrl(url);
        }
    }
}
