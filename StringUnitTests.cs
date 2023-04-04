
using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using Xunit;

namespace MailCreatorTests
{
    public class StringUnitTests
    {
        [Fact]
        public void MatchMailtypeText()
        {
            Assert.Equal("", ("").MatchMailtypeText());
            Assert.Equal(("1").MatchMailtypeText(),"1");
            Assert.Equal(("123456789").MatchMailtypeText(),"123456789" );
            Assert.Equal(("aBcDeF1D35").MatchMailtypeText(),"aBcDeF1D35");
            Assert.Equal(("gvv.sqd@mmm.comm").MatchMailtypeText(),"gvv.sqd@mmm.comm");
            Assert.Equal(("gvv.sq_d@mmm.comm").MatchMailtypeText(),"gvv.sq_d@mmm.comm");
            Assert.Equal(("g-vv.sq_d@mmm.comm").MatchMailtypeText(),"g-vv.sq_d@mmm.comm" );
            Assert.NotEqual("g-v$v.sq_d@mmm.comm", ("g-v$v.sq_d@mmm.comm").MatchMailtypeText());
            Assert.NotEqual(("ffdsq*.").MatchMailtypeText(),"ffdsq*.");
            Assert.Equal("", ("458<è'é\"rfdsdsf").MatchMailtypeText());
        }
        [Fact]
        public void MatchJsonFilename()
        {
            Assert.Throws<ArgumentException>(() => "sq.dsqf.json".MatchJsonFilename());
            Assert.Throws<ArgumentException>(() => "/dsqf.json".MatchJsonFilename());
            Assert.Throws<ArgumentException>(() => "./45.json".MatchJsonFilename());
            Assert.Throws<ArgumentException>(() => ".json".MatchJsonFilename());
            Assert.Throws<ArgumentException>(() => "sqdd52".MatchJsonFilename());
            Assert.Throws<ArgumentException>(() => "sqdd52.jsonn".MatchJsonFilename());
            Assert.Throws<ArgumentException>(() => " .json".MatchJsonFilename());
            Assert.Equal("data.json", ("data.json").MatchJsonFilename());
            Assert.Equal("dat452dAcfdsa.json", ("dat452dAcfdsa.json").MatchJsonFilename());
        }
    }
}