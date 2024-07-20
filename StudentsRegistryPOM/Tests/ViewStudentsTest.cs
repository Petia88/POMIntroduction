using StudentsRegistryPOM.Pages;

namespace StudentsRegistryPOM.Tests
{
    public class ViewStudentsTest : BaseTest
    {
        [Test]
        public void Test_ViewStudentsPage_Content()
        {
            ViewStudentsPage viewStudentsPage = new ViewStudentsPage(driver);
            viewStudentsPage.Open();

            Assert.Multiple(() =>
            {
                Assert.That(viewStudentsPage.GetPageTitle(), Is.EqualTo("Students"));
                Assert.That(viewStudentsPage.GetPageHeadingText(), Is.EqualTo("Registered Students"));
            });
 
            var students = viewStudentsPage.GetRegisterStudents();

            foreach (var student in students)
            {
                Assert.That(student.Contains("("), Is.True);
                Assert.That(student.LastIndexOf(")") == student.Length -1, Is.True);
            }
        }

        [Test]
        public void Test_ViewStudentsPage_Links()
        {
            var viewStudentsPage = new ViewStudentsPage(driver);
            viewStudentsPage.Open();
            viewStudentsPage.HomeLink.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            viewStudentsPage.Open();
            viewStudentsPage.LinkAddStudentsPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());

            viewStudentsPage.Open();
            viewStudentsPage.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
        }
    }
}
