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

        //https://leetcode-cn.com/problems/permutations/description/
        #region 46. 全排列
        public static IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();

            P(nums, 0, nums.Length - 1, res);

            return res;
        }
        private static void P(int[] nums, int start, int end, IList<IList<int>> res)
        {
            if(start != end)
            {
                for(int i = start; i <= end; i++)
                {
                    Swap(nums, i, start);
                    P(nums, start + 1, end, res);
                    Swap(nums, i, start);
                }
            }
            else
            {
                IList<int> l = new List<int>();
                for(int i = 0; i <= end; i++)
                    l.Add(nums[i]);
                res.Add(l);
            }
        }
        private static void Swap(int[] nums, int i, int j)
        {
            int t = nums[i];
            nums[i] = nums[j];
            nums[j] = t;
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

        //https://leetcode-cn.com/problems/sort-colors/description/
        #region 75. 分类颜色
        public static void SortColors(int[] nums)
        {
            QuickSort(nums);
        }

        public static void QuickSort(int[] nums)
        {
            Sort(nums, 0, nums.Length - 1);
        }
        private static void Sort(int[] nums, int left, int right)
        {
            if(left >= right)
                return;

            int index = Partition(nums, left, right);
            Sort(nums, left, index - 1);
            Sort(nums, index + 1, right);
        }
        private static int Partition(int[] nums, int left, int right)
        {
            int center = left;
            int pivot = nums[right];

            for(int i = left; i < right; i++)
            {
                if(nums[i] <= pivot)
                {
                    Swap(nums, i, center++);
                }
            }
            Swap(nums, center, right);

            return center;
        }
        //private static void Swap(int[] nums, int i, int j)
        //{
        //    if(i == j)
        //        return;

        //    int t = nums[i];
        //    nums[i] = nums[j];
        //    nums[j] = t;
        //}
        #endregion

        //https://leetcode-cn.com/problems/linked-list-cycle-ii/description/
        #region 142. 环形链表 II
        public static ListNode DetectCycle(ListNode head)
        {
            if(head == null)
                return null;

            var walker = head;
            var runner = head;

            ListNode point = null;
            while(runner.next != null && runner.next.next != null)
            {
                walker = walker.next;
                runner = runner.next.next;
                if(walker == runner)
                {
                    point = walker;
                    break;
                }
            }

            if(point != null)
            {
                ListNode entrance = head;
                while(point.next != null)
                {
                    if(point == entrance)
                        return entrance;

                    point = point.next;
                    entrance = entrance.next;
                }

            }
            return null;
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

        //https://leetcode-cn.com/problems/find-the-duplicate-number/description/
        #region 287. 寻找重复数
        public static int FindDuplicate(int[] nums)
        {
            int[] arr = new int[nums.Length];
            for(int i = 0; i < nums.Length; i++)
            {
                int t = nums[i];
                if(arr[t] == 0)
                    arr[t] = nums[i];
                else
                    arr[t] = -1;
            }

            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] == -1)
                    return i;
            }
            return 0;
        }
        #endregion

        //https://leetcode-cn.com/problems/counting-bits/description/
        #region 338. Bit位计数
        public static int[] CountBits(int num)
        {
            int[] res = new int[num + 1];

            for(int i = 1; i <= num; i++)
                res[i] = CountBit(i);

            return res;
        }
        private static int CountBit(int n)
        {
            int i = 0;
            while(n > 0)
            {
                n &= n - 1;
                i++;
            }
            return i;
        }
        #endregion

        //https://leetcode-cn.com/problems/decode-string/description/
        #region 394. 字符串解码
        public static string DecodeString(string s)
        {
            int k = 0;
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < s.Length; i++)
            {
                if(s[i] >= '0' && s[i] <= '9')
                {
                    k = k * 10 + (s[i] - '0');
                    continue;
                }
                else if(s[i] == '[')
                {
                    int c = 1;
                    int j = i + 1;
                    while(c > 0)
                    {
                        if(s[j] == '[')
                            c++;
                        else if(s[j] == ']')
                            c--;
                        j++;
                    }
                    string str = DecodeString(s.Substring(i + 1, j - i - 2));
                    for(int m = 0; m < k; m++)
                    {
                        sb.Append(str);
                    }
                    i = j - 1;
                    k = 0;
                }
                else
                    sb.Append(s[i]);
            }

            return sb.ToString();
        }
        #endregion

        //https://leetcode-cn.com/problems/find-all-duplicates-in-an-array/description/
        #region 442. 数组中重复的数据
        public static IList<int> FindDuplicates(int[] nums)
        {
            List<int> res = new List<int>();
            for(int i = 0; i < nums.Length; i++)
            {
                int index = Math.Abs(nums[i]) - 1;
                if(nums[index] < 0)
                    res.Add(Math.Abs(index + 1));
                nums[index] *= -1;
            }
            return res;
        }
        #endregion

        //https://leetcode.com/problems/132-pattern/description/
        #region 456. 132 Pattern
        public static bool Find132pattern(int[] nums)
        {
            int p3 = int.MinValue;
            Stack<int> stack = new Stack<int>();
            for(int i = nums.Length - 1; i >= 0; i--)
            {
                if(nums[i] < p3)
                {
                    return true;
                }
                else
                {
                    while(stack.Count > 0 && nums[i] > stack.Peek())
                    {
                        p3 = stack.Pop();
                    }
                }
                stack.Push(nums[i]);
            }

            return false;
        }
        #endregion

        //https://leetcode-cn.com/problems/single-element-in-a-sorted-array/description/
        #region 540. 有序数组中的单一元素
        public static int SingleNonDuplicate(int[] nums)
        {
            for(int i = 0; i < nums.Length; i += 2)
            {
                if(i + 1 >= nums.Length)
                    return nums[i];
                if(nums[i] != nums[i + 1])
                    return nums[i];
            }
            return 0;
        }
        #endregion
    }
}
