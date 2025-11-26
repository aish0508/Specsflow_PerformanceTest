using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2.AssertHelpers
{
    public class ChangePasswordAssertHelper
    {
        public static void assertEmptyScenarioMessage(String expected, string actual)
        {
            
            Assert.That("Please fill all the details before Submit" == actual, "Actual message and expected message do not match");

        }
        public static void assertChangePasswordSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }
        public static void assertVerificationOfWrongPasswordMessage(string expected, string actual)
        {
            Assert.That("Current Password and New Password should not be same" == actual, "Actual message and expected message do not match");
        }
        public static void assertVerificationOfPasswordDoNotMatch(string expected, string actual)
        {
            Assert.That("Passwords does not match" == actual, "Actual message and expected message do not match");
        }
    }
}
