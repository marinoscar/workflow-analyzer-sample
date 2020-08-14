using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Studio.Activities.Api.Analyzer.Rules;
using UiPath.Studio.Analyzer.Models;

namespace wa.sample.rules
{
    internal static class SampleRule
    {
        private const string RuleId = "WACR-001";

        internal static Rule<IActivityModel> Get()
        {
            var rule = new Rule<IActivityModel>("Simple Sample Rule", RuleId, Inspect)
            {
                RecommendationMessage = "Sample Recomendation Message",
                /// Off and Verbose are not supported.
                ErrorLevel = System.Diagnostics.TraceLevel.Warning
            };
            return rule;
        }

        private static InspectionResult Inspect(IActivityModel activityModel, Rule ruleInstance)
        {
            Debug.WriteLine($"Inspecting rule { ruleInstance.Name }");

            foreach (var property in activityModel.Properties)
            {
                Debug.WriteLine($"Properties Name {property.DisplayName}");
            }

            return new InspectionResult() { HasErrors = false };
        }
    }
}

