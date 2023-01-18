using NUnit.Framework;

namespace OrangeHRM.Data
{
    //class to get values from TestContext
    public class TestContextValues
    {
        public static string ExecutableClassName => TestContext.CurrentContext.Test.ClassName;
    }
}
