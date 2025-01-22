using AdvancedTaskPart2.Utilities;
using Microsoft.Graph.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2.Model
{
    public class ReceivedRequestsData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ExpectedMessage { get; set; }
    }
}
