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
    internal static class CreateTestDataRule
    {
        internal static Rule<IProjectModel> Create()
        {
            return new Rule<IProjectModel>("Create Sample Data", "WACR-003", ExecuteRule);
        }

        internal static InspectionResult ExecuteRule(IProjectModel project, Rule instance)
        {
            //implementation
            //UiPath.Studio.Analyzer.ModelImpl.ProjectModel
            var jsonString = JsonConvert.SerializeObject(project, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            File.WriteAllText(@"C:\Users\CH489GT\Downloads\data.json", jsonString);
            return new InspectionResult() { HasErrors = false, RecommendationMessage = "Success" };
        }
    }
}
