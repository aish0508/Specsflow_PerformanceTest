using AdvancedTaskPart2.Utilities;
using OpenQA.Selenium;
using AdvancedTaskPart2.Hooks;
namespace AdvancedTaskPart2.Pages.SignIn
{
    public class SignIn : CommonDriver

    {
        private IWebElement SignInButton;

        public void renderSignIn()
        {
            try
            {
                
                Wait.WaitToBeClickable(dr, "XPath", "//div[@id='home']/div/div/div/div/a", 4);
                SignInButton = dr.FindElement(By.XPath("//div[@id='home']/div/div/div/div/a"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickSignInButton()
        {
            //InitializeWebDriver();
            renderSignIn();
            SignInButton.Click();
        }
    }
}
