using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wa.data.model
{
    public class ModelConverter : JsonConverter
    {
        private const string SupportedNameSpace = "UiPath.Studio.Analyzer.Models";
        private string _rootNamespace;
        public override bool CanWrite => false;
        public override bool CanRead => true;

        public ModelConverter()
        {
            _rootNamespace = GetType().Namespace;
        }

        public override bool CanConvert(Type objectType)
        {
            var result = objectType.FullName.Contains(SupportedNameSpace);
            if (!result && objectType.IsGenericType && objectType.GetGenericArguments().First().GetType().FullName.Contains("UiPath.Studio.Analyzer.Models")) result = true;
            return result;
        }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonToken = JToken.Load(reader);
            var objectInstance = CreateObject(objectType);
            if (!string.IsNullOrWhiteSpace(jsonToken.ToString()))
            {
                if (!objectType.Name.Contains("ReadOnly"))
                {
                    if (typeof(string) == objectInstance.GetType()) return jsonToken.ToString();

                    serializer.Populate(jsonToken.CreateReader(), objectInstance);
                }
                else
                    PopulateReadOnlyCollection((JArray)jsonToken, objectInstance, serializer);
            }
            return objectInstance;
        }

        private void PopulateReadOnlyCollection(JArray array, object list, JsonSerializer serializer)
        {
            foreach (var token in array)
            {
                var listItem = ReadJson(token.CreateReader(), list.GetType().GenericTypeArguments.First(), null, serializer);
                AddItemToList(list, listItem);
            }
        }

        private void AddItemToList(object list, object item)
        {
            var addMethod = list.GetType().GetMethod("Add");
            addMethod.Invoke(list, new[] { item });
        }

        private object CreateObject(Type objectType)
        {
            if (typeof(IEnumerable).IsAssignableFrom(objectType) && objectType.IsGenericType)
                return GetList(objectType.GenericTypeArguments.First());

            if (objectType.FullName.Contains(SupportedNameSpace))
                return Activator.CreateInstance(GetModelType(objectType));

            if (objectType == typeof(string)) return string.Empty;
            return Activator.CreateInstance(objectType);
        }

        private object GetList(Type elementType)
        {
            var itemType = GetModelType(elementType);
            var listType = typeof(List<>);
            //var readOnlyListType = typeof(ReadOnlyCollection<>);
            var constructedList = listType.MakeGenericType(itemType);
            //var constructedReadOnlyList = readOnlyListType.MakeGenericType(itemType);
            var listInstance = Activator.CreateInstance(constructedList);
            //return Activator.CreateInstance(constructedReadOnlyList, listInstance);
            return listInstance;
        }

        private Type GetModelType(Type elementType)
        {
            if (!elementType.FullName.Contains(SupportedNameSpace)) return elementType;

            var constructed = Type.GetType(string.Format("{0}.{1}", _rootNamespace, elementType.Name.Remove(0, 1)));
            return constructed;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }


    }
}
