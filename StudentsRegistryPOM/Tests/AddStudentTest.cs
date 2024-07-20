using StudentsRegistryPOM.Pages;

namespace StudentsRegistryPOM.Tests
{
    public class AddStudentTest : BaseTest
    {
        [Test]
        public void Test_TestAddStudentPage_Content()
        {
            AddStudentPage addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();

            Assert.Multiple(() =>
            {
                Assert.That(addStudentPage.GetPageTitle(), Is.EqualTo("Add Student"));
                Assert.That(addStudentPage.GetPageHeadingText(), Is.EqualTo("Register New Student"));
            });

            Assert.That(addStudentPage.FieldEmail.Text, Is.EqualTo(""));
            Assert.That(addStudentPage.FieldName.Text, Is.EqualTo(""));
            Assert.That(addStudentPage.AddButton.Text, Is.EqualTo("Add"));
        }

        [Test]
        public void Test_TestAddStudentPage_Links()
        {
            var addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();
            addStudentPage.HomeLink.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            addStudentPage.Open();
            addStudentPage.LinkAddStudentsPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());

            addStudentPage.Open();
            addStudentPage.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
        }

        [Test]
        public void Test_TestAddStudentPage_AddValidStudent()
        {
            AddStudentPage addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();

            string name = GenerateRandomName();
            string email = GenerateRandomEmail(name);

            addStudentPage.AddStudent(name, email);

            ViewStudentsPage viewSudentsPage = new ViewStudentsPage(driver);
            Assert.That(viewSudentsPage.IsOpen(), Is.True);

            var students = viewSudentsPage.GetRegisterStudents();
            string newStudentFullString = name + " (" + email + ")";

            Assert.True(students.Contains(newStudentFullString));

        }

        [Test]
        public void Test_TestAddStudentPage_AddInvalidStudent()
        {
            AddStudentPage addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();

            addStudentPage.AddStudent("", "petar@gmail.com");

            Assert.That(addStudentPage.IsOpen(), Is.True);
            Assert.That(addStudentPage.GetErrorMessage(), Is.EqualTo("Cannot add student. Name and email fields are required!"));

        }

        private string GenerateRandomName()
        {
            var random = new Random();
            string[] names = { "Ivan", "Petar", "Aleksandra", "Ivaila" };

            return names[random.Next(names.Length)] + random.Next(999, 9999).ToString();
        }

        private string GenerateRandomEmail(string name)
        {
            var random = new Random();

            return name.ToLower() + random.Next(999, 9999).ToString() + "@gmail.com";
        }
    }
}
