using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

internal class Builder
{
    [STAThread]
    private static void Main(string[] args)
    {
        var dirs = args.Length > 0 ? args : new[] { @"." };

        var ignoredPatterns = new[] { @"_tests?\.cs", @"_should\.cs", @"bin\\", @"obj\\", @"Builder\.cs" };
        var sources =
            dirs.SelectMany(
                dir =>
                    Directory
                        .EnumerateFiles(dir, "*.cs", SearchOption.AllDirectories)
                        .Where(fn => !ignoredPatterns.Any(p => Regex.IsMatch(fn, p, RegexOptions.IgnoreCase)))
                        .Select(fn => fn.ToLower())
                        .Select(fn => new { name = fn.ToLower(), src = File.ReadAllText(fn) })).ToList();
        var usings = new HashSet<string>();
        var sb = new StringBuilder();
        foreach (var file in sources)
        {
            Console.WriteLine($"use {file.name}");
            var source = file.src;
            var pattern = @"using [A-Z0-9.]+;\r?\n";
            var usingLines = Regex.Matches(source, pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase)
                .Cast<Match>()
                .Select(m => m.Value).ToList();
            foreach (var usingLine in usingLines)
            {
                if (!usingLine.StartsWith("using System"))
                {
                    var oldColor = TrySetConsoleForegroundColor(ConsoleColor.Red);
                    Console.WriteLine(usingLine + " in " + file.name);
                    Console.WriteLine("You can't use third party libs in your solution! Press any key and fix it!");
                    TrySetConsoleForegroundColor(oldColor);
                    Console.ReadLine();
                    Environment.Exit(255);
                }
                usings.Add(usingLine);
            }
            var sourceWithNoUsings =
                Regex.Replace(source, pattern, "", RegexOptions.Multiline | RegexOptions.IgnoreCase)
                    .Trim();
            sb.AppendLine(sourceWithNoUsings);
            sb.AppendLine();
        }
        sb.Insert(0, string.Join("", usings) + "\r\n");
        var result = sb.ToString();
        Console.WriteLine("Length: {0}", result.Length);
        if (result.Length > 90000)
            result = Compress(result);
        Console.WriteLine();
        Console.WriteLine("result was copied to the clipboard");
        Clipboard.SetText(result);
    }

    private static ConsoleColor TrySetConsoleForegroundColor(ConsoleColor color)
    {
        try
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            return oldColor;
        }
        catch
        {
            return ConsoleColor.White;
        }
    }

    private static string Compress(string result)
    {
        result = result.Replace("\r\n", "\n");
        result = Regex.Replace(result, @"\n[ \t]+", "\n");
        Console.WriteLine($"after spaces compression: {result.Length}");
        return result;
    }
}