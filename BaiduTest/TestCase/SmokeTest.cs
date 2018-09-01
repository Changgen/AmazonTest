using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AutomationTest.UITesting;
using BaiduTest.Objects;

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
        }
    }
}
