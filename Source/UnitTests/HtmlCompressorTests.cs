namespace ZetaProducerHtmlCompressor.UnitTests
{
    using Internal;
    using NUnit.Framework;
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    [TestFixture]
    public sealed class HtmlCompressorTests
    {
        [Test]
        public void Test01()
        {
            var comp = new HtmlCompressor();

            var input = Resources.Html01;
            var output = comp.compress(input);

            Assert.IsNotEmpty(output);
            var ratio = Math.Round((double)output.Length / input.Length * 100.0, 2);
            Assert.IsTrue(ratio < 100.0);
        }

        [Test]
        public void Test02()
        {
            var comp = new HtmlContentCompressor();
            comp.AddPreservePattern(new Regex(@"<!-- PROTECTED: .*? -->", RegexOptions.Singleline | RegexOptions.IgnoreCase));

            var input = Resources.Html02a;
            var output = comp.Compress(input);

            Assert.IsNotEmpty(output);
            var ratio = Math.Round((double)output.Length / input.Length * 100.0, 2);
            Assert.IsTrue(ratio < 100.0);
        }

        [Test]
        public void testEnabled()
        {
            var source = Resources.testEnabled;
            var result = Resources.testEnabledResult;

            var compressor = new HtmlCompressor();
            compressor.setEnabled(false);

            var compress = compressor.compress(source);
            Assert.AreEqual(result, compress);
        }

        [Test]
        public void testRemoveSpacesInsideTags()
        {
            var source = Resources.testRemoveSpacesInsideTags;
            var result = Resources.testRemoveSpacesInsideTagsResult;

            var compressor = new HtmlCompressor();
            compressor.setRemoveMultiSpaces(false);

            var compress = compressor.compress(source);
            Assert.AreEqual(result, compress);

        }

        [Test]
        public void testRemoveComments()
        {
            var source = Resources.testRemoveComments;
            var result = Resources.testRemoveCommentsResult;

            var compressor = new HtmlCompressor();
            compressor.setRemoveComments(true);
            compressor.setRemoveIntertagSpaces(true);

            var compress = compressor.compress(source);
            Assert.AreEqual(result, compress);

        }

        [Test]
        public void testRemoveQuotes()
        {
            var source = Resources.testRemoveQuotes;
            var result = Resources.testRemoveQuotesResult;

            var compressor = new HtmlCompressor();
            compressor.setRemoveQuotes(true);

            var compress = compressor.compress(source);
            Assert.AreEqual(result, compress);

        }

        [Test]
        public void testRemoveMultiSpaces()
        {
            var source = Resources.testRemoveMultiSpaces;
            var result = Resources.testRemoveMultiSpacesResult;

            var compressor = new HtmlCompressor();
            compressor.setRemoveMultiSpaces(true);

            var compress = compressor.compress(source);
            Assert.AreEqual(result, compress);

        }

        [Test]
        public void testRemoveIntertagSpaces()
        {
            var source = Resources.testRemoveIntertagSpaces;
            var result = Resources.testRemoveIntertagSpacesResult;

            var compressor = new HtmlCompressor();
            compressor.setRemoveIntertagSpaces(true);

            var compress = compressor.compress(source);
            Assert.AreEqual(result, compress);

        }

        [Test]
        public void testPreservePatterns()
        {
            var source = Resources.testPreservePatterns;
            var result = Resources.testPreservePatternsResult;

            var preservePatterns = new List<Regex>
            {
                HtmlCompressor.PHP_TAG_PATTERN,
                HtmlCompressor.SERVER_SCRIPT_TAG_PATTERN,
                HtmlCompressor.SERVER_SIDE_INCLUDE_PATTERN,
                new Regex("<jsp:.*?>", RegexOptions.Singleline | RegexOptions.IgnoreCase)
            };
            //<?php ... ?> blocks
            //<% ... %> blocks
            //<!--# ... --> blocks
            //<jsp: ... > tags

            var compressor = new HtmlCompressor();
            compressor.setPreservePatterns(preservePatterns);
            compressor.setRemoveComments(true);
            compressor.setRemoveIntertagSpaces(true);

            var compress = compressor.compress(source);
            Assert.AreEqual(result, compress);

        }

        /*[Test]
		public void testCompressJavaScriptYui()
		{
			var source = Resources.testCompressJavaScript;
			var result = Resources.testCompressJavaScriptYuiResult;

			var compressor = new HtmlCompressor();
			compressor.setCompressJavaScript(true);
			compressor.setRemoveIntertagSpaces(true);

						var compress = compressor.compress(source);
			Assert.AreEqual(result, compress);

		}*/

        //[Test]
        //public void testCompressJavaScriptClosure()
        //{
        //    var source = Resources.testCompressJavaScript;
        //    var result = Resources.testCompressJavaScriptClosureResult;

        //    var compressor = new HtmlCompressor();
        //    compressor.setCompressJavaScript(true);
        //    compressor.setJavaScriptCompressor(new ClosureJavaScriptCompressor(CompilationLevel.ADVANCED_OPTIMIZATIONS));
        //    compressor.setRemoveIntertagSpaces(true);

        //    			var compress = compressor.compress(source);
        //	Assert.AreEqual(result, compress);

        //}

        /*[Test]
		public void testCompressCss()
		{
			var source = Resources.testCompressCss;
			var result = Resources.testCompressCssResult;

			var compressor = new HtmlCompressor();
			compressor.setCompressCss(true);
			compressor.setRemoveIntertagSpaces(true);

						var compress = compressor.compress(source);
			Assert.AreEqual(result, compress);

		}*/

        [Test]
        public void testCompress()
        {
            var source = Resources.testCompress;
            var result = Resources.testCompressResult;

            var compressor = new HtmlCompressor();

            var compress = compressor.compress(source);
            Assert.AreEqual(result, compress);
        }

        [Test]
        public void testSimpleDoctype()
        {
            var source = Resources.testSimpleDoctype;
            var result = Resources.testSimpleDoctypeResult;

            var compressor = new HtmlCompressor();
            compressor.setSimpleDoctype(true);

            var compress = compressor.compress(source);
            Assert.AreEqual(result, compress);

        }

        [Test]
        public void testRemoveScriptAttributes()
        {
            var source = Resources.testRemoveScriptAttributes;
            var result = Resources.testRemoveScriptAttributesResult;

            var compressor = new HtmlCompressor();
            compressor.setRemoveScriptAttributes(true);

            var compress = compressor.compress(source);
            Assert.AreEqual(result, compress);

        }

        [Test]
        public void testRemoveStyleAttributes()
        {
            var source = Resources.testRemoveStyleAttributes;
            var result = Resources.testRemoveStyleAttributesResult;

            var compressor = new HtmlCompressor();
            compressor.setRemoveStyleAttributes(true);

            var compress = compressor.compress(source);
            Assert.AreEqual(result, compress);

        }

        [Test]
        public void testRemoveLinkAttributes()
        {
            var source = Resources.testRemoveLinkAttributes;
            var result = Resources.testRemoveLinkAttributesResult;

            var compressor = new HtmlCompressor();
            compressor.setRemoveLinkAttributes(true);

            var compress = compressor.compress(source);
            Assert.AreEqual(result, compress);

        }

        [Test]
        public void testRemoveFormAttributes()
        {
            var source = Resources.testRemoveFormAttributes;
            var result = Resources.testRemoveFormAttributesResult;

            var compressor = new HtmlCompressor();
            compressor.setRemoveFormAttributes(true);

            var compress = compressor.compress(source);
            Assert.AreEqual(result, compress);

        }

        [Test]
        public void testRemoveInputAttributes()
        {
            var source = Resources.testRemoveInputAttributes;
            var result = Resources.testRemoveInputAttributesResult;

            var compressor = new HtmlCompressor();
            compressor.setRemoveInputAttributes(true);

            var compress = compressor.compress(source);
            Assert.AreEqual(result, compress);

        }

        [Test]
        public void testRemoveJavaScriptProtocol()
        {
            var source = Resources.testRemoveJavaScriptProtocol;
            var result = Resources.testRemoveJavaScriptProtocolResult;

            var compressor = new HtmlCompressor();
            compressor.setRemoveJavaScriptProtocol(true);

            var compress = compressor.compress(source);
            Assert.AreEqual(result, compress);

        }

        [Test]
        public void testRemoveHttpProtocol()
        {
            var source = Resources.testRemoveHttpProtocol;
            var result = Resources.testRemoveHttpProtocolResult;

            var compressor = new HtmlCompressor();
            compressor.setRemoveHttpProtocol(true);

            var compress = compressor.compress(source);
            Assert.AreEqual(result, compress);

        }

        [Test]
        public void testRemoveHttpsProtocol()
        {
            var source = Resources.testRemoveHttpsProtocol;
            var result = Resources.testRemoveHttpsProtocolResult;

            var compressor = new HtmlCompressor();
            compressor.setRemoveHttpsProtocol(true);

            var compress = compressor.compress(source);
            Assert.AreEqual(result, compress);

        }

        [Test]
        public void testPreserveLineBreaks()
        {
            var source = Resources.testPreserveLineBreaks;
            var result = Resources.testPreserveLineBreaksResult;

            var compressor = new HtmlCompressor();
            compressor.setPreserveLineBreaks(true);

            var compress = compressor.compress(source);
            Assert.AreEqual(result, compress);

        }

        [Test]
        public void testSurroundingSpaces()
        {
            var source = Resources.testSurroundingSpaces;
            var result = Resources.testSurroundingSpacesResult;

            var compressor = new HtmlCompressor();
            compressor.setRemoveIntertagSpaces(true);
            compressor.setRemoveSurroundingSpaces("p,br");

            var compress = compressor.compress(source);
            Assert.AreEqual(result, compress);

        }
    }
}