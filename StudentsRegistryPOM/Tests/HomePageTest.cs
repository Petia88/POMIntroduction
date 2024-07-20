using StudentsRegistryPOM.Pages;

namespace StudentsRegistryPOM.Tests
{
    public class HomePageTest : BaseTest
    {
        [Test]
        public void Test_HomePage_Content()
        {
            HomePage homePage = new HomePage(driver);
            homePage.Open();

            Assert.Multiple(() =>
            {
                Assert.That(homePage.GetPageTitle(), Is.EqualTo("MVC Example"));
                Assert.That(homePage.GetPageHeadingText(), Is.EqualTo("Students Registry"));
            });

            Assert.True(homePage.StudentsCount() > 0);
        }

        [Test]
        public void Test_Home_page_Links()
        {
            var homePage = new HomePage(driver);
            homePage.Open();
            homePage.HomeLink.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            homePage.Open();
            homePage.LinkAddStudentsPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());

            homePage.Open();
            homePage.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
        }
    }
}
