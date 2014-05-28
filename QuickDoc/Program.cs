using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

using MarkdownSharp;

namespace QuickDoc
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				string templatePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Templates";

				// process args
				string inputFileName;
				string outputFileName;

				if (args.Length == 0)
				{
					throw new ArgumentException("Usage: QuickDoc.exe [Markdown input filename] [optional output filename]");
				}

				inputFileName = args[0];

				if (args.Length == 1)
				{
					outputFileName = CreateOutputFileName(inputFileName);
				}
				else
				{
					outputFileName = args[1];
				}

				StringBuilder sb = new StringBuilder();
				Markdown markdown = new Markdown();

				// read in header template
				using (StreamReader reader = new StreamReader(Path.Combine(templatePath, "Header.txt")))
				{
					sb.AppendLine(reader.ReadToEnd());
				}

				// read in Markdown file from args and append lines
				using (StreamReader reader = new StreamReader(inputFileName))
				{
					sb.AppendLine(markdown.Transform(reader.ReadToEnd()));
				}

				// read in footer template
				using (StreamReader reader = new StreamReader(Path.Combine(templatePath, "Footer.txt")))
				{
					sb.AppendLine(reader.ReadToEnd());
				}

				// write the output to filename.htm
				using (StreamWriter sw = new StreamWriter(outputFileName))
				{
					sw.Write(sb.ToString());
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine("\n\n");
				Console.WriteLine(ex.InnerException);
			}
			
		}

		static string CreateOutputFileName(string inputFileName)
		{
			return Path.Combine(Path.GetDirectoryName(inputFileName), Path.GetFileNameWithoutExtension(inputFileName) + ".htm");
		}
	}
}
