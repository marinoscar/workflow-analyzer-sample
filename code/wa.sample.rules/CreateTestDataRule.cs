using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Studio.Activities.Api.Analyzer.Rules;
using UiPath.Studio.Analyzer.Models;

namespace wa.sample.rules
{
    internal static class CreateTestDataRule
    {
        internal static Rule<IProjectModel> Create()
        {
            var rule = new Rule<IProjectModel>("Create Test Data", "WACR-003", ExecuteRule);
            rule.Parameters.Add("Path", new Parameter()
            {
                DefaultValue = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "project-data.json")
            });
            return rule;
        }

        internal static InspectionResult ExecuteRule(IProjectModel project, Rule instance)
        {
            var pathValue = instance.Parameters["Path"].Value;
            var jsonString = JsonConvert.SerializeObject(project, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            if(string.IsNullOrWhiteSpace(pathValue)) return new InspectionResult() { HasErrors = true, RecommendationMessage = "Parameter not provided" };
            
            File.WriteAllText(pathValue, jsonString);
            return new InspectionResult() { HasErrors = false, ErrorLevel = TraceLevel.Info, RecommendationMessage = $"File saved in { pathValue }" };
        }
    }
}
