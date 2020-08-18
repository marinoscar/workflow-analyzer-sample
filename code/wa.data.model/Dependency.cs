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
    public class Dependency : IDependency
    {
        public string Name { get; set; }

        [JsonConverter(typeof(ModelConverter))]
        public IReadOnlyCollection<string> Assemblies { get; set; }
    }
}
