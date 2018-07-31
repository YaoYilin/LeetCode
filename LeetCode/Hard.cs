using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class Hard
    {
        //https://leetcode-cn.com/problems/median-of-two-sorted-arrays/description/
        #region 4. 两个排序数组的中位数
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int m = nums1.Length;
            int n = nums2.Length;
            if(m + n == 0)
                return 0;

            bool isOdd = (m + n) % 2 == 1;
            int i1 = 0, i2 = 0;
            int counter = 0;
            int end = isOdd ? (m + n) / 2 : (m + n) / 2 - 1;

            int[] longArray, shortArray;
            if(m > n)
            {
                longArray = nums1;
                shortArray = nums2;
            }
            else
            {
                longArray = nums2;
                shortArray = nums1;
            }

            if(m + n == 1)
                return longArray[0];

            while(true)
            {
                int n1 = longArray[i1];
                int n2;
                if(i2 < shortArray.Length)
                    n2 = shortArray[i2];
                else
                    n2 = longArray[i1 + 1];

                if(counter == end)
                {
                    if(isOdd)
                        return n1 > n2 ? n2 : n1;

                    int t = int.MaxValue;
                    if(n1 > n2 && i2 < shortArray.Length - 1)
                        t = shortArray[i2 + 1];
                    else if(n1 < n2 && i1 < longArray.Length - 1)
                        t = longArray[i1 + 1];

                    int t1 = n1 > t ? t : n1;
                    int t2 = n2 > t ? t : n2;
                    return (t1 + t2) / 2.0;
                }
                counter++;
                if(n1 > n2)
                    i2++;
                else
                    i1++;
            }
        }
        #endregion

        //https://leetcode-cn.com/problems/sudoku-solver/description/
        #region TODO: 37. 解数独
        public static void SolveSudoku(char[,] board)
        {

        }
        #endregion

        //https://leetcode-cn.com/problems/first-missing-positive/description/
        #region TODO: 41. 缺失的第一个正数
        public static int FirstMissingPositive(int[] nums)
        {
            if(nums.Length <= 0)
                return 1;

            int min = 0, max = 0;

            foreach(var n in nums)
            {
                if(n > max)
                    max = n;
                else if(n == min + 1)
                    min++;
            }

            return min == max ? max + 1 : min;
        }
        #endregion

        //https://leetcode-cn.com/problems/binary-tree-postorder-traversal/description/
        #region 145. 二叉树的后序遍历
        public static IList<int> PostorderTraversal(TreeNode root)
        {
            IList<int> res = new List<int>();
            Traversal(root, res);
            return res;
        }

        private static void Traversal(TreeNode root, IList<int> res)
        {
            if(root == null)
                return;

            Traversal(root.left, res);
            Traversal(root.right, res);
            res.Add(root.val);
        }
        #endregion

        //https://leetcode-cn.com/problems/number-of-digit-one/description/
        #region 233. 数字1的个数
        /// <summary>
        /// For each position, split the decimal representation into two parts, 
        /// for example split n=3141592 into a=31415 and b=92 when we're at m=100 for analyzing the hundreds-digit. 
        /// And then we know that the hundreds-digit of n is 1 for prefixes "" to "3141", i.e., 3142 times. 
        /// Each of those times is a streak, though. Because it's the hundreds-digit, 
        /// each streak is 100 long. So (a / 10 + 1) * 100 times, the hundreds-digit is 1.
        /// Consider the thousands-digit, i.e., when m = 1000.Then a=3141 and b = 592.
        /// The thousands-digit is 1 for prefixes "" to "314", so 315 times.
        /// And each time is a streak of 1000 numbers.However, since the thousands-digit is a 1, 
        /// the very last streak isn't 1000 numbers but only 593 numbers, 
        /// for the suffixes "000" to "592". So (a / 10 * 1000) + (b + 1) times, the thousands-digit is 1.
        /// The case distincton between the current digit/position being 0, 
        /// 1 and >=2 can easily be done in one expression.With(a + 8) / 10 you get the number of full streaks, 
        /// and a % 10 == 1 tells you whether to add a partial streak.
        /// See More: https://leetcode.com/problems/number-of-digit-one/discuss/64381/4+-lines-O(log-n)-C++JavaPython
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int CountDigitOne(int n)
        {
            long ones = 0;
            for(long m = 1; m <= n; m *= 10)
                ones += (n / m + 8) / 10 * m + (n / m % 10 == 1 ? n % m + 1 : 0);
            return (int)ones;
        }
        #endregion
    }
}
