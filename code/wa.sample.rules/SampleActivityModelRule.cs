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
    internal static class SampleActivityModelRule
    {
        private const string RuleId = "WACR-001";

        internal static Rule<IActivityModel> Create()
        {
            var rule = new Rule<IActivityModel>("Sample Activity Model Rule", RuleId, Execute)
            {
                RecommendationMessage = "Sample Recomendation Message",
                ErrorLevel = System.Diagnostics.TraceLevel.Info
            };
            return rule;
        }

        private static InspectionResult Execute(IActivityModel activityModel, Rule ruleInstance)
        {
            return new InspectionResult() { HasErrors = false, RecommendationMessage = "Everything is perfect!" };
        }
    }
}

