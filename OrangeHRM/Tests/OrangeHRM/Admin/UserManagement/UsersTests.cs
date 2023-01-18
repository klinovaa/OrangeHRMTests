using Allure.Net.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OrangeHRM.Data;
using OrangeHRM.Data.Constants;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests.OrangeHRM.Admin.UserManagement
{
    [AllureNUnit]
    [AllureSuite("Admin > User Management > Users")]
    public class UsersTests : BaseTest
    {
        public UsersTests() : base(TestSettings.HomePageUrl)
        {
        }

        [SetUp]
        public void SetUpForUsersTests()
        {
            GenericPages.UsersPage.NavigateToCategory(MainMenuCategories.Admin);
        }

        [Test]
        [AllureEpic("Tests for user functionality")]
        [AllureName("User Records that are found")]
        [AllureSeverity(SeverityLevel.normal)]
        public void CompareAmountOfAllRows()
        {
            var countedRows = GenericPages.UsersPage.CountAllRows();
            var countedRowsWithText = $"({countedRows})";

            var allRecordsText = GenericPages.UsersPage.GetRecordsFoundText();
            Assert.AreEqual(allRecordsText, countedRowsWithText + Common.RecordsFoundText);
        }

        [Test]
        [AllureEpic("Tests for user functionality")]
        [AllureName("Add new user")]
        [AllureSeverity(SeverityLevel.critical)]
        public void AddNewAdminUser()
        {
            GenericPages.UsersPage.ClickAddButton();
            GenericPages.AddUserPage.SelectUserRole(AddUser.AdminOption);
            GenericPages.AddUserPage.EnterEmployeeName(AddUser.LetterAText);
            GenericPages.AddUserPage.SelectStatus(AddUser.EnabledOption);
            GenericPages.AddUserPage.EnterUsername(AddUser.UsernameText);
            GenericPages.AddUserPage.EnterPassword(AddUser.PasswordText);
            GenericPages.AddUserPage.EnterConfirmPassword(AddUser.PasswordText);
            Thread.Sleep(4000);//TODO change it later
            GenericPages.AddUserPage.ClickSaveButton();

            var actualUserNameValues = new List<string>();
            GenericPages.UsersPage.AddAllRowsUsernameTextToList(actualUserNameValues);

            Assert.IsTrue(actualUserNameValues.Contains(AddUser.UsernameText));
        }

        [Test]
        [AllureEpic("Tests for user functionality")]
        [AllureName("Edit appropriate user")]
        [AllureSeverity(SeverityLevel.critical)]
        public void EditUsername()
        {
            GenericPages.UsersPage.ClickAddButton();
            GenericPages.AddUserPage.SelectUserRole(AddUser.AdminOption);
            GenericPages.AddUserPage.EnterEmployeeName(AddUser.LetterAText);
            GenericPages.AddUserPage.SelectStatus(AddUser.EnabledOption);
            GenericPages.AddUserPage.EnterUsername(AddUser.NewUsernameText);
            GenericPages.AddUserPage.EnterPassword(AddUser.PasswordText);
            GenericPages.AddUserPage.EnterConfirmPassword(AddUser.PasswordText);
            Thread.Sleep(4000); //TODO change it later
            GenericPages.AddUserPage.ClickSaveButton();

            GenericPages.UsersPage.EditAppropriateUser(AddUser.NewUsernameText);
            GenericPages.AddUserPage.EnterUsername(AddUser.EditedText);
            Thread.Sleep(4000); //TODO change it later
            GenericPages.AddUserPage.ClickSaveButton();

            var usernamesAfterEditing = new List<string>();
            GenericPages.UsersPage.AddAllRowsUsernameTextToList(usernamesAfterEditing);

            Assert.IsTrue(usernamesAfterEditing.Contains(AddUser.NewUsernameText + AddUser.EditedText));
        }

        [Test]
        [AllureEpic("Tests for user functionality")]
        [AllureName("Delete user")]
        [AllureSeverity(SeverityLevel.critical)]
        public void DeleteUser()
        {
            var countedRows = GenericPages.UsersPage.CountAllRows();
            var deletedUsername = GenericPages.UsersPage.GetLastRawUsername();
            GenericPages.UsersPage.DeleteLastElement();
            var countedRowsAfterDeletion = GenericPages.UsersPage.CountAllRows();
            Assert.AreEqual(countedRows - 1, countedRowsAfterDeletion);

            var usersRowsAfterDeletion = new List<string>();
            GenericPages.UsersPage.AddAllRowsUsernameTextToList(usersRowsAfterDeletion);

            Assert.IsFalse(usersRowsAfterDeletion.Contains(deletedUsername));
        }

        [Test]
        [AllureEpic("Tests for user functionality")]
        [AllureName("Search user by username")]
        [AllureSeverity(SeverityLevel.normal)]
        public void SearchByUserName()
        {
            var usernameText = GenericPages.UsersPage.GetLastRawUsername();
            GenericPages.UsersPage.EnterTextInUserNameField(usernameText);
            GenericPages.UsersPage.SearchForUser();

            var actualValues = new List<string>();
            GenericPages.UsersPage.AddAllRowsUsernameTextToList(actualValues);

            foreach (var row in actualValues)
            {
                Assert.AreEqual(usernameText, row.ToString());
            }
        }

        [Test]
        [AllureEpic("Tests for user functionality")]
        [AllureName("Search user by status")]
        [AllureSeverity(SeverityLevel.normal)]
        public void SearchByStatus()
        {
            GenericPages.UsersPage.SelectStatus(AddUser.EnabledOption);
            GenericPages.UsersPage.SearchForUser();

            var actualValues = new List<string>();
            GenericPages.UsersPage.AddAllRowsStatusTextToList(actualValues);

            foreach (var row in actualValues)
            {
                Assert.AreEqual(AddUser.EnabledOption, row);
            }
        }

        [Test]
        [AllureEpic("Tests for user functionality")]
        [AllureName("Search user by user role")]
        [AllureSeverity(SeverityLevel.normal)]
        public void SearchByUserRole()
        {
            GenericPages.UsersPage.SelectUserRole(AddUser.AdminOption);
            GenericPages.UsersPage.SearchForUser();

            var actualValues = new List<string>();
            GenericPages.UsersPage.AddAllRowsUserRolesTextToList(actualValues);

            foreach (var row in actualValues)
            {
                //specially failed test. Should be AddUser.AdminOption instead of AddUser.EssOption
                Assert.AreEqual(AddUser.EssOption, row.ToString());
            }
        }

        [Test]
        [AllureEpic("Tests for user functionality")]
        [AllureName("Search user by employee name")]
        [AllureSeverity(SeverityLevel.normal)]
        [Ignore("Ignored test")]
        public void SearchByEmployeeName()
        {
        }
    }
}
