using Microsoft.Extensions.Configuration;
using OrangeHRM.Data.Enums;

namespace OrangeHRM.Data
{
    //to make it parallelizable you have to remove static
    public static class TestSettings
    {
        public static Browsers Browser { get; set; }

        public static string HomePageUrl { get; set; }

        public static string Username { get; set; }

        public static string Password { get; set; }

        //after Built() it will contain context of our .json file
        public static IConfiguration TestConfiguration { get; } = new ConfigurationBuilder().AddJsonFile("testsettings.json").Build();

        static TestSettings()
        {
            //easy way to get values from .json file by keys like these
            Enum.TryParse(TestConfiguration["Common:Browser"], out Browsers browser);
            Browser = browser;
            HomePageUrl = TestConfiguration["Common:URLs:Home"];
            Username = TestConfiguration["Common:TestData:Username"];
            Password = TestConfiguration["Common:TestData:Password"];
        }
    }
}
