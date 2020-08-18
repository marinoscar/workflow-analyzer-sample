using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wa.data.model;
using wa.sample.rules;

namespace wa.sample.tests
{
    public static class Helper
    {
        public static ProjectModel LoadModel()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var jsonContent = File.ReadAllText(@"Test-Data\data.json");
            return JsonConvert.DeserializeObject<ProjectModel>(jsonContent, settings);
        }
    }
}
