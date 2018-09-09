using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationTest.UITesting.Controls;

namespace AmazonTest.Objects
{
    public class SignInPage : ApplicationBase 
    {
        public HtmlTextField TxtEmail
        {
            get
            {
                ILocator locator = new Locator("//input[@name='email']");
                return new HtmlTextField(locator);
            }
        }

        public HtmlTextField TxtYourName
        {
            get
            {
                ILocator locator = new Locator("//input[@name='customerName']");
                return new HtmlTextField(locator);
            }
        }

        public HtmlTextField TxtPassword
        {
            get
            {
                ILocator locator = new Locator("//input[@name='password']");
                return new HtmlTextField(locator);
            }
        }

        public HtmlTextField TxtReEnterPassword
        {
            get
            {
                ILocator locator = new Locator("//input[@name='passwordCheck']");
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

        public HtmlButton BtnCreateAccount
        {
            get
            {
                ILocator locator = new Locator("//*[contains(text(),'Create your Amazon account')]");
                return new HtmlButton(locator);
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
                Locator locator = new Locator("//span[contains(text(),'We cannot find an account with that email']");
                return new HtmlSpan(locator);
            }
        }
        #endregion

        public void SignIn(string account, string password)
        {
            this.TxtEmail.InputText(account);
            this.BtnContinue.Click();
        }

        public void CreateAmazonAccount(string name, string email, string password)
        {
            this.BtnCreateAccount.Click();
            this.TxtYourName.InputText(name);
            this.TxtEmail.InputText(email);
            this.TxtPassword.InputText(password);
            this.TxtReEnterPassword.InputText(password);
            this.BtnCreateAccount.Click();
        }


        public void GoBackToHome()
        {
            this.Back();
            this.Back();
        }
    }
}
