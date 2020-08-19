using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wa.data.model;
using wa.sample.tests;

namespace wa.sample.rules.terminal
{
    class Program
    {
        static void Main(string[] args)
        {

            var project = Helper.LoadModel();
            var activity = project.Workflows.Last().Root.Children.First().Children.ToList()[2];

            var result = ClickImageAccuracyRule.Execute(activity, ClickImageAccuracyRule.Create());

            Console.WriteLine("Has Errors: {0}", result.HasErrors);
            Console.ReadKey();


        }

       
    }
}
