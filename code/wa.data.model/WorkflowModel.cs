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
    public class WorkflowModel : IWorkflowModel
    {
        [JsonConverter(typeof(ModelConverter))]
        public IActivityModel Root { get; set; }

        [JsonConverter(typeof(ModelConverter))]
        public IReadOnlyCollection<IArgumentModel> Arguments { get; set; }

        [JsonConverter(typeof(ModelConverter))]
        public IReadOnlyCollection<string> ImportedNamespaces { get; set; }

        [JsonConverter(typeof(ModelConverter))]
        public IProjectSummary Project { get; set; }

        public string RelativePath { get; set; }

        public string DisplayName { get; set; }
    }
}
