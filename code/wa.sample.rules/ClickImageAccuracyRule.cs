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
    public class ClickImageAccuracyRule
    {
        public static Rule<IActivityModel> Create()
        {
            return new Rule<IActivityModel>("Check Image Click Quality", "DEMO-001", Execute);
        }

        public static InspectionResult Execute(IActivityModel activity, Rule instance)
        {
            if (string.IsNullOrWhiteSpace(activity.Type) || !activity.Type.Contains("ClickImage")) return new InspectionResult() { HasErrors = false };

            var imageClickAccuracy = activity.Properties.Where(i => i.Type.Contains("ImageTarget"))
                .SelectMany(i => i.Arguments)
                .FirstOrDefault(i => i.DisplayName == "Accuracy");

            return new InspectionResult()
            {
                ErrorLevel = TraceLevel.Error,
                HasErrors = Convert.ToDouble(imageClickAccuracy.DefinedExpression) < 0.9,
                RecommendationMessage = "Accuracy needs to be greater to 0.9"
            };
        }
    }
}
