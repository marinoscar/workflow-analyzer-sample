using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Studio.Activities.Api.Analyzer.Rules;
using UiPath.Studio.Analyzer.Models;

namespace wa.sample.rules
{
    internal static class RetryRule
    {
        public const string RuleId = "RetryCheck-001";
        private const string ConfigParameterKey = "configuration";


        internal static Rule<IProjectModel> Get()
        {
            var rule = new Rule<IProjectModel>("Retry Check Rule", RuleId, Inspect)
            {
                RecommendationMessage = "Number of Retry scope activities should be > 2 in Process Transaction, please check",
            /// Off and Verbose are not supported.
            ErrorLevel = System.Diagnostics.TraceLevel.Warning
            };
            return rule;
        }

        private static InspectionResult Inspect(IProjectModel project, Rule ruleInstance)
        {

            var messageList = new List<string>();
            var retryCount = 0;

            if (project.Workflows.Where(x => x.DisplayName.Equals("Process")).Count() > 0)
            {
                //get all xamls called inside Process.xaml and subsequest called workflows

                var allProcessWorkflows = getInvokedWorkflowNames(project, "Process").Concat(new[] { "Process" }).Distinct();

                foreach (var workflowName in allProcessWorkflows)
                {
                    var currentWorkflow = project.Workflows.Where(x => x.DisplayName.Equals(workflowName)).First();

                    var retryScopeActivities = currentWorkflow.Root.Children.Flatten(node => node.Children).Where(x => x.Type.ToString().Contains("RetryScope"));

                    retryCount += retryScopeActivities.Count();


                }

                if (retryCount < 3)
                {
                    messageList.Add($"Number of Retry scope activities in Process Transaction found: {retryCount.ToString()}");
                }
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

        public static IEnumerable<string> getInvokedWorkflowNames(IProjectModel project, string WorkflowName)
        {
            var CalledWorkflows = new List<string>();

            if (project.Workflows.Where(x => x.DisplayName.Equals(WorkflowName)).Count() > 0)
            {
                var baseWorkflow = project.Workflows.Where(x => x.DisplayName.Equals(WorkflowName)).First();

                var allChildren = baseWorkflow.Root.Children.Flatten(node => node.Children).Where(x => x.Type.ToString().Contains("InvokeWorkflowFile"));
                if (allChildren.Count() > 0)
                {
                    var childWorkflows = allChildren.Select(x => x.Arguments.Where(y => y.DisplayName.Equals("WorkflowFileName")).First().DefinedExpression.ToString().Split('\\').Last().Replace(".xaml", "").Replace("\"", ""));
                    CalledWorkflows.AddRange(childWorkflows);
                    CalledWorkflows.AddRange(childWorkflows.SelectMany(x => getInvokedWorkflowNames(project, x)));
                }

            }

            return CalledWorkflows;

        }

    }
}
