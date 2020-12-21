using System;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace UGF.Yaml.Runtime
{
    public static class YamlUtility
    {
        public static ISerializer DefaultSerializer { get; } = CreateDefaultSerializerBuilder().Build();
        public static IDeserializer DefaultDeserializer { get; } = CreateDefaultDeserializerBuilder().Build();

        public static SerializerBuilder CreateDefaultSerializerBuilder()
        {
            return new SerializerBuilder()
                .DisableAliases()
                .EmitDefaults()
                .WithNamingConvention(new CamelCaseNamingConvention());
        }

        public static DeserializerBuilder CreateDefaultDeserializerBuilder()
        {
            return new DeserializerBuilder()
                .IgnoreUnmatchedProperties()
                .WithNamingConvention(new CamelCaseNamingConvention());
        }

        public static string ToYaml(object target)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));

            return DefaultSerializer.Serialize(target);
        }

        public static object FromYaml(string text, Type type)
        {
            if (string.IsNullOrEmpty(text)) throw new ArgumentException("Value cannot be null or empty.", nameof(text));
            if (type == null) throw new ArgumentNullException(nameof(type));

            return DefaultDeserializer.Deserialize(text, type);
        }

        public static T FromYaml<T>(string text)
        {
            if (string.IsNullOrEmpty(text)) throw new ArgumentException("Value cannot be null or empty.", nameof(text));

            return DefaultDeserializer.Deserialize<T>(text);
        }
    }
}
