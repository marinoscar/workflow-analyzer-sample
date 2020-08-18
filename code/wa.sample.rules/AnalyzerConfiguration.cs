using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Studio.Activities.Api;
using UiPath.Studio.Activities.Api.Analyzer;

namespace wa.sample.rules
{
    /// <summary>
    /// Initialize the analyzer custom rules
    /// </summary>
    /// <remarks>
    /// Install the pacakge UiPath.Activities.Api from the following stream https://www.myget.org/F/workflow
    /// </remarks>
    public class AnalyzerConfiguration : IRegisterAnalyzerConfiguration
    {
        public void Initialize(UiPath.Studio.Activities.Api.Analyzer.IAnalyzerConfigurationService workflowAnalyzerConfigService)
        {
            workflowAnalyzerConfigService.AddRule(SampleActivityModelRule.Create());
            workflowAnalyzerConfigService.AddRule(SampleWorkflowModelRule.Create());
            workflowAnalyzerConfigService.AddRule(CreateTestDataRule.Create());
        }
    }
}
