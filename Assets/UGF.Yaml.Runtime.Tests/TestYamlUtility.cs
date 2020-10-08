using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace UGF.Yaml.Runtime.Tests
{
    public class TestYamlUtility
    {
        public class Data
        {
            public bool Bool { get; set; }
            public int Int { get; set; }
            public float Float { get; set; }
            public string String { get; set; }
            public List<Data2> Data2 { get; set; } = new List<Data2>();
        }

        public class Data2
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
                Bool = true,
                Int = 15,
                Float = 10.5F,
                String = "Text",
                Data2 =
                {
                    new Data2
                    {
                        Bool = true,
                        Int = 100,
                        Float = 55.5F,
                        String = "Text2"
                    },
                    new Data2
                    {
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
            Assert.AreEqual(15, result.Int);
            Assert.AreEqual(10.5F, result.Float);
            Assert.AreEqual("Text", result.String);
            Assert.AreEqual(2, result.Data2.Count);
            Assert.True(result.Data2[0].Bool);
            Assert.AreEqual(100, result.Data2[0].Int);
            Assert.AreEqual(55.5F, result.Data2[0].Float);
            Assert.AreEqual("Text2", result.Data2[0].String);
            Assert.True(result.Data2[1].Bool);
            Assert.AreEqual(200, result.Data2[1].Int);
            Assert.AreEqual(65.5F, result.Data2[1].Float);
            Assert.AreEqual("Text3", result.Data2[1].String);
        }
    }
}
