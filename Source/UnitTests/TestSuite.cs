namespace ZetaHtmlCompressor.UnitTests
{
	using System.Collections;
	using NUnit.Framework;

	public sealed class TestSuite
	{
	    [Suite]
	    public static IEnumerable Suite =>
	        new[]
	        {
	            new HtmlCompressorTests()
	        };
	}
}