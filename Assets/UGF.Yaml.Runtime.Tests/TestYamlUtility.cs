using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace UGF.Yaml.Runtime.Tests
{
    public class TestYamlUtility
    {
        public class DataBase
        {
            public string BaseValue { get; set; }
        }

        public class Data : DataBase
        {
            public bool Bool { get; set; }
            public int Int { get; set; }
            public float Float { get; set; }
            public string String { get; set; }
            public List<Data2> Data2 { get; set; } = new List<Data2>();
        }

        public class Data2 : DataBase
        {
            public bool Bool { get; set; }
            public int Int { get; set; }
            public float Float { get; set; }
            public string String { get; set; }
        }

        [Test]
        public void ToYaml()
        {
            var data = new Data
            {
                BaseValue = "Base Value",
                Bool = true,
                Int = 15,
                Float = 10.5F,
                String = "Text",
                Data2 =
                {
                    new Data2
                    {
                        BaseValue = "Base Value 2",
                        Bool = true,
                        Int = 100,
                        Float = 55.5F,
                        String = "Text2"
                    },
                    new Data2
                    {
                        BaseValue = "Base Value 3",
                        Bool = true,
                        Int = 200,
                        Float = 65.5F,
                        String = "Text3"
                    }
                }
            };

            string yaml = Resources.Load<TextAsset>("Data").text;
            string result = YamlUtility.ToYaml(data);

            Assert.AreEqual(yaml, result);
            Assert.Pass(result);
        }

        [Test]
        public void FromYaml()
        {
            string yaml = Resources.Load<TextAsset>("Data").text;
            var result = YamlUtility.FromYaml<Data>(yaml);

            Assert.NotNull(result);
            Assert.True(result.Bool);
            Assert.AreEqual("Base Value", result.BaseValue);
            Assert.AreEqual(15, result.Int);
            Assert.AreEqual(10.5F, result.Float);
            Assert.AreEqual("Text", result.String);
            Assert.AreEqual(2, result.Data2.Count);
            Assert.AreEqual("Base Value 2", result.Data2[0].BaseValue);
            Assert.True(result.Data2[0].Bool);
            Assert.AreEqual(100, result.Data2[0].Int);
            Assert.AreEqual(55.5F, result.Data2[0].Float);
            Assert.AreEqual("Text2", result.Data2[0].String);
            Assert.AreEqual("Base Value 3", result.Data2[1].BaseValue);
            Assert.True(result.Data2[1].Bool);
            Assert.AreEqual(200, result.Data2[1].Int);
            Assert.AreEqual(65.5F, result.Data2[1].Float);
            Assert.AreEqual("Text3", result.Data2[1].String);
        }
    }
}
