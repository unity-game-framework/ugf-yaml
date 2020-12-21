using System;
using System.Collections.Generic;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.TypeInspectors;

namespace UGF.Yaml.Runtime
{
    public class YamlPropertyInheritanceOrderTypeInspector : TypeInspectorSkeleton
    {
        public ITypeInspector InnerInspector { get; }

        public YamlPropertyInheritanceOrderTypeInspector(ITypeInspector innerInspector)
        {
            InnerInspector = innerInspector ?? throw new ArgumentNullException(nameof(innerInspector));
        }

        public override IEnumerable<IPropertyDescriptor> GetProperties(Type type, object container)
        {
            var properties = new List<IPropertyDescriptor>(InnerInspector.GetProperties(type, container));
            var comparer = new YamlPropertyInheritanceCountComparer(type);

            properties.Sort(comparer);

            return properties;
        }
    }
}
