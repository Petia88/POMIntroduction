using OpenQA.Selenium;

namespace CalculatorPOM
{
  
    public class SumNumberPage
    {
        private readonly IWebDriver driver;
        public SumNumberPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public const string PageUrl = "https://5e52e3c2-a0f5-446c-9d70-eb977d1c379a-00-9d7sroqjuocd.janeway.replit.dev/";

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }

        public void ResetForm()
        {
            ButtonReset.Click();
        }

        public bool IsFormEmpty()
        {
            return FieldNum1.Text + FieldNum2.Text + ElementResult.Text == "";
        }

        public string AddNumbers(string number1, string number2)
        {
            FieldNum1.SendKeys(number1);
            FieldNum2.SendKeys(number2);
            ButtonCalc.Click();

            return ElementResult.Text;
        }

        public IWebElement FieldNum1 => driver.FindElement(By.CssSelector("input#number1"));
        public IWebElement FieldNum2 => driver.FindElement(By.CssSelector("input#number2"));
        public IWebElement ButtonCalc => driver.FindElement(By.CssSelector("input#calcButton"));
        public IWebElement ButtonReset => driver.FindElement(By.CssSelector("input#resetButton"));
        public IWebElement ElementResult => driver.FindElement(By.CssSelector("#result"));


    }
}
