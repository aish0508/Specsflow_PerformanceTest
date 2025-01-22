using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2.AssertHelpers
{
    public class EducationAssertHelper
    {
        public static void assertEmptyScenarioAlertMessage(String expected , String actual)
        {
            Assert.That("Please enter all the fields" == actual, "Actual message and expected message do not match");
        }
        public static void assertAddEducationSuccessMessage(String expected, String actual)
        {
            Assert.That("Education has been added" == actual, "Actual message and expected message do not match");
        }
        public static void assertDeleteEducationSuccessMessage(string expected, String actual)
        {
            Assert.That("Education entry successfully removed" == actual, "Actual message and expected message do not match");

        }
        public static void assertExitsAlreadyAddedEducation(String expected, String actual)
        {
            Assert.That("This information is already exist." == actual, "Actual message and expected message do not match");
        }
        public static void assertAddSpecialCharacters(String expected, String actual)
        {
            Assert.That("Do not allow adding Special Character" == actual, "Actual message and expected message do not match");
        }

    }
}
