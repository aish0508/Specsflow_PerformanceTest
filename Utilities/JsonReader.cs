using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2.Utilities
{
    public class JsonReader
    {
        public static List<T> LoadData<T>(string jsonFileName)
        {
            string currentDirectory = "D:\\Advanced Task Part2-Mars-QA\\AdvancedTask_specsflow";
            string filePath = Path.Combine(currentDirectory, "Test Data", jsonFileName);
            using (StreamReader reader = new StreamReader(filePath))
            {
                var jsonContent = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(jsonContent);
            }
        }
    }
}