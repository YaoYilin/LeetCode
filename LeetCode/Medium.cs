using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class Medium
    {
        //https://leetcode-cn.com/problems/add-two-numbers/description/
        #region 2. 两数相加
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode res = null;
            ListNode current = null;
            int carry = 0;
            while(l1 != null || l2 != null)
            {
                int n1 = 0, n2 = 0;
                if(l1 != null)
                {
                    n1 = l1.val;
                    l1 = l1.next;
                }
                if(l2 != null)
                {
                    n2 = l2.val;
                    l2 = l2.next;
                }
                int sum = n1 + n2 + carry;
                int val = sum % 10;
                carry = sum / 10;

                ListNode node = new ListNode(val);
                if(res == null)
                {
                    res = node;
                    current = res;
                }
                else
                {
                    current.next = node;
                    current = current.next;
                }
            }
            if(carry > 0)
            {
                current.next = new ListNode(carry);
                return res;
            }

            return res == null ? new ListNode(0) : res;
        }
        #endregion

        //https://leetcode-cn.com/problems/remove-nth-node-from-end-of-list/description/
        #region 19. 删除链表的倒数第N个节点
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            int index = 0;
            ListNode current = head;
            ListNode cache = head;
            ListNode cacheFast = head.next;
            while(current.next != null)
            {
                current = current.next;
                index++;

                if(index > n)
                {
                    cache = cache.next;
                    cacheFast = cache.next;
                }
            }
            if(n <= index)
                cache.next = cacheFast.next;
            else
                head = head.next;

            return head;
        }
        #endregion

        //https://leetcode-cn.com/problems/rotate-image/description/
        #region 48. 旋转图像
        public static void RotateImage(int[,] matrix)
        {
            int length = matrix.GetLength(0);
            for(int i = 0; i <= length / 2; i++)
                for(int j = i; j < length - i - 1; j++)
                    RotateFrom(i, j, matrix, length - 1);
        }
        private static void RotateFrom(int x, int y, int[,] matrix, int length)
        {
            int t = matrix[x, y];
            matrix[x, y] = matrix[length - y, x];
            matrix[length - y, x] = matrix[length - x, length - y];
            matrix[length - x, length - y] = matrix[y, length - x];
            matrix[y, length - x] = t;
        }
        #endregion

        //https://leetcode-cn.com/problems/spiral-matrix/description/
        #region 54. 螺旋矩阵
        public static IList<int> SpiralOrder(int[,] matrix)
        {
            int width = matrix.GetLength(1);
            int height = matrix.GetLength(0);
            int size = width * height;

            IList<int> res = new List<int>(size);

            int counter = 0;
            int round = 0;
            while(counter < size)
            {
                width--;
                height--;
                for(int i = round; i <= width; i++)
                {
                    res.Add(matrix[round, i]);
                    counter++;
                }

                for(int i = round + 1; i <= height; i++)
                {
                    res.Add(matrix[i, width]);
                    counter++;
                }

                for(int i = width - 1; i >= round && height > round; i--)
                {
                    res.Add(matrix[height, i]);
                    counter++;
                }

                for(int i = height - 1; i > round && width > round; i--)
                {
                    res.Add(matrix[i, round]);
                    counter++;
                }

                round++;
            }

            return res;
        }
        #endregion

        //https://leetcode-cn.com/problems/number-of-islands/description/
        #region TODO: 200. 岛屿的个数
        public static int NumIslands(char[,] grid)
        {
            for(int i = 0; i < grid.GetLength(0); i++)
            {
                for(int j = 0; j < grid.GetLength(1); j++)
                {

                }
            }


            return 0;
        }
        #endregion
    }
}
