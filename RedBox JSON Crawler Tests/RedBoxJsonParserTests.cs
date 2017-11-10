using System.Linq;
using Redbox_JSON_Parser;
using NUnit.Framework;
using Redbox_JSON_Parser.Exceptions;
using Newtonsoft.Json;



namespace RedBox_JSON_Crawler_Tests
{
    [TestFixture]
    public class RedBoxJsonParserTests
    {

        public RedBoxJsonParserTests()
        {
        }

        [Test]
        public void TestProperJsonFormat()
        {
            var parser = new RedBoxJsonParser();
            parser.Json = "var __titles = [{ 'ID':303266,'soon':'0','name':'Tyler Perry's Boo 2! A Madea Halloween','alt':'Tyler Perry's Boo 2! A Madea Halloween, Movie on DVD, Comedy','img':'203266.jpg','imgPath':'PosterThumb150/','articleKey':'Title303266','SEO':'tyler-perrys-boo-2-a-madea-halloween','len':'1:41','sortName':'tyler perry's boo 2! a madea halloween','sortOrder':99,'doNotSell':true,'forSale':'0','salePrice':0.0,'sortDate':'2018-01-30T06:00:00','sortReleaseDays':-82,'releaseDays':-83,'retailSaleDate':'','genreIDs':[1004,1004],'fmt':'1','url':'movies/tyler-perrys-boo-2-a-madea-halloween','productType':'1','rating':'PG-13','def':'0','limited':'0','sib':'403266','sibs':[403266],'sibFmts':[2],'pid':'203266','extendedSoon':'1','tSoon':'0','mdv':'0','replay':'0','mostpopular':2085}];";
            parser.Execute();
            var movie = parser.RedboxMovies.ElementAt(0);
            Assert.AreEqual("0", movie.Soon);
            Assert.AreEqual("303266", movie.TitleId);
        }

        [Test]
        public void TestEmptyJson()
        {
            var parser = new RedBoxJsonParser();
            parser.Json = "";
            Assert.Throws<EmptyJsonException>(() => parser.CreateRedBoxMovies());
        }

        [Test]
        public void TestInvalidJson()
        {
            var parser = new RedBoxJsonParser();
            parser.Json = "Bad Json";
            Assert.Throws<JsonReaderException>(() => parser.CreateRedBoxMovies());
        }
    }
}
