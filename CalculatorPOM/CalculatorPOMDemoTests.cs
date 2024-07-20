using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CalculatorPOM
{
    public class Tests
    {
        public IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void Test_AddTwoNumbers_ValidInput()
        {
            var calculatorPage = new SumNumberPage(driver);
            calculatorPage.OpenPage();

            string result = calculatorPage.AddNumbers("1", "2");

            Assert.AreEqual("Sum: 3", result);

            calculatorPage.ResetForm();
        }

        [Test]
        public void Test_AddTwoNumbers_InValidInput()
        {
            var calculatorPage = new SumNumberPage(driver);
            calculatorPage.OpenPage();

            string result = calculatorPage.AddNumbers("Hello", "world");

            Assert.AreEqual("Sum: invalid input", result);

            calculatorPage.ResetForm();
        }

        [Test]
        public void Test_FormReset()
        {
            var calculatorPage = new SumNumberPage(driver);
            calculatorPage.OpenPage();

            string result = calculatorPage.AddNumbers("1", "2");

            Assert.AreEqual("Sum: 3", result);

            calculatorPage.ResetForm();

            Assert.True(calculatorPage.IsFormEmpty());
        }
    }
}