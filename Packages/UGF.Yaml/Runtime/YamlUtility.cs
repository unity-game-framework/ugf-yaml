using System;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace UGF.Yaml.Runtime
{
    public static class YamlUtility
    {
        private static readonly ISerializer m_serializer;
        private static readonly IDeserializer m_deserializer;

        static YamlUtility()
        {
            m_serializer = new SerializerBuilder()
                .DisableAliases()
                .EmitDefaults()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();

            m_deserializer = new DeserializerBuilder()
                .IgnoreUnmatchedProperties()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();
        }

        public static string ToYaml(object target)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));

            return m_serializer.Serialize(target);
        }

        public static object FromYaml(string text, Type type)
        {
            if (string.IsNullOrEmpty(text)) throw new ArgumentException("Value cannot be null or empty.", nameof(text));
            if (type == null) throw new ArgumentNullException(nameof(type));

            return m_deserializer.Deserialize(text, type);
        }

        public static T FromYaml<T>(string text)
        {
            if (string.IsNullOrEmpty(text)) throw new ArgumentException("Value cannot be null or empty.", nameof(text));

            return m_deserializer.Deserialize<T>(text);
        }
    }
}
