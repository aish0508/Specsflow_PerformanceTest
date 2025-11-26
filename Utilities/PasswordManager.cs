using AdvancedTaskPart2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2.Utilities
{
    public class PasswordManager
    {
        public void WriteNewPasswordToJson(string newPassword)
        {
            // Read existing JSON data from UserInformation.json
            string currentDirectory = "D:\\Advanced Task Part2-Mars-QA\\AdvancedTask_specsflow\\Specsflow_PerformanceTest";
            string filePath = Path.Combine(currentDirectory, "Test Data", "UserInformation.json");
            string json = File.ReadAllText(filePath);
            List<UserInformation> userDataList = JsonConvert.DeserializeObject<List<UserInformation>>(json);

            // Find the user with the specified username
            UserInformation user = userDataList.FirstOrDefault(u => u.Email == "aisharya994@gmail.com");

            if (user != null)
            {
                // Update the password
                user.Password = newPassword;

                // Serialize the updated data back to JSON
                string updatedJson = JsonConvert.SerializeObject(userDataList, Formatting.Indented);

                // Write the updated JSON back to the file
                File.WriteAllText(filePath, updatedJson);
            }
            else
            {
                Console.WriteLine("User not found in UserInformation.json");
            }
        }
    }
}
