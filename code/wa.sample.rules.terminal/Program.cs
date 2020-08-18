using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wa.sample.tests;

namespace wa.sample.rules.terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new AnalyzerConfiguration();
            var service = new AnalyzerConfigurationServiceStub();
            config.Initialize(service);
            var rules = service.GetProjectRules();
            var model = Helper.LoadModel();
            Debug.WriteLine(model);
        }
    }
}
