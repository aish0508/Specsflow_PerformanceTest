using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2.Model
{
    public class EducationData
    {
        public int Id { get; set; }
        public string UniversityName { get; set; }
        public string Country { get; set; }
        public string Title { get; set; }
        public string Degree { get; set; }
        public string YearOfGraduation { get; set; }
        public string ExpectedMessage { get; set; }
              
        public string AddExpectedMessage { get; set; }
        public string DeleteExpectedMessage { get; set; }
    }
}
