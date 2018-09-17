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
            //homepage.ExpandDepartments();
            homepage.MoveMouseTo("//span[text()='Account & Lists']");
            Verify.That(() => Assert.AreEqual(1, 2), "Verify 1 = 2 ", DriverContext.TakeSnapshot("Exception"));
            Verify.That(() => Assert.AreEqual(1, 2), "Verify 1 = 2", TakeScreenshot("Exception2"));

            homepage.ExpandTryPrime();
            homepage.ExpandAccountLists();
            homepage.DivAccountLists.TextClick("Your Account");
            homepage.DivAccountLists.SpnYourAccount.Click();
            //homepage.MoveMouseTo("//span[text()='Departments']");

            SignInPage signinPage = homepage.GoToSignInPage();

            signinPage.SignIn("changgen.peng@yahoo.com", "123");

            Verify.IsTrue(signinPage.SpnProblemExistWarning.Exist());
            Verify.IsTrue(signinPage.SpnNotFindAccountError.Exist());

            signinPage.CreateAmazonAccount("Paul34", "changgen.peng@yahoo.com", "123");

            signinPage.GoBackToHome();
            homepage.TxtSearch.InputText("Clark");
            homepage.BtnGo.Click();
            homepage.CmbSortBy.Select("Newest Arrivals");
            
            Verify.AreEqual(1, 1);
            Verify.AreEqual(1, 1);
            Verify.IsTrue(true);
        }
    }
}
