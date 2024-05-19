using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTemplate.Resources
{
    public class ApplicationConfiguration
    {
        public GeneralConfiguration GeneralConfiguration { get; set; }
    }
    public class GeneralConfiguration
    {
        public string ApplicationName { get; set; }
    }
}
