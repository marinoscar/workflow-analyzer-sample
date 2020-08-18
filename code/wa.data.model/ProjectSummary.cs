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
    public class ProjectSummary : IProjectSummary
    {
        public string DisplayName { get; set; }

        [JsonConverter(typeof(ModelConverter))]
        public IReadOnlyCollection<string> FileNames { get; set; }

        [JsonConverter(typeof(ModelConverter))]
        public IReadOnlyCollection<IDependency> Dependencies { get; set; }

        public string ProjectOutputType { get; set; }

        public string ProjectProfileType { get; set; }

        public string ExpressionLanguage { get; set; }

        public bool RequiresUserInteraction { get; set; }

        public bool SupportsPersistence { get; set; }

        public string EntryPointName { get; set; }

        public string ProjectFilePath { get; set; }

        public string ExceptionHandlerWorkflowName { get; set; }
    }
}
