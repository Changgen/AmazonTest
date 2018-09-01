using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationTest.Generic;
using AutomationTest.Generic.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomationTest.UITesting.Controls;
using AutomationTest.Generic.Asserts;
using AutomationTest.UITesting;
using AmazonTest.Objects;

namespace AmazonTest.TestCase
{
    [TestClass]
    public class SmokeTest : ProjectTestBase  
    {        
        public void Setup()
        {
            Initialize();
        }

        public void Terminate()
        {
            Cleanup();
        }

        [TestMethod]
        [TestCase("VSTS000001")]
        [Headline("Somke Test")]
        public void VSTS000001()
        {
            Steps(1, "Go to Amazon home page");
            HomePage homepage = new HomePage();
            //homepage.TxtSearch.InputText("Clark");
            //homepage.BtnGo.Click();
            //homepage.CmbSortBy.Select("Newest Arrivals");
        }

        [TestMethod]
        [TestCase("VSTS000001")]
        [Headline("Somke Test")]
        public void VSTS000002()
        {
            Steps(1, "Go to Amazon home page");
            HomePage homepage = new HomePage();
            //homepage.TxtSearch.InputText("Clark");
            //homepage.BtnGo.Click();
            //homepage.CmbSortBy.Select("Newest Arrivals");
            Verify.AreEqual(1, 2);
            Verify.AreEqual(1, 1);
            Verify.IsTrue(false);
        }

        [TestMethod]
        [TestCase("VSTS000001")]
        [Headline("Somke Test")]
        public void VSTS000003()
        {
            Steps(1, "Go to Amazon home page");
            HomePage homepage = new HomePage();
            homepage.TxtSearch.InputText("Clark");
            homepage.BtnGo.Click();
            homepage.CmbSortBy.Select("Newest Arrivals");
            Verify.AreEqual(1, 1);
            Verify.AreEqual(1, 1);
            Verify.IsTrue(true);
        }
    }
}
