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
    internal static class SampleWorkflowModelRule
    {
        private const string RuleId = "WACR-002";

        internal static Rule<IWorkflowModel> Create()
        {
            var counter = new Rule<IWorkflowModel>("Sample Activity Model Rule", RuleId, Execute)
            {
               
            };
            return counter;
        }
        
        private static InspectionResult Execute(IWorkflowModel workflow, Rule ruleInstance)
        {

            return new InspectionResult()
            {
                RecommendationMessage = "Success!"
            };
        }
    }
}
