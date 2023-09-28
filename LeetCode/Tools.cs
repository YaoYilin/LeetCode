using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace LeetCode
{
    public static class Tools
    {
        public static void UpdateReadMe()
        {
            string basePath = "https://github.com/YaoYilin/LeetCode/blob/master/LeetCode/";
            try
            {
                string readMe = Path.Combine(Environment.CurrentDirectory, "../../../README.md");
                string[] lines = File.ReadAllLines(readMe);
                string[] easy = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../Easy.cs"));
                string[] medium = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../Medium.cs"));
                string[] hard = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../Hard.cs"));


                string[] fileLines = null;
                string fileName = null;
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string str = line.Trim();
                    if (str.StartsWith("###"))
                    {
                        if (str.EndsWith("Easy"))
                        {
                            fileLines = easy;
                            fileName = "Easy.cs";
                        }
                        else if (str.EndsWith("Medium"))
                        {
                            fileLines = medium;
                            fileName = "Medium.cs";
                        }
                        else if (str.EndsWith("Hard"))
                        {
                            fileLines = hard;
                            fileName = "Hard.cs";
                        }
                    }

                    if (fileLines != null)
                    {
                        if (str.StartsWith("*"))
                        {
                            Regex regex = new Regex(@"(?<=[\[])[^]]*");
                            MatchCollection collection = regex.Matches(str);
                            if (collection.Count > 0)
                            {
                                string name = collection[0].Value;
                                int l = GetCodeLine(fileLines, name);
                                
                                Regex linkRegex = new Regex(@"(([^()]+))");
                                var match = linkRegex.Matches(regex.Replace(str, ""));
                                if (match.Count > 1)
                                {
                                    lines[i] = $"* [{name}]({match[1].Value}) (<u> [答案跳转]({basePath}{fileName}#L{l}) </u>)";
                                }
                            }
                        }
                    }
                }
                File.WriteAllLines(readMe, lines, Encoding.UTF8);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static int GetCodeLine(string[] group, string name)
        {
            for (int i = 0; i < group.Length; i++)
            {
                if (group[i].Contains(name))
                {
                    return i + 1;
                }
            }

            return 1;
        }
        
        public static char ToUpper(char c)
        {
            if('a' <= c && c <= 'z')
                c = (char)(c & ~0x20);
            return c;
        }

        public static char ToLower(char c)
        {
            if('A' <= c && c <= 'Z')
                c = (char)(c | 0x20);
            return c;
        }

        public static string Print(this int[,] m)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < m.GetLength(0); i++)
            {
            	for (int j = 0; j < m.GetLength(1); j++)
                    sb.Append((m[i, j]).ToString().PadLeft(4));

                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static string Print(this IList<int> l)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item  in l)
            {
                sb.AppendFormat("{0} ", item);
            }
            return sb.ToString();
        }

        public static string Print(this string[] l)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var item in l)
            {
                sb.AppendFormat("{0} ", item);
            }

            return sb.ToString();
        }
        public static string Print(this int[][] arr)
        {
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < arr.Length; i++)
            {
            	for (int j = 0; j < arr[i].Length; j++)
                    sb.Append(arr[i][j].ToString().PadLeft(4));
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
