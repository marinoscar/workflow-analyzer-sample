using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UiPath.Studio.Activities.Api;
using UiPath.Studio.Activities.Api.Analyzer;
using UiPath.Studio.Activities.Api.Analyzer.Rules;
using UiPath.Studio.Analyzer.Models;

namespace wa.sample.rules
{
    public class AnalyzerConfigurationServiceStub : IAnalyzerConfigurationService
    {
        public List<object> Counters { get; private set; }
        public List<object> Rules { get; private set; }

        public AnalyzerConfigurationServiceStub()
        {
            Counters = new List<object>();
            Rules = new List<object>();
        }

        public void AddCounter<T>(Counter<T> counter) where T : IInspectionObject
        {
            Counters.Add(counter);
        }

        public void AddRule<T>(Rule<T> rule) where T : IInspectionObject
        {
            Rules.Add(rule);
        }

        public bool HasFeature(string name)
        {
            return true;
        }


        public List<Rule<IProjectModel>> GetProjectRules()
        {
            return GetRules<IProjectModel>();
        }

        public List<Rule<IWorkflowModel>> GetWorkflowRules()
        {
            return GetRules<IWorkflowModel>();
        }

        public List<Rule<IActivityModel>> GetActivityRules()
        {
            return GetRules<IActivityModel>();
        }

        public List<Counter<IProjectModel>> GetProjectCounter()
        {
            return GetCounters<IProjectModel>();
        }

        public List<Counter<IWorkflowModel>> GetWorkflowCounter()
        {
            return GetCounters<IWorkflowModel>();
        }

        public List<Counter<IActivityModel>> GetActivityCounter()
        {
            return GetCounters<IActivityModel>();
        }


        private List<Rule<T>> GetRules<T>() where T : IInspectionObject
        {
            return Rules
                .Where(i => i.GetType().IsGenericType && i.GetType().GetGenericArguments().Contains(typeof(T)))
                .Select(i => (Rule<T>)Convert.ChangeType(i, typeof(Rule<T>))).ToList();
        }

        private List<Counter<T>> GetCounters<T>() where T : IInspectionObject
        {
            return Counters
                .Where(i => i.GetType().IsGenericType && i.GetType().GetGenericArguments().Contains(typeof(T)))
                .Select(i => (Counter<T>)Convert.ChangeType(i, typeof(Counter<T>))).ToList();
        }
    }
}
