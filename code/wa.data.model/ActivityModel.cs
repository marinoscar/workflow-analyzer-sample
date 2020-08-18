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
    public class ActivityModel : IActivityModel
    {
        public string Type { get; set; }

        [JsonConverter(typeof(ModelConverter))]
        public IReadOnlyCollection<IVariableModel> Variables { get; set; }

        [JsonConverter(typeof(ModelConverter))]
        public IReadOnlyCollection<IVariableModel> DelegateArguments { get; set; }

        [JsonConverter(typeof(ModelConverter))]
        public IReadOnlyCollection<IArgumentModel> Arguments { get; set; }

        [JsonConverter(typeof(ModelConverter))]
        public IReadOnlyCollection<IPropertyModel> Properties { get; set; }

        [JsonConverter(typeof(ModelConverter))]
        public IReadOnlyCollection<IActivityModel> Children { get; set; }

        [JsonConverter(typeof(ModelConverter))]
        public IActivityModel Parent { get; set; }

        [JsonConverter(typeof(ModelConverter))]
        public IActivityContext Context { get; set; }

        [JsonConverter(typeof(ModelConverter))]
        public IReadOnlyCollection<string> ObjectReferences { get; set; }

        public bool SupportsObjectReferences { get; set; }

        public string DisplayName { get; set; }
    }
}
