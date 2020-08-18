using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wa.data.model;
using wa.sample.rules;

namespace wa.sample.tests
{
    [TestFixture]
    public class WhenClickImageAccuracyIsExecuted
    {

        [Test]
        public void ItShouldPassWithValidActivity()
        {
            var project = Helper.LoadModel();
            var activity = project.Workflows.Last().Root.Children.First().Children.ToList()[2];
            var result = ClickImageAccuracyRule.Execute(activity, ClickImageAccuracyRule.Create());

            Assert.IsFalse(result.HasErrors);
        }
    }
}
