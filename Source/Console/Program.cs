namespace ZetaProducerHtmlCompressor.Console
{
    using System;
    using System.IO;
    using System.Text;

    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Zeta Html Compressor Console. https://zeta.li");
            Console.WriteLine();
            Console.WriteLine("Syntax: hc.exe <HTML input file path>");
            Console.WriteLine();

            if (args.Length != 1)
            {
                Console.Error.WriteLine(
                    $"No input file specified or invalid number of arguments ({args.Length} found).");
            }
            else
            {
                var inputFilePath = args[0];
                var input = File.ReadAllText(inputFilePath);

                var compressor = new HtmlContentCompressor();
                var output = compressor.Compress(input);

                var outputFilePath =
                    Path.Combine(
                        Path.GetDirectoryName(inputFilePath),
                        Path.GetFileNameWithoutExtension(inputFilePath) + // @"-output" +
                        Path.GetExtension(inputFilePath));

                if (File.Exists(outputFilePath)) File.Delete(outputFilePath);
                File.WriteAllText(outputFilePath, output, Encoding.UTF8);

                Console.WriteLine($"Successfully written output file '{outputFilePath}'.");
            }
        }
    }
}