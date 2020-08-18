using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Studio.Activities.Api.Analyzer.Rules;
using UiPath.Studio.Analyzer.Models;

namespace wa.sample.rules
{
    internal static class ReFrameworkLib_Rule
    {
        public const string RuleId = "Framework-001";
        private const string ConfigParameterKey = "configuration";

        internal static Rule<IProjectModel> Get()
        {
            var rule = new Rule<IProjectModel>("ReFramework Library Rule", RuleId, Inspect)
            {
                RecommendationMessage = "Utils ReFramework library missing in project. Program projects should be developed using Custom RE Framework",
                ErrorLevel = System.Diagnostics.TraceLevel.Error
            };
            return rule;
        }

        private static InspectionResult Inspect(IProjectModel project, Rule ruleInstance)
        {

            var messageList = new List<string>();
            var expectedFrameworkLib = "Utils_Custom-ReFramework";


            if (!project.Dependencies.Select(x => x.Name).Contains(expectedFrameworkLib))
            {
                messageList.Add($"Missing Project dependencies: " + expectedFrameworkLib);
            }


            if (messageList.Count > 0)
            {
                return new InspectionResult()
                {
                    ErrorLevel = ruleInstance.ErrorLevel,
                    HasErrors = true,
                    RecommendationMessage = ruleInstance.RecommendationMessage,
                    // When inspecting a model, a rule can generate more than one message.
                    Messages = messageList
                };
            }
            else
            {
                return new InspectionResult() { HasErrors = false };
            }

        }



    }
}
