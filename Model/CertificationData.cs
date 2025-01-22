using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2.Model
{
    public class CertificationData
    {
        public int Id { get; set; }
        public string Certificate { get; set; }
        public string CertifiedFrom { get; set; }
        public string Year { get; set; }
        public string AddExpectedMessage { get; set; }
        public string DeleteExpectedMessage { get; set; }
        public string ExpectedMessage { get; set; }
    }
}
