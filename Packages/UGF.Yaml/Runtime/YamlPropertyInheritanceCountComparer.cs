using System;
using System.Collections.Generic;
using System.Reflection;
using YamlDotNet.Serialization;

namespace UGF.Yaml.Runtime
{
    public class YamlPropertyInheritanceCountComparer : IComparer<IPropertyDescriptor>
    {
        public Type ContainerType { get; }

        public YamlPropertyInheritanceCountComparer(Type containerType)
        {
            ContainerType = containerType ?? throw new ArgumentNullException(nameof(containerType));
        }

        public int Compare(IPropertyDescriptor x, IPropertyDescriptor y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;

            Type xDeclaringType = GetDeclaringType(ContainerType, x);
            Type yDeclaringType = GetDeclaringType(ContainerType, y);

            int xCount = GetInheritanceCount(xDeclaringType);
            int yCount = GetInheritanceCount(yDeclaringType);

            return xCount.CompareTo(yCount);
        }

        private static Type GetDeclaringType(Type containerType, IPropertyDescriptor propertyDescriptor)
        {
            if (propertyDescriptor == null) throw new ArgumentNullException(nameof(propertyDescriptor));

            MemberInfo[] members = containerType.GetMember(propertyDescriptor.Name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            if (members.Length == 0) throw new ArgumentException($"Members not found by the specified name: '{propertyDescriptor.Name}'.");

            MemberInfo member = members[0];

            return member.DeclaringType;
        }

        private static int GetInheritanceCount(Type type)
        {
            int count = 0;

            while (type != null)
            {
                count++;

                type = type.BaseType;
            }

            return count;
        }
    }
}
