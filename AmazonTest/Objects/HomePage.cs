using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationTest.UITesting.Controls;
using AutomationTest.UITesting;

namespace AmazonTest.Objects
{
    public class HomePage : ApplicationBase
    {
        private readonly static string homepageUrl = GlobalSetting.Config.Url;  

        public HomePage()
            : base(homepageUrl)
        {
        }

        #region MainMenu
        public HtmlTextField TxtSearch
        {
            get
            {
                ILocator locator = new Locator(LocateMethod.CssSelector, "input[id='twotabsearchtextbox']");
                return new HtmlTextField(locator);
            }
        }

        public HtmlButton BtnGo
        {
            get
            {
                ILocator locator = new Locator(LocateMethod.CssSelector, "input[value='Go']");
                return new HtmlButton(locator);
            }
        }

        public HtmlSpan SpnDepartments
        {
            get
            {
                ILocator locator = new Locator("//span[text()='Departments']");
                return new HtmlSpan(locator);
            }
        }

        public HtmlSpan SpnAccountLists
        {
            get
            {
                ILocator locator = new Locator("//span[text()='Account & Lists']");
                return new HtmlSpan(locator);
            }
        }

        public HtmlSpan SpnTryPrime
        {
            get
            {
                ILocator locator = new Locator("//span[text()='Try Prime']");
                return new HtmlSpan(locator);
            }
        }

        public HtmlHyperLink HlkSignIn
        {
            get
            {
                ILocator locator = new Locator("//a[text()='Your Amazon.com']");
                return new HtmlHyperLink(locator);
            }
        }

        public AccountListsDiv DivAccountLists
        {
            get { return new AccountListsDiv(); }
        }
        #endregion

        #region Sign In page
        public HtmlTextField TxtEmail
        {
            get
            {
                ILocator locator = new Locator("//input[@name='email']");
                return new HtmlTextField(locator);
            }

        }

        public HtmlButton BtnContinue
        {
            get
            {
                ILocator locator = new Locator("//input[@id='continue']");
                return new HtmlButton(locator);
            }
        }
        #endregion

        public HtmlComboBox CmbSortBy
        {
            get
            {
                ILocator locator = new Locator(LocateMethod.CssSelector, "select[id='sort'][name='sort']");
                return new HtmlComboBox(locator);
            }
        }

        #region Warning
        public HtmlSpan SpnProblemExistWarning
        {
            get
            {
                Locator locator = new Locator("//h4[text()='There was a problem']");
                return new HtmlSpan(locator);
            }
        }

        public HtmlSpan SpnNotFindAccountError
        {
            get
            {
                Locator locator = new Locator("//span[text()='We cannot find an account with that email address']");
                return new HtmlSpan(locator);
            }
        }
        #endregion

        #region Scenario
        public void ExpandDepartments()
        {
            MoveMouseTo(this.SpnDepartments);
        }

        public void ExpandAccountLists()
        {
            MoveMouseTo(this.SpnAccountLists);
        }

        public void ExpandTryPrime()
        {
            MoveMouseTo(this.SpnTryPrime);
        }

        public SignInPage GoToSignInPage()
        {
            this.HlkSignIn.Click();
            return new SignInPage();
        }

        public void SignIn(string account, string password)
        {
            this.HlkSignIn.Click();
            this.TxtEmail.InputText(account);
            this.BtnContinue.Click();
        }
        #endregion
    }
}
