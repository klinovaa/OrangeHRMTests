using OrangeHRM.PageObjects.Admin;
using OrangeHRM.PageObjects.Admin.Job;
using OrangeHRM.PageObjects.Admin.UserManagement;
using OrangeHRM.PageObjects.Login;

namespace OrangeHRM.PageObjects
{
    public class GenericPages
    {
        public static LoginPage LoginPage => GetPage<LoginPage>();
        public static UsersPage UsersPage => GetPage<UsersPage>();
        public static AddUserPage AddUserPage => GetPage<AddUserPage>();
        public static AdminNavigationPage AdminNavigationPage => GetPage<AdminNavigationPage>();
        public static JobTitlesPage JobTitlesPage => GetPage<JobTitlesPage>();
        public static AddJobTitlePage AddJobTitlePage => GetPage<AddJobTitlePage>();

        private static T GetPage<T>() where T : new() => new T();
    }
}
