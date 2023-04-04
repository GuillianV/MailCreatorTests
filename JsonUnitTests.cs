using Json;
using JsonPart.Records;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace MailCreatorTests
{
    public class JsonUnitTests
    {
        [Fact]
        public void CreateFolder()
        {
            Assert.True(JsonFileUtils.CreateDataFolder());
        }
        [Fact]
        public void Write()
        {
            Assert.Throws<NullReferenceException>(() => JsonFileUtils.Write(default(object), typeof(object), "data.json"));
            Assert.Throws<NullReferenceException>(() => JsonFileUtils.Write(default(string), typeof(string), "dat5623a.json"));
            Assert.Throws<ArgumentException>(() => JsonFileUtils.Write(new Professeur("d", "n", "d", "n"), typeof(Professeur), "proo.f.json"));
            Assert.Throws<TypeAccessException>(() => JsonFileUtils.Write(new Professeur("d", "n", "d", "n"), typeof(int), "dat5623a.json"));
        }
        [Fact]
        public void Read()
        {
            Assert.Throws<FileNotFoundException>(() => JsonFileUtils.Read<Object>("data.json"));
            Assert.Throws<ArgumentException>(() => JsonFileUtils.Read<Professeur>("datsd45a.jsn"));
            Assert.Throws<NullReferenceException>(() => JsonFileUtils.Read<Professeur>("deleteme.json"));
            Assert.IsType(typeof(List<Professeur>),JsonFileUtils.Read<List<Professeur>>("professeurs.json"));
        }
    }
}
