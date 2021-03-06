﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Studio.Analyzer.Models;

namespace wa.data.model
{
    public class VariableModel : IVariableModel
    {
        public string DefaultValue { get; set; }

        public string DisplayName { get; set; }

        public string Type { get; set; }

        public string DefinedExpression { get; set; }
    }
}
