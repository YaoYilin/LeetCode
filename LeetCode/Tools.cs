using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class Tools
    {
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
