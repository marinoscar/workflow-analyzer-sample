using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Studio.Activities.Api.Analyzer.Rules;
using UiPath.Studio.Analyzer.Models;

namespace wa.sample.rules
{
    internal static class SampleCounter
    {
        private const string RuleId = "WACR-002";

        internal static Counter<IActivityModel> Get()
        {
            var counter = new Counter<IActivityModel>("Simple Sample Rule", RuleId, Inspect)
            {
               
            };
            return counter;
        }
        
        private static InspectionResult Inspect(IReadOnlyCollection<IActivityModel> activities, Counter ruleInstance)
        {
            //interface is implemented with class
            //UiPath.Studio.Analyzer.ModelImpl.ActivityModel
            var file = Path.Combine(@"C:\Users\CH489GT\Downloads", $"activities-{ Guid.NewGuid().ToString() }.json");
            var result = string.Format("Number of activities {0}. Json file saved on {1}", activities.Count, file);
            try
            {
                var jsonContent = JsonConvert.SerializeObject(activities, Formatting.None,
                                new JsonSerializerSettings()
                                {
                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                });
                File.WriteAllText(file, jsonContent);
            }
            catch (Exception ex)
            {
                result = $"failed to serialize the data with error { ex.ToString() }";
            }

            return new InspectionResult()
            {
                Messages = new List<string>() { result }
            };
        }
    }
}
