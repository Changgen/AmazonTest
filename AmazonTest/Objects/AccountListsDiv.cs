using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationTest.UITesting.Controls;

namespace AmazonTest.Objects
{
    public class AccountListsDiv : HtmlDiv
    {
        private static ILocator locator = new Locator(LocateMethod.CssSelector, "div[id='nav-al-container']");

        public AccountListsDiv()
            : base(locator)
        {
        }

        #region Sign in
        public HtmlButton BtnSignIn
        {
            get
            {
                ILocator locator = new Locator("//span[text()='Sign in']");
                return new HtmlButton(locator);
            }
        }
        #endregion

        #region Account
        public HtmlSpan SpnYourAccount  
        {
            get
            {
                ILocator locator = new Locator("//span[text()='Your Account']");
                return new HtmlSpan(locator);
            }
        }

        public HtmlSpan SpnYourOrders
        {
            get
            {
                ILocator locator = new Locator("//span[text()='Your Orders']");
                return new HtmlSpan(locator);
            }
        }

        public HtmlSpan SpnYourLists
        {
            get
            {
                ILocator locator = new Locator("//span[text()='Your Lists']");
                return new HtmlSpan(locator);
            }
        }
        #endregion

        #region Lists
        public HtmlSpan SpnCreateList
        {
            get
            {
                ILocator locator = new Locator("//span[text()='Create a List']");
                return new HtmlSpan(locator);
            }
        }

        public HtmlSpan SpnFindGift
        {
            get
            {
                ILocator locator = new Locator("//span[text()='Find a Gift']");
                return new HtmlSpan(locator);
            }
        }
        #endregion
    }
}
