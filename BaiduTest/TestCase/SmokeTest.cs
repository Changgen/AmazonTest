using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AutomationTest.UITesting;
using BaiduTest.Objects;
using AutomationTest.Generic.Utils;
using AutomationTest.UITesting.Controls;
using OpenQA.Selenium;


namespace BaiduTest.TestCase
{
    [TestFixture]
    public class SmokeTest : ProjectTestBase 
    {
        protected HomePage homepage;

        [SetUp]
        public override void Initialize()
        {
            base.Initialize();
            this.homepage = new HomePage();         
        }

        [Test]
        [Description("Test search function for baidu")]
        [TestCase("Aspen")]
        [TestCase("KBC")]
        [TestCase("Proii")]
        public void VSTS000002(string content)
        {

            homepage.TxtSearch.InputText(content);
            homepage.BtnGo.Click();
            
        }

        [Description("Test search function for baidu")]
        [TestCase("Aspen")]
        [TestCase("KBC")]
        [TestCase("Proii")]
        public void VSTS000003(string content)
        {

            homepage.TxtSearch.InputText(content);
            homepage.BtnGo.Click();
            Log.Trace("current windowhandle =>" + homepage.WindowHandle);

            BaiduSearchPage baiduSearchPage = new BaiduSearchPage();
            baiduSearchPage.hlkImage.Click();
            baiduSearchPage.Refresh();

            HomePage baiduHomepage = new HomePage();
            baiduHomepage.TxtSearch.InputText("123");

            baiduSearchPage.SetActive();
            baiduSearchPage.Back();
            baiduSearchPage.TxtSearch.InputText("???");
            baiduSearchPage.BtnGo.Click();
            baiduSearchPage.Exit();

            baiduHomepage.SetActive();
            baiduHomepage.TxtSearch.InputText("234");

            HomePage baiduHomepage2 = new HomePage();
            baiduHomepage2.TxtSearch.InputText("xxx");

            baiduHomepage.SetActive();
            baiduHomepage.FindElement(new Locator(LocateMethod.CssSelector, "")).Click();
            baiduHomepage.Minimize();
            

        }
    }
}
