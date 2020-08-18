using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Studio.Analyzer.Models;

namespace wa.data.model
{
    public class ActivityContext : IActivityContext
    {
        [JsonConverter(typeof(ModelConverter))]
        public IReadOnlyCollection<IVariableModel> Variables { get; set; }

        [JsonConverter(typeof(ModelConverter))]
        public IReadOnlyCollection<IArgumentModel> DelegateArguments { get; set; }

        [JsonConverter(typeof(ModelConverter))]
        public IReadOnlyCollection<IArgumentModel> WorkflowArguments { get; set; }

        [JsonConverter(typeof(ModelConverter))]
        public IProjectSummary Project { get; set; }
    }
}
