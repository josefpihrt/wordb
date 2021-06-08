// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Wordb
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            foreach (string filePath in Directory.EnumerateFiles(@"..\..\..\..\..\data", "*.txt", SearchOption.AllDirectories))
                Normalize(filePath);

            foreach (string filePath in Directory.EnumerateFiles(@"..\..\..\..\..\data.other", "*.txt", SearchOption.AllDirectories))
                Normalize(filePath);
        }

        private static void Normalize(string path)
        {
            Console.WriteLine(path);

            List<string> values = File.ReadLines(path)
                .Where(f => !string.IsNullOrWhiteSpace(f))
                .Select(f => f.Trim())
                .Distinct(StringComparer.InvariantCulture)
                .OrderBy(f => f, StringComparer.InvariantCulture)
                .ToList();

            string content = string.Join(Environment.NewLine, values);

            if (!string.IsNullOrEmpty(content))
                content += Environment.NewLine;

            File.WriteAllText(path, content, Encoding.UTF8);
        }
    }
}
