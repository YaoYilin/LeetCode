using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Sudoku
{
    public class Sudoku
    {


        public Sudoku(char[,] board)
        {

        }
    }

    public static class Line
    {
        public static bool IsValid(char[] nums)
        {
            HashSet<char> hash = new HashSet<char>();
            for(int i = 0; i < nums.Length; i++)
            {
                if(nums[i] == '.' || hash.Contains(nums[i]))
                {
                    return false;
                }
                hash.Add(nums[i]);
            }
            return true;
        }

        public static void Print(char[] nums, bool isRow)
        {
            if(isRow)
            {
                for(int i = 0; i < nums.Length; i++)
                {
                    Console.Write(nums[i]);
                    Console.Write(" ");
                }
            }
            else
            {
                for(int i = 0; i < nums.Length; i++)
                {
                    Console.WriteLine(nums[i]);
                }
            }
        }
    }

    public class Grid
    {
        private char[] Nums = new char[9];
        private char[] Original = new char[9];
        public Grid(char[] nums)
        {
            Array.Copy(nums, Original, nums.Length);
            Array.Copy(nums, Nums, nums.Length);
        }

        public char this[int index]
        {
            get
            {
                if(index < 0 || index >= 9)
                    throw new Exception();

                return Nums[index];
            }
            set
            {
                if(index < 0 || index >= 9)
                    throw new Exception();

                Nums[index] = value;
            }
        }

        public char[] GetRow(int row)
        {
            char[] arr = new char[3];
            Array.Copy(Nums, row * 3, arr, 0, 3);
            return arr;
        }

        public char[] GetColumn(int column)
        {
            char[] arr = new char[3];
            for(int i = 0; i < 3; i++)
            {
                arr[i] = Nums[column + i * 3];
            }
            return arr;
        }

        public bool IsValid()
        {
            HashSet<char> nums = new HashSet<char>();
            for(int i = 0; i < Nums.Length; i++)
            {
                if(Nums[i] == '.' || nums.Contains(Nums[i]))
                {
                    return false;
                }
                nums.Add(Nums[i]);
            }
            return true;
        }

        public void Reset()
        {
            Array.Copy(Original, Nums, Original.Length);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < Nums.Length; i += 3)
            {
                sb.AppendLine(string.Format("{0} {1} {2}", Nums[i], Nums[i + 1], Nums[i + 2]));
            }

            return sb.ToString();
        }
    }
}
