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
    }
}
