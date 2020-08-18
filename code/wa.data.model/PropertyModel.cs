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
    public class PropertyModel : IPropertyModel
    {
        [JsonConverter(typeof(ModelConverter))]
        public IReadOnlyCollection<IPropertyModel> Properties { get; set; }

        [JsonConverter(typeof(ModelConverter))]
        public IReadOnlyCollection<IArgumentModel> Arguments { get; set; }

        public string DisplayName { get; set; }

        public string Type { get; set; }

        public string DefinedExpression { get; set; }
    }
}
