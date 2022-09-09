using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class Easy
    {
        //https://leetcode-cn.com/problems/two-sum/description/
        #region 1. 两数之和
        public static int[] TwoSum(int[] nums, int target)
        {
            int[] arr = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] + nums[i] == target)
                    {
                        arr[0] = i;
                        arr[1] = j;
                        break;
                    }
                }
            }
            return arr;
        }
        #endregion

        //https://leetcode-cn.com/problems/reverse-integer/description/
        #region 7. 颠倒整数
        public static int Reverse(int x)
        {
            int result = 0;

            while (x != 0)
            {
                int tail = x % 10;
                int newResult = result * 10 + tail;
                if ((newResult - tail) / 10 != result)
                    return 0;

                result = newResult;
                x = x / 10;
            }

            return result;
        }
        #endregion
        
        //https://leetcode.cn/problems/palindrome-number/
        #region 9. 回文数
        public static bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }

            int cur = 0;
            int num = x;
            while(num != 0) 
            {
                cur = cur * 10 + num % 10;
                num /= 10;
            }
            return cur == x;
        }
        #endregion

        //https://leetcode-cn.com/problems/valid-parentheses/description/
        #region 20. 有效的括号
        public static bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '(')
                    stack.Push(')');
                else if (c == '{')
                    stack.Push('}');
                else if (c == '[')
                    stack.Push(']');
                else if (stack.Count == 0 || stack.Pop() != c)
                    return false;
            }

            return stack.Count == 0;
        }
        #endregion

        //https://leetcode-cn.com/problems/merge-two-sorted-lists/description/
        #region 21. 合并两个有序链表
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }

            if (l2 == null)
            {
                return l1;
            }

            if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists(l2.next, l1);
                return l2;
            }
        }

        public static ListNode MergeTwoLists_2(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(0);
            ListNode tail = dummy;
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    tail.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    tail.next = l2;
                    l2 = l2.next;
                }
                tail = tail.next;
            }
            tail.next = l1 != null ? l1 : l2;
            return dummy.next;
        }
        #endregion

        //https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array/description/
        #region 26. 删除排序数组中的重复项
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length < 2)
                return nums.Length;

            int index = 0;
            int v = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != v)
                {
                    index++;
                    v = nums[i];
                    nums[index] = v;
                }
            }

            return index + 1;
        }
        #endregion

        //https://leetcode-cn.com/problems/remove-element/description/
        #region 27. 移除元素
        public static int RemoveElement(int[] nums, int val)
        {
            int len = nums.Length;
            int i = 0;
            while (i != len)
            {
                if (nums[i] == val)
                {
                    nums[i] = nums[len - 1];
                    len--;
                }
                else
                {
                    i++;
                }
            }

            return len;
        }
        #endregion

        //https://leetcode-cn.com/problems/implement-strstr/
        #region 28. 实现 strStr()
        public static int StrStr(string haystack, string needle)
        {
            if (haystack.Length < needle.Length)
            {
                return -1;
            }
            if (string.IsNullOrEmpty(needle))
            {
                return 0;
            }
            char n = needle[0];
            for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
            {
                char c = haystack[i];
                if (c == n)
                {
                    bool isFound = true;
                    for (int j = 1; j < needle.Length; j++)
                    {
                        if (haystack[i + j] != needle[j])
                        {
                            isFound = false;
                            break;
                        }
                    }
                    if (isFound)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        #endregion

        //https://leetcode-cn.com/problems/search-insert-position/description/
        #region 35. 搜索插入位置
        public static int SearchInsert(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int v = nums[i];
                if (v >= target)
                    return i;
            }

            return nums.Length;
        }
        #endregion

        //https://leetcode-cn.com/problems/length-of-last-word/description/
        #region 58. 最后一个单词的长度
        public static int LengthOfLastWord(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;

            string str = s.TrimEnd();
            int i = str.Length - 1;
            int l = 0;
            while (i >= 0)
            {
                if (s[i--] == ' ')
                    break;
                l++;
            }
            return l;
        }
        #endregion

        //https://leetcode-cn.com/problems/plus-one/description/
        #region 66. 加一
        public static int[] PlusOne(int[] digits)
        {
            int carry = 1;
            LinkedList<int> res = new LinkedList<int>();

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int sum = digits[i] + carry;
                res.AddFirst(sum % 10);
                carry = sum / 10;
            }

            if (carry > 0)
                res.AddFirst(carry);

            return res.ToArray();
        }
        #endregion

        //https://leetcode-cn.com/problems/add-binary/description/
        #region 67. 二进制求和
        public static string AddBinary(string a, string b)
        {
            int i = a.Length - 1;
            int j = b.Length - 1;
            char carry = '0';
            LinkedList<char> list = new LinkedList<char>();
            while (i >= 0 || j >= 0)
            {
                char res = carry;
                char ca = i >= 0 ? a[i] : '0';
                char cb = j >= 0 ? b[j] : '0';
                res ^= ca;
                res ^= cb;

                if (ca == cb)
                    carry = ca;
                else
                    carry = res == '0' ? '1' : '0';

                list.AddFirst(res);
                i--;
                j--;
            }

            if (carry == '1')
                list.AddFirst(carry);

            return new string(list.ToArray());
        }
        #endregion

        //https://leetcode-cn.com/problems/sqrtx/description/
        #region 69. x 的平方根
        public static int MySqrt(int x)
        {
            int m = 0x40000000, y = 0, b;
            while (m != 0)
            {
                b = y | m;
                y >>= 1;
                if (x >= b)
                {
                    x = x - b;
                    y |= m;
                }
                m >>= 2;
            }
            return y;
            //if(x == 0)
            //    return 0;

            //int left = 0;
            //int right = x;
            //while(true)
            //{
            //    int middle = (right + left) / 2;
            //    if(middle == x / middle)
            //    {
            //        return middle;
            //    }

            //    if(middle > x / middle)
            //    {
            //        right = middle - 1;
            //    }
            //    else
            //    {
            //        if(middle + 1 > x / (middle + 1))
            //        {
            //            return middle;
            //        }
            //        left = middle + 1;
            //    }
            //}
        }
        #endregion

        //https://leetcode.cn/problems/climbing-stairs/
        #region 70. 爬楼梯
        public static int ClimbStairs(int n)
        {
            if(n <= 2)
            {
                return n;
            }
            int pre = 2, prePre = 1;
            for (int i = 2; i < n; i++)
            {
                int current = pre + prePre;
                prePre = pre;
                pre = current;
            }

            return pre;
        }
        #endregion

        //https://leetcode-cn.com/problems/remove-duplicates-from-sorted-list/description/
        #region 83. 删除排序链表中的重复元素
        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
                return null;

            var node = head;
            while (node.next != null)
            {
                if (node.val == node.next.val)
                {
                    node.next = node.next.next;
                }
                else
                {
                    node = node.next;
                }
            }

            return head;
        }
        #endregion

        //https://leetcode-cn.com/problems/merge-sorted-array/description/
        #region 88. 合并两个有序数组
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int end = m + n - 1;
            m--;
            n--;
            while (end >= 0)
            {
                int a = m >= 0 ? nums1[m] : int.MinValue;
                int b = n >= 0 ? nums2[n] : int.MinValue;
                if (a > b)
                {
                    nums1[end--] = a;
                    m--;
                }
                else
                {
                    nums1[end--] = b;
                    n--;
                }
            }
        }
        #endregion

        //https://leetcode-cn.com/problems/same-tree/description/
        public static bool IsSameTree(TreeNode p, TreeNode q) 
        {
            if (p == null && q == null)
            {
                return true;
            }

            if (p == null || q == null)
            {
                return false;
            }

            if (p.val != q.val)
            {
                return false;
            }

            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
        
        //https://leetcode-cn.com/problems/symmetric-tree/description/
        #region 101. 对称二叉树
        public static bool IsSymmetric(TreeNode root)
        {
            if (root != null)
                return IsEqual(root.left, root.right);

            return true;
        }
        private static bool IsEqual(TreeNode n1, TreeNode n2)
        {
            if (n1 == null && n2 == null)
                return true;

            if (n1 != null && n2 != null)
                return n1.val == n2.val && IsEqual(n1.left, n2.right) && IsEqual(n1.right, n2.left);

            return false;
        }

        #endregion

        //https://leetcode-cn.com/problems/maximum-depth-of-binary-tree/description/
        #region 104. 二叉树的最大深度
        public static int MaxDepth(TreeNode root)
        {
            return MaxDepth(root, 0);
        }
        private static int MaxDepth(TreeNode root, int level)
        {
            if (root == null)
                return level;
            int l = Math.Max(MaxDepth(root.left, level + 1), level);
            int r = Math.Max(MaxDepth(root.right, level + 1), level);
            return Math.Max(l, r);
        }

        #endregion

        //https://leetcode-cn.com/problems/minimum-depth-of-binary-tree/description/
        #region 111. 二叉树的最小深度
        public static int MinDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            int L = MinDepth(root.left), R = MinDepth(root.right);
            return L < R && L > 0 || R < 1 ? 1 + L : 1 + R;
        }
        #endregion

        //https://leetcode-cn.com/problems/pascals-triangle/description/
        #region 118. 帕斯卡三角形（杨辉三角）
        public static IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> res = new List<IList<int>>();
            for (int i = 0; i < numRows; i++)
                res.Add(GetRow(i)); // No. 119

            return res;
        }
        #endregion

        //https://leetcode-cn.com/problems/pascals-triangle-ii/description/
        #region 119. 帕斯卡三角形（杨辉三角）II
        /// <summary>
        /// https://en.wikipedia.org/wiki/Pascal%27s_triangle
        /// ∵ C[n, m] = n! / (m! * (n - m)!)
        /// ∴ C[n, m - 1] = n！ / ((m - 1)! * (n - m - 1)!)
        /// ∴ C[n, m] = C[n, m - 1] / (m * ( n - (m - 1)))
        /// thus C[n, m] = C[n, m - 1] * (n - m + 1) / m
        /// ∵ C[n, 0] = 1
        /// thus for index = 1 to row, we can get the result
        /// </summary>
        public static IList<int> GetRow(int rowIndex)
        {
            int[] row = new int[rowIndex + 1];
            row[0] = 1;
            for (int i = 1; i <= rowIndex; i++)
                row[i] = (int)((long)row[i - 1] * (rowIndex - (i - 1)) / (i));

            return new List<int>(row);
        }
        #endregion

        //https://leetcode-cn.com/problems/valid-palindrome/description/
        #region 125. 验证回文串
        public static bool IsPalindrome(string s)
        {
            int l = 0, r = s.Length - 1;
            while (l < r)
            {
                char c1 = default(char);
                while (l < s.Length)
                {
                    if (char.IsLetterOrDigit(s[l]))
                    {
                        c1 = Tools.ToUpper(s[l]);
                        break;
                    }
                    l++;
                }
                char c2 = default(char);
                while (r >= 0)
                {
                    if (char.IsLetterOrDigit(s[r]))
                    {
                        c2 = Tools.ToUpper(s[r]);
                        break;
                    }
                    r--;
                }
                if (c1 != c2)
                    return false;

                l++;
                r--;
            }
            return true;
        }

        /// <summary>
        /// C# source code is an array of ascii type enum, so is faster than below.
        /// char.IsLetterOrDigit(char c)
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [Obsolete("Use char.IsLetterOrDigit(char c) instead")]
        private static bool IsLetterOrDigit(char c)
        {
            if (c >= '0' && c <= '9')
                return true;
            if (c >= 'A' && c <= 'Z')
                return true;
            if (c >= 'a' && c <= 'z')
                return true;
            return false;
        }

        #endregion

        //https://leetcode-cn.com/problems/single-number/description/
        #region 136. 只出现一次的数字
        public static int SingleNumber(int[] nums)
        {
            int res = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                res ^= nums[i];
            }
            return res;
        }
        #endregion

        //https://leetcode-cn.com/problems/intersection-of-two-linked-lists/description/
        #region 160. 相交链表
        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
                return null;

            ListNode a = headA, b = headB;

            while (a != b)
            {
                a = a == null ? headB : a.next;
                b = b == null ? headA : b.next;
            }
            return a;
        }
        #endregion

        //https://leetcode-cn.com/problems/two-sum-ii-input-array-is-sorted/description/
        #region 167. 两数之和 II - 输入有序数组
        public static int[] TwoSum167(int[] numbers, int target)
        {
            int[] res = new int[2];

            if (numbers == null || numbers.Length < 2)
                return res;

            int l = 0, r = numbers.Length - 1;

            while (l < r)
            {
                int lv = numbers[l];
                int rv = numbers[r];
                int sum = lv + rv;
                if (sum == target)
                {
                    res[0] = l + 1;
                    res[1] = r + 1;
                    break;
                }
                else if (sum > target)
                    r--;
                else
                    l++;
            }

            return res;
        }
        #endregion

        //https://leetcode-cn.com/problems/excel-sheet-column-title/description/
        #region 168. Excel表列名称
        public static string ConvertToTitle(int n)
        {
            LinkedList<char> chars = new LinkedList<char>();
            while (true)
            {
                chars.AddFirst((char)(--n % 26 + 'A'));
                n /= 26;
                if (n <= 0)
                    break;
            }
            return new string(chars.ToArray());
        }
        #endregion

        //https://leetcode-cn.com/problems/excel-sheet-column-number/description/
        #region 171. Excel表列序号
        public static int TitleToNumber(string s)
        {
            int res = 0;
            for (int i = 0; i < s.Length; i++)
                res += (ParseExcelTitleChar(s[i]) * (int)Math.Pow(26, s.Length - i - 1));

            return res;
        }
        private static int ParseExcelTitleChar(char c)
        {
            if (c >= 'A' && c <= 'Z')
            {
                return c - 'A' + 1;
            }
            return 0;
        }
        #endregion

        //https://leetcode-cn.com/problems/factorial-trailing-zeroes/description/
        #region 172. 阶乘后的零
        /// <summary>
        ///  while 0 < n < 5 , f(n!) = 0;
        ///  while n >= 5，f(n!) = k + f(k!), there k = n / 5
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int TrailingZeroes(int n)
        {
            if (n < 5)
                return 0;
            return n / 5 + TrailingZeroes(n / 5);
        }
        #endregion

        //https://leetcode-cn.com/problems/rotate-array/description/
        #region 189. 旋转数组
        public static void Rotate(int[] nums, int k)
        {
            k = k % nums.Length;
            Array.Reverse(nums);

            Array.Reverse(nums, 0, k);
            Array.Reverse(nums, k, nums.Length - k);
        }
        #endregion

        //https://leetcode-cn.com/problems/reverse-bits/description/
        #region 190. 颠倒二进制位
        public static uint ReverseBits(uint n)
        {
            //uint[] bits = new uint[32];
            //uint num = n;
            //int i = 0;
            //while(num > 0)
            //{
            //    uint r = num % 2;
            //    bits[i++] = r;
            //    num /= 2;
            //}
            //uint res = 0;

            //uint p = 1;
            //for(int j = bits.Length - 1; j >= 0; j--)
            //{
            //    res += (bits[j] * p);
            //    p *= 2;
            //}

            //return res;

            uint m = 0;
            for (int i = 0; i < 32; i++)
            {
                m <<= 1;
                m |= n & 1;
                n >>= 1;
            }
            return m;
        }
        #endregion

        //https://leetcode-cn.com/problems/number-of-1-bits/description/
        #region 191. 位1的个数
        public static int HammingWeight(uint n)
        {
            int c = 0;
            while (n > 0)
            {
                n &= (n - 1);
                c++;
            }
            return c;
        }
        #endregion

        //https://leetcode-cn.com/problems/happy-number
        #region 202. 快乐数
        public static bool IsHappy(int n)
        {
            return IsHappy(n, new HashSet<int>());
        }
        private static bool IsHappy(int n, HashSet<int> set)
        {
            if (n == 1)
                return true;

            if (set.Contains(n))
                return false;
            else
                set.Add(n);

            int sum = 0;
            while (n > 0)
            {
                int r = n % 10;
                sum += (r * r);
                n /= 10;
            }

            return IsHappy(sum, set);
        }
        #endregion

        //https://leetcode-cn.com/problems/remove-linked-list-elements/description/
        #region 203. 删除链表中的节点
        public static ListNode RemoveElements(ListNode head, int val)
        {
            ListNode dummy = head;
            while (dummy != null)
            {
                ListNode next = dummy.next;
                if (next != null && next.val == val)
                    dummy.next = next.next;
                else
                    dummy = dummy.next;
            }

            if (head != null && head.val == val)
                head = head.next;

            return head;
        }
        #endregion

        //https://leetcode-cn.com/problems/count-primes/description/
        #region 204. 计数质数
        /// <summary>
        /// idea copy from https://leetcode.com/problems/count-primes/discuss/57588/My-simple-Java-solution
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int CountPrimes(int n)
        {
            bool[] notPrime = new bool[n];
            int count = 0;
            for (int i = 2; i < n; i++)
            {
                if (notPrime[i] == false)
                {
                    count++;
                    for (int j = 2; i * j < n; j++)
                        notPrime[i * j] = true;
                }
            }

            return count;
        }

        #endregion

        //https://leetcode-cn.com/problems/isomorphic-strings/description/
        #region 205. 同构字符串
        public static bool IsIsomorphic(string s, string t)
        {
            char[] m = new char[256];
            char[] n = new char[256];
            for (int i = 0; i < s.Length; i++)
            {
                var si = s[i];
                var ti = t[i];

                if (m[si] == 0 && n[ti] == 0)
                {
                    m[si] = ti;
                    n[ti] = si;
                }
                else
                {
                    if (m[si] != ti && n[ti] != si)
                        return false;
                }
            }

            return true;
        }
        #endregion

        //https://leetcode-cn.com/problems/reverse-linked-list/description/
        #region 206. 反转链表
        public static ListNode ReverseList(ListNode head)
        {
            ListNode list = null;
            while (head != null)
            {
                var next = head.next;
                head.next = list;
                list = head;
                head = next;
            }

            return list;
        }
        #endregion

        //https://leetcode-cn.com/problems/contains-duplicate/description/
        #region 217. 存在重复元素
        public static bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> hash = new HashSet<int>();
            foreach (var n in nums)
                if (!hash.Add(n))
                    return true;
            return false;
        }
        #endregion

        //https://leetcode-cn.com/problems/contains-duplicate-ii/description/
        #region 219. 存在重复元素 II
        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int key = nums[i];
                if (map.ContainsKey(key))
                {
                    if (Math.Abs(map[key] - i) <= k)
                        return true;
                    else
                        map[key] = i;
                }
                else
                    map.Add(key, i);
            }

            return false;
        }
        #endregion

        //https://leetcode-cn.com/problems/invert-binary-tree/description/
        #region 226. 翻转二叉树
        public static TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;
            var tree = root.left;
            root.left = root.right;
            root.right = tree;
            InvertTree(root.left);
            InvertTree(root.right);
            return root;
        }
        #endregion

        //https://leetcode-cn.com/problems/power-of-two/description/
        #region 231. 2的幂
        public static bool IsPowerOfTwo(int n)
        {
            //int c = 0;
            //while(n > 0)
            //{
            //    if((n & 1) == 1 && (++c > 1))
            //        return false;
            //    n >>= 1;
            //}
            //return c > 0;
            return n > 0 && (n & (n - 1)) == 0;
        }
        #endregion

        //https://leetcode-cn.com/problems/delete-node-in-a-linked-list/description/
        #region 237. 删除链表的结点
        public static void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }
        #endregion

        //https://leetcode-cn.com/problems/binary-tree-paths/description/
        #region 257. 二叉树的所有路径
        public static IList<string> BinaryTreePaths(TreeNode root)
        {
            IList<string> res = new List<string>();
            if (root != null)
                BinaryTreePaths(root, res, "");
            return res;
        }

        private static void BinaryTreePaths(TreeNode root, IList<string> res, string path)
        {
            if (root.left == null && root.right == null)
            {
                res.Add(path + root.val);
                return;
            }

            if (root.left != null)
                BinaryTreePaths(root.left, res, string.Format("{0}{1}->", path, root.val));

            if (root.right != null)
                BinaryTreePaths(root.right, res, string.Format("{0}{1}->", path, root.val));
        }
        #endregion

        //https://leetcode-cn.com/problems/add-digits/description/
        #region 258. 各位相加
        // 这个题放到Easy里，有点说不过去。
        // 参考这个：https://en.wikipedia.org/wiki/Digital_root#Congruence_formula
        public static int AddDigits(int num)
        {
            return 1 + (num - 1) % 9;
        }
        #endregion

        //https://leetcode-cn.com/problems/ugly-number/description/
        #region 263. 丑数
        public static bool IsUgly(int num)
        {
            if (num <= 0)
                return false;

            while (num % 2 == 0)
                num /= 2;

            while (num % 3 == 0)
                num /= 3;

            while (num % 5 == 0)
                num /= 5;

            return num == 1;
        }
        #endregion

        //https://leetcode-cn.com/problems/missing-number/description/
        #region 268. 缺失数字
        public static int MissingNumber(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
                sum += nums[i];

            return (nums.Length * (nums.Length + 1)) / 2 - sum;
        }
        #endregion

        //https://leetcode-cn.com/problems/first-bad-version/description/
        #region 278. 第一个错误的版本
        /* The isBadVersion API is defined in the parent class VersionControl.
            bool IsBadVersion(int version); */
        public static int FirstBadVersion(int n)
        {
            int left = 1, right = n;
            while (left < right)
            {
                int middle = left + (right - left) / 2;
                if (!IsBadVersion(middle))
                    left = middle + 1;
                else
                    right = middle;
            }
            return left;
        }
        private static bool IsBadVersion(int version)
        {
            return true;
        }
        #endregion

        //https://leetcode-cn.com/problems/move-zeroes/description/
        #region 283. 移动零
        public static void MoveZeroes(int[] nums)
        {
            int i = 0;
            while (i < nums.Length)
            {
                if (nums[i] == 0)
                {
                    int total = 0;
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        total += nums[j];
                        if (nums[j] != 0)
                        {
                            int t = nums[i];
                            nums[i] = nums[j];
                            nums[j] = t;
                            break;
                        }
                    }
                    if (total == 0)
                        return;
                }
                else
                {
                    i++;
                }
            }
        }
        #endregion

        //https://leetcode-cn.com/problems/range-sum-query-immutable/description/
        #region 303. 区域和检索 - 不可变
        public class NumArray
        {
            public int[] Nums { private set; get; }
            private int[] nums;
            public NumArray(int[] nums)
            {
                Nums = new int[nums.Length];
                this.nums = nums;
                if (nums.Length <= 0)
                    return;

                Nums[0] = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    Nums[i] = nums[i];
                    this.nums[i] += nums[i - 1];
                }
            }

            public int SumRange(int i, int j)
            {
                if (i == 0)
                    return nums[j];

                return nums[j] - nums[i - 1];
            }
        }
        #endregion

        //https://leetcode-cn.com/problems/power-of-three/description/
        #region 326. 3的幂
        /// <summary>
        /// 1162261467 is the biggest int number of power 3
        /// </summary>
        public static bool IsPowerOfThree(int n)
        {
            return (n > 0 && 1162261467 % n == 0);
        }
        #endregion

        //https://leetcode-cn.com/problems/power-of-four/description/
        #region 342. 4的幂
        public static bool IsPowerOfFour(int num)
        {
            return (((num - 1) & num) == 0) && ((num & 0x55555555) != 0);
        }
        #endregion

        //https://leetcode-cn.com/problems/reverse-string/description/
        #region 344. 反转字符串
        public static string ReverseString(string s)
        {
            char[] chars = new char[s.Length];
            int start = 0;
            int end = s.Length - 1;
            while (start <= end)
            {
                chars[start] = s[end];
                chars[end] = s[start];
                start++;
                end--;
            }
            return new string(chars);
        }
        #endregion

        //https://leetcode-cn.com/problems/reverse-vowels-of-a-string/description/
        #region 345. 反转字符串中的元音字母
        public static string ReverseVowels(string s)
        {
            char[] str = s.ToCharArray();

            int l = 0, r = str.Length - 1;
            bool lIsVowel = false, rIsVowel = false;
            while (l < r)
            {
                lIsVowel = IsVowel(str[l]);
                rIsVowel = IsVowel(str[r]);

                if (!lIsVowel)
                    l++;

                if (!rIsVowel)
                    r--;

                if (lIsVowel && rIsVowel)
                {
                    char t = str[l];
                    str[l] = str[r];
                    str[r] = t;
                    l++;
                    r--;
                }
            }

            return new string(str);
        }

        private static bool IsVowel(char c)
        {
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U';
        }
        #endregion

        //https://leetcode-cn.com/problems/valid-perfect-square/description/
        #region 367. 有效的完全平方数
        /// <summary>
        /// Sn = (1+ 2n - 1）* n)/2 = n²
        /// </summary>
        public static bool IsPerfectSquare(int num)
        {
            int i = 1;
            // a1 = 2*1 - 1;
            // an = 2n - 1;
            // Sn = (1+ 2n - 1）* n)/2 = n²
            while (num > 0)
            {
                num -= i;
                i += 2;
            }
            return num == 0;

            //int left = 1, right = num;
            //while(left < right)
            //{
            //    int middle = left + (right - left) / 2;
            //    long res = middle * middle;
            //    if(res == num)
            //        return true;
            //    else if(res > num)
            //        right = middle -1;
            //    else
            //        left = middle + 1;
            //}
            //return false;
        }
        #endregion

        //https://leetcode-cn.com/problems/sum-of-two-integers/description/
        #region 371. 两整数之和
        public static int GetSum(int a, int b)
        {
            if (b == 0)
                return a;

            int sum, carry;
            sum = a ^ b;
            carry = (a & b) << 1;
            return GetSum(sum, carry);
        }
        #endregion

        //https://leetcode-cn.com/problems/guess-number-higher-or-lower/description/
        #region 374. 猜数字大小
        public static int GuessNumber(int n)
        {
            int l = 1, r = n;
            while (true)
            {
                int m = (l & r) + ((l ^ r) >> 1);
                int res = Guess(m);
                if (res > 0)
                {
                    l = m + 1;
                }
                else if (res < 0)
                {
                    r = m - 1;
                }
                else
                {
                    return res;
                }
            }
        }
        /// <summary>
        /// 原题没有C#版本的，下面这个函数是我自己添加的，当做API以供调用。
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private static int Guess(int num)
        {
            int n = 6;
            if (num > n)
                return -1;
            if (num < n)
                return 1;
            return 0;
        }

        #endregion

        //https://leetcode-cn.com/problems/ransom-note/description/
        #region 383. 赎金信
        public static bool CanConstruct(string ransomNote, string magazine)
        {
            int[] arr = new int['z' + 1];
            for (int i = 0; i < magazine.Length; i++)
                arr[magazine[i]]++;

            for (int i = 0; i < ransomNote.Length; i++)
                if (arr[ransomNote[i]]-- <= 0)
                    return false;

            return true;
        }
        #endregion

        //https://leetcode-cn.com/problems/first-unique-character-in-a-string/description/
        #region 387. 字符串中的第一个唯一字符
        public static int FirstUniqChar(string s)
        {
            int[] asicii = new int['z' + 1];
            int[] chars = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (asicii[c] == 0)
                {
                    chars[i] = c;
                    asicii[c] = i + 1;
                }
                else
                {
                    chars[asicii[c] - 1] = -1;
                }
            }

            for (int i = 0; i < chars.Length; i++)
                if (chars[i] > 0)
                    return i;

            return -1;
        }
        #endregion

        //https://leetcode-cn.com/problems/find-the-difference/description/
        #region 389. 找不同
        public static char FindTheDifference(string s, string t)
        {
            char res = default(char);
            for (int i = 0; i < s.Length; i++)
                res ^= s[i];
            for (int i = 0; i < t.Length; i++)
                res ^= t[i];

            return res;
        }
        #endregion

        //https://leetcode-cn.com/problems/sum-of-left-leaves/description/
        #region 404. 左叶子之和
        public static int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null)
                return 0;

            return SumLeft(root.left) + SumRight(root.right);
        }
        private static int SumLeft(TreeNode node)
        {
            if (node == null)
                return 0;

            if (node.left == null && node.right == null)
                return node.val;

            return SumLeft(node.left) + SumRight(node.right);
        }

        private static int SumRight(TreeNode node)
        {
            if (node == null)
                return 0;

            return SumLeft(node.left) + SumRight(node.right);
        }
        #endregion

        //https://leetcode-cn.com/problems/convert-a-number-to-hexadecimal/description/
        #region 405. 数字转换为十六进制数
        private static char[] hexs = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
        public static string ToHex(int num)
        {
            if (num == 0)
                return "0";

            LinkedList<char> res = new LinkedList<char>();
            long n = num & 0xFFFFFFFF;
            while (n != 0)
            {
                long low4 = n & 0xf;
                res.AddFirst(hexs[low4]);
                n >>= 4;
            }
            return new string(res.ToArray());
        }
        #endregion

        //https://leetcode-cn.com/problems/fizz-buzz/description/
        #region 412. Fizz Buzz
        public static IList<string> FizzBuzz(int n)
        {
            List<string> strs = new List<string>();

            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0)
                {
                    if (i % 5 == 0)
                    {
                        strs.Add("FizzBuzz");
                    }
                    else
                    {
                        strs.Add("Fizz");
                    }
                }
                else if (i % 5 == 0)
                {
                    if (i % 3 == 0)
                    {
                        strs.Add("FizzBuzz");
                    }
                    else
                    {
                        strs.Add("Buzz");
                    }
                }
                else
                {
                    strs.Add(i.ToString());
                }
            }

            return strs;
        }
        #endregion

        //https://leetcode-cn.com/problems/add-strings/description/
        #region 415. 字符串相加
        public static string AddStrings(string num1, string num2)
        {
            List<char> res = new List<char>();
            int carry = 0, sum = 0;
            int n1 = 0, n2 = 0;

            int i = 1;
            while ((num1.Length - i >= 0 || num2.Length - i >= 0) || carry > 0)
            {
                if (num1.Length - i >= 0)
                    n1 = num1[num1.Length - i] - '0';
                else
                    n1 = 0;

                if (num2.Length - i >= 0)
                    n2 = num2[num2.Length - i] - '0';
                else
                    n2 = 0;
                sum = n1 + n2 + carry;
                carry = sum / 10;
                sum %= 10;
                res.Insert(0, (char)(sum + '0'));
                i++;
            }

            return new string(res.ToArray());
        }
        #endregion

        //https://leetcode-cn.com/problems/string-compression/description/
        #region 443. 压缩字符串
        public static int Compress(char[] chars)
        {
            if (chars.Length < 2)
                return chars.Length;

            char target = chars[0];
            int len = 1;
            int index = 0;

            for (int i = 1; i <= chars.Length; i++)
            {
                char v;
                if (i < chars.Length)
                    v = chars[i];
                else
                    v = (char)0;
                if (target != v)
                {
                    chars[index] = target;
                    index++;
                    if (len > 1)
                    {
                        string l = len.ToString();
                        for (int k = 0; k < l.Length; k++)
                        {
                            chars[index] = l[k];
                            index++;
                        }
                    }
                    target = v;
                    len = 1;
                }
                else
                {
                    len++;
                }
            }

            return index;
        }
        #endregion

        //https://leetcode-cn.com/problems/find-all-numbers-disappeared-in-an-array/description/
        #region 448. 找到所有数组中消失的数字
        public static IList<int> FindDisappearedNumbers(int[] nums)
        {
            int[] arr = new int[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
                arr[nums[i]] = nums[i];

            List<int> res = new List<int>();
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] == 0)
                    res.Add(i);

            return res;
        }
        #endregion

        //https://leetcode-cn.com/problems/hamming-distance/description/
        #region 461. 汉明距离
        public static int HammingDistance(int x, int y)
        {
            int counter = 0;
            int r = x ^ y;
            while (r > 0)
            {
                r = r & (r - 1);
                counter++;
            }

            return counter;
        }
        #endregion

        //https://leetcode-cn.com/problems/island-perimeter/description/
        #region 463. 岛屿的周长
        public static int IslandPerimeter(int[,] grid)
        {
            int res = 0;
            int maxRow = grid.GetUpperBound(0);
            int maxCol = grid.GetUpperBound(1);
            int b, r;
            for (int row = -1; row <= maxRow; row++)
            {
                for (int col = -1; col <= maxCol; col++)
                {
                    int v = row < 0 || col < 0 ? 0 : grid[row, col];

                    b = col < 0 || row == maxRow ? 0 : grid[row + 1, col];
                    r = row < 0 || col == maxCol ? 0 : grid[row, col + 1];

                    if (v != b)
                        res++;
                    if (v != r)
                        res++;
                }
            }

            return res;
        }
        #endregion

        //https://leetcode-cn.com/problems/number-complement/description/
        #region 476. 数字的补数
        public static int FindComplement(int num)
        {
            int i = 1;

            while (i < num)
                i = i | (i << 1);

            return ~num & i;
        }
        #endregion

        //https://leetcode-cn.com/problems/max-consecutive-ones/description/
        #region 485. 最大连续1的个数
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int max = 0;
            int c = 0;
            foreach (var n in nums)
            {
                if (n == 0)
                {
                    max = Math.Max(c, max);
                    c = 0;
                }
                else
                {
                    c++;
                }
            }

            return Math.Max(c, max);
        }
        #endregion

        //https://leetcode-cn.com/problems/keyboard-row/description/
        #region 500. 键盘行
        public static string[] FindWords(string[] words)
        {
            int[] keyMap = new int['z' - 'A' + 1];
            string row1 = "QWERTYUIOP";
            string row2 = "ASDFGHJKL";
            string row3 = "ZXCVBNM";

            InitMap(row1, keyMap, 1);
            InitMap(row2, keyMap, 2);
            InitMap(row3, keyMap, 3);
            List<string> strs = new List<string>();
            foreach (var word in words)
            {
                if (IsInOneLine(word, keyMap))
                    strs.Add(word);
            }

            return strs.ToArray();
        }
        private static void InitMap(string str, int[] keyMap, int row)
        {
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                keyMap[c - 'A'] = row;
                keyMap[c - 'A' + 'a' - 'A'] = row;
            }
        }
        private static bool IsInOneLine(string str, int[] keyMap)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            if (str.Length == 1)
                return true;

            int basic = keyMap[str[0] - 'A'];
            for (int i = 1; i < str.Length; i++)
            {
                if (keyMap[str[i] - 'A'] != basic)
                    return false;
            }

            return true;
        }
        #endregion

        //https://leetcode-cn.com/problems/base-7/description/
        #region 504. 七进制数
        public static string ConvertToBase7(int num)
        {
            if (num == 0)
                return "0";

            Stack<char> res = new Stack<char>();
            bool addSymble = false;
            if (num < 0)
            {
                addSymble = true;
                num = -num;
            }

            while (num > 0)
            {
                res.Push((char)(num % 7 + '0'));
                num /= 7;
            }

            if (addSymble)
                res.Push('-');
            return new string(res.ToArray());
        }
        #endregion

        //https://leetcode-cn.com/problems/detect-capital/description/
        #region 520. 检测大写字母
        public static bool DetectCapitalUse(string word)
        {
            if (word.Length <= 1)
                return true;

            if (word.Length <= 2)
            {
                if (IsCaptital(word[0]))
                    return true;

                if ((!IsCaptital(word[0]) && !IsCaptital(word[1])))
                    return true;

                if ((IsCaptital(word[0]) && IsCaptital(word[1])))
                    return true;

                return false;
            }

            for (int i = 0; i <= word.Length - 3; i++)
            {
                if (IsCaptital(word[i]) && IsCaptital(word[i + 1]) && IsCaptital(word[i + 2]))
                    continue;

                if (!IsCaptital(word[i]) && !IsCaptital(word[i + 1]) && !IsCaptital(word[i + 2]))
                    continue;

                if (IsCaptital(word[i]) && !IsCaptital(word[i + 1]) && !IsCaptital(word[i + 2]))
                    continue;

                return false;
            }

            return true;
        }
        private static bool IsCaptital(char c)
        {
            return c - 'a' < 0;
        }
        #endregion

        //https://leetcode-cn.com/problems/reverse-string-ii/description/
        #region 541. 反转字符串 II
        public static string ReverseStr(string s, int k)
        {
            char[] str = s.ToArray();
            int l = s.Length;
            if (l == 0)
                return string.Empty;

            if (k > l)
                Swap(str, 0, l);
            else
                for (int i = 0; i < l;)
                {
                    int j = Math.Min(i + k, l);
                    Swap(str, i, j);
                    i += 2 * k;
                }

            return new string(str);
        }
        private static void Swap(char[] chars, int start, int end)
        {
            while (start < end)
            {
                char c = chars[start];
                chars[start++] = chars[--end];
                chars[end] = c;
            }
        }
        #endregion

        //https://leetcode-cn.com/problems/reverse-words-in-a-string-iii/description/
        #region 557. 反转字符串中的单词 III
        public static string ReverseWords(string s)
        {
            var chars = new char[s.Length];
            int start = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Equals(' '))
                {
                    chars[i] = ' ';
                    ReverseLetters(s, chars, start, i - 1);
                    start = i + 1;
                }
                else if (i == s.Length - 1)
                {
                    ReverseLetters(s, chars, start, s.Length - 1);
                }
            }

            return new string(chars);
        }
        private static void ReverseLetters(string s, char[] chars, int start, int end)
        {
            while (start <= end)
            {
                chars[start] = s[end];
                chars[end] = s[start];
                start++;
                end--;
            }
        }
        #endregion

        //https://leetcode.com/problems/array-partition-i/description/
        #region 561. 数组拆分 I
        public static int ArrayPairSum(int[] nums)
        {
            Array.Sort(nums);
            int sum = 0;
            for (int i = 0; i < nums.Length; i += 2)
                sum += nums[i];

            return sum;
        }
        #endregion

        //https://leetcode-cn.com/problems/merge-two-binary-trees/description/
        #region 617. 合并二叉树
        public static TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
                return null;

            int v = 0;
            if (t1 != null)
                v += t1.val;
            if (t2 != null)
                v += t2.val;

            var res = new TreeNode(v);

            res.left = MergeTrees(t1 != null ? t1.left : null, t2 != null ? t2.left : null);
            res.right = MergeTrees(t1 != null ? t1.right : null, t2 != null ? t2.right : null);

            return res;
        }
        #endregion

        //https://leetcode-cn.com/problems/sum-of-square-numbers/description/
        #region 633. 平方数之和
        public static bool JudgeSquareSum(int c)
        {
            int left = 0;
            int right = (int)Math.Sqrt(c);

            while (left <= right)
            {
                int r = left * left + right * right;
                if (r > c)
                    right--;
                else if (r < c)
                    left++;
                else
                    return true;
            }

            return false;
        }
        #endregion

        //https://leetcode-cn.com/problems/set-mismatch/description/
        #region 645. 错误的集合
        public static int[] FindErrorNums(int[] nums)
        {
            int[] res = new int[2];
            int sum = 0;
            foreach (var n in nums)
            {
                int i = Math.Abs(n);
                if (nums[i - 1] < 0)
                    res[0] = i;
                else
                    nums[i - 1] *= -1;
                sum += i;
            }
            res[1] = (1 + nums.Length) * nums.Length / 2 - sum + res[0];

            return res;
        }
        #endregion
        //https://leetcode-cn.com/problems/judge-route-circle/description/
        #region 657. 判断路线成圈
        public static bool JudgeCircle(string moves)
        {
            int res = 0;
            for (int i = 0; i < moves.Length; i++)
            {
                char c = moves[i];
                if (c == 'U')
                    res++;
                else if (c == 'D')
                    res--;
                else if (c == 'L')
                    res += 2;
                else if (c == 'R')
                    res -= 2;
            }
            return res == 0;
        }
        #endregion

        //https://leetcode-cn.com/problems/non-decreasing-array/description/
        #region 665. 非递减数列
        /// <summary>
        /// for more effective, can do not copy array
        /// there copy, because function name is CheckXXX, so it's better don't change original data
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool CheckPossibility(int[] nums)
        {
            int[] arr = new int[nums.Length];
            Array.Copy(nums, arr, nums.Length);
            bool isMabeyInvalid = false;
            int i = 1;
            while (i < arr.Length)
            {
                if (arr[i - 1] > arr[i])
                {
                    if (isMabeyInvalid)
                        return false;

                    if (i < 2 || arr[i - 2] < arr[i])
                        arr[i - 1] = arr[i];
                    else
                        arr[i] = arr[i - 1];
                    isMabeyInvalid = true;
                }
                else
                    i++;
            }

            return true;
        }
        #endregion

        //https://leetcode-cn.com/problems/binary-number-with-alternating-bits/description/
        #region 693. 交替位二进制数
        public static bool HasAlternatingBits(int n)
        {
            return (((long)n + (n >> 1) + 1) & ((long)n + (n >> 1))) == 0;
        }
        #endregion
        
        //https://leetcode-cn.com/problems/binary-search/

        #region 704. 二分查找
        public static int Search(int[] nums, int target)
        {
            int s = 0;
            int e = nums.Length - 1;
            int i = nums.Length / 2;

            while (s <= e)
            {
                int v = nums[i];
                if (v == target)
                {
                    return i;
                }
                
                if (v < target)
                {
                    s = i + 1;
                }
                else
                {
                    e = i - 1;
                }
                
                i = (e - s) / 2 + s;
            }
            
            return -1;
        }
        #endregion

        //https://leetcode-cn.com/problems/to-lower-case/description/
        #region 709. 转换成小写字母
        public static string ToLowerCase(string str)
        {
            var arr = str.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if ('A' <= c && c <= 'Z')
                    c = (char)(c | 0x20);
                arr[i] = c;
            }

            return new string(arr);
        }
        #endregion

        //https://leetcode-cn.com/problems/self-dividing-numbers/description/
        #region 728. 自除数
        public static IList<int> SelfDividingNumbers(int left, int right)
        {
            IList<int> res = new List<int>();
            for (int i = left; i <= right; i++)
            {
                int j = i;
                for (; j > 0; j /= 10)
                {
                    int a = j % 10;
                    if (a == 0)
                        break;

                    if (i % a != 0)
                        break;
                }
                if (j == 0)
                    res.Add(i);
            }

            return res;
        }
        #endregion

        //https://leetcode-cn.com/problems/prime-number-of-set-bits-in-binary-representation/description/
        #region 762. 二进制表示中质数个计算置位
        public static int CountPrimeSetBits(int L, int R)
        {
            int c = 0;
            for (int i = L; i <= R; i++)
                if (IsPrime(CountBit(i)))
                    c++;
            return c;
        }
        private static bool[] primeArray = new bool[] { false, false, true, true, false, true,
                             false, true, false, false, false, true,
                             false, true, false, false, false, true,
                             false, true, false, false, false, true };
        private static bool IsPrime(int num)
        {
            return primeArray[num];
        }
        private static int CountBit(int num)
        {
            int res = 0;
            while (num > 0)
            {
                num &= (num - 1);
                res++;
            }
            return res;
        }
        #endregion

        //https://leetcode-cn.com/problems/toeplitz-matrix/description/
        #region 766. 托普利茨矩阵
        public static bool IsToeplitzMatrix(int[,] matrix)
        {
            for (int i = 1; i < matrix.GetLength(0); i++)
                for (int j = 1; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] != matrix[i - 1, j - 1])
                        return false;

            return true;
        }
        #endregion

        //https://leetcode-cn.com/problems/jewels-and-stones/description/
        #region 771. 宝石与石头
        public static int NumJewelsInStones(string J, string S)
        {
            int[] stones = new int['z' + 1];
            for (int i = 0; i < S.Length; i++)
                stones[S[i]]++;

            int count = 0;
            for (int i = 0; i < J.Length; i++)
                count += stones[J[i]];

            return count;
        }

        #endregion

        //https://leetcode-cn.com/problems/letter-case-permutation/description/
        #region 784. 字母大小写全排列
        public static IList<string> LetterCasePermutation(string S)
        {
            HashSet<string> res = new HashSet<string>();
            S = S.ToLower();
            res.Add(S);
            Permutation(S, 0, res);
            return res.ToList();
        }

        private static void Permutation(string S, int index, HashSet<string> res)
        {
            for (int i = index; i < S.Length; i++)
            {
                char c = S[i];
                if (char.IsLetter(c))
                {
                    var s = S.ToCharArray();
                    if (char.IsLower(c))
                    {
                        s[i] = char.ToUpper(c);
                        string _s = new string(s);
                        res.Add(_s);
                        Permutation(_s, index + 1, res);
                    }
                }
            }
        }
        #endregion

        //https://leetcode-cn.com/problems/rotate-string/description/
        #region 796. 旋转字符串
        public static bool RotateString(string A, string B)
        {
            if (A.Length != B.Length)
                return false;
            return (B + B).Contains(A);
        }
        #endregion

        //https://leetcode-cn.com/problems/unique-morse-code-words/description/
        #region 804. 唯一摩尔斯密码词
        public static int UniqueMorseRepresentations(string[] words)
        {
            HashSet<string> morses = new HashSet<string>();
            foreach (var word in words)
            {
                var m = WordToMorse(word);
                if (!morses.Contains(m))
                    morses.Add(m);
            }
            return morses.Count;
        }
        private static string[] morse = new string[] { ".-", "-...", "-.-.", "-..", ".",
            "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---",
            ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
        private static string WordToMorse(string word)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < word.Length; i++)
                sb.Append(morse[word[i] - 'a']);

            return sb.ToString();
        }
        #endregion

        //https://leetcode-cn.com/problems/most-common-word/description/
        #region 819. 最常见的单词
        public static string MostCommonWord(string paragraph, string[] banned)
        {
            var words = paragraph.ToLower().Split(new char[] { '!', '?', '\'', ',', ';', '.', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> map = new Dictionary<string, int>();
            HashSet<string> bannedSet = new HashSet<string>(banned);

            foreach (var word in words)
            {
                if (!bannedSet.Contains(word))
                {
                    if (map.ContainsKey(word))
                        map[word]++;
                    else
                        map.Add(word, 1);
                }
            }
            int max = 0;
            string w = string.Empty;
            foreach (var kvp in map)
            {
                if (kvp.Value > max)
                {
                    w = kvp.Key;
                    max = kvp.Value;
                }
            }

            return w;
        }
        #endregion

        //https://leetcode-cn.com/problems/shortest-distance-to-a-character/description/
        #region 821. 字符的最短距离
        public static int[] ShortestToChar(string S, char C)
        {
            int[] arr = new int[S.Length];
            for (int i = 0; i < S.Length; i++)
            {
                int l = i, r = i;
                while (true)
                {
                    if (S[l] == C)
                    {
                        arr[i] = i - l;
                        break;
                    }
                    if (S[r] == C)
                    {
                        arr[i] = r - i;
                        break;
                    }
                    l = --l < 0 ? 0 : l;
                    r = ++r >= S.Length ? S.Length - 1 : r;
                }
            }

            return arr;
        }
        #endregion

        //https://leetcode-cn.com/problems/goat-latin/description/
        #region 824. 山羊拉丁文
        public static string ToGoatLatin(string S)
        {
            var arr = S.Split(' ');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append(Transform(arr[i], i + 1));
                if (i != arr.Length - 1)
                    sb.Append(" ");
            }
            return sb.ToString();
        }
        private static string Transform(string s, int index)
        {
            if (s[0] == 'A' || s[0] == 'a'
                || s[0] == 'E' || s[0] == 'e'
                || s[0] == 'I' || s[0] == 'i'
                || s[0] == 'O' || s[0] == 'o'
                || s[0] == 'U' || s[0] == 'u')
            {
                char[] r = new char[2 + index];
                r[0] = 'm';
                r[1] = 'a';
                for (int i = 2; i < r.Length; i++)
                    r[i] = 'a';

                return s + new string(r);
            }
            else
            {
                char[] r = new char[s.Length + 2 + index];
                for (int i = 0; i < s.Length; i++)
                    r[i] = s[(i + 1) % s.Length];
                r[r.Length - 1 - index] = 'a';
                r[r.Length - 2 - index] = 'm';
                for (int i = s.Length + 2; i < s.Length + 2 + index; i++)
                    r[i] = 'a';
                return new string(r);
            }
        }
        #endregion

        //https://leetcode-cn.com/problems/flipping-an-image/description/
        #region 832. 翻转图像
        public static int[][] FlipAndInvertImage(int[][] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                int l = 0, r = A[i].Length - 1;
                while (l <= r)
                {
                    int t = A[i][l];
                    A[i][l] = A[i][r] ^ 1;
                    A[i][r] = t ^ 1;
                    l++;
                    r--;
                }
            }

            return A;
        }
        #endregion

        //https://leetcode-cn.com/problems/rectangle-overlap/description/
        #region 836. 矩形重叠
        public static bool IsRectangleOverlap(int[] rec1, int[] rec2)
        {
            return !(rec2[0] >= rec1[2] || rec2[1] >= rec1[3] || rec1[0] >= rec2[2] || rec1[1] >= rec2[3]);
        }
        #endregion

        //https://leetcode-cn.com/problems/backspace-string-compare/description/
        #region 844. 比较含退格的字符串
        public static bool BackspaceCompare(string S, string T)
        {
            return Trim(S).Equals(Trim(T));
        }
        private static string Trim(string s)
        {
            int i = 0;
            Stack<char> res = new Stack<char>();
            while (i < s.Length)
            {
                if (s[i] == '#')
                {
                    if (res.Count > 0)
                        res.Pop();
                }
                else
                {
                    res.Push(s[i]);
                }
                i++;
            }
            return new string(res.ToArray());
        }
        #endregion

        //https://leetcode-cn.com/problems/peak-index-in-a-mountain-array/description/
        #region 852. 山脉数组的峰顶索引
        public static int PeakIndexInMountainArray(int[] A)
        {
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] < A[i - 1])
                    return i - 1;
            }
            return A.Length;
        }
        #endregion

        //https://leetcode-cn.com/problems/buddy-strings/description/
        #region 859. 亲密字符串
        public static bool BuddyStrings(string A, string B)
        {
            if (A.Length != B.Length)
                return false;

            if (A.Equals(B))
            {
                HashSet<char> set = new HashSet<char>();

                for (int i = 0; i < A.Length; i++)
                    if (!set.Add(A[i]))
                        return true;

                return false;
            }

            int c = 0;
            int xor = 0;

            for (int i = 0; i < A.Length; i++)
            {
                char a = A[i], b = B[i];
                xor ^= (a ^ b);
                if (a != b)
                    c++;
            }

            return xor == 0 && c == 2;
        }
        #endregion

        //https://leetcode-cn.com/problems/lemonade-change/description/
        #region 860. 柠檬水找零
        public static bool LemonadeChange(int[] bills)
        {
            int five = 0;
            int ten = 0;
            foreach (var bill in bills)
            {
                if (bill == 5)
                {
                    five++;
                }
                else if (bill == 10)
                {
                    if (five == 0)
                        return false;
                    else
                        five--;

                    ten++;
                }
                else if (bill == 20)
                {
                    if (five == 0)
                    {
                        return false;
                    }
                    else
                    {
                        if (ten == 0)
                        {
                            if (five < 3)
                                return false;
                            else
                                five -= 3;
                        }
                        else
                        {
                            if (five == 0)
                            {
                                return false;
                            }
                            else
                            {
                                ten--;
                                five--;
                            }
                        }
                    }
                }
            }

            return true;
        }
        #endregion

        //https://leetcode-cn.com/problems/transpose-matrix/description/
        #region 868. 转置矩阵
        public static int[][] Transpose(int[][] A)
        {
            if (A == null || A.Length <= 0)
                return null;

            int w = A[0].Length;
            int[][] res = new int[w][];
            for (int i = 0; i < w; i++)
            {
                res[i] = new int[A.Length];
                for (int j = 0; j < A.Length; j++)
                {
                    res[i][j] = A[j][i];
                }
            }

            return res;
        }
        #endregion

        //https://leetcode-cn.com/contest/weekly-contest-94/problems/leaf-similar-trees/
        #region 872. 叶子相似的树
        public static bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            List<int> leaves1 = new List<int>();
            GetLeaf(root1, leaves1);
            List<int> leaves2 = new List<int>();
            GetLeaf(root2, leaves2);

            if (leaves1.Count != leaves2.Count)
                return false;

            for (int i = 0; i < leaves1.Count; i++)
                if (leaves1[i] != leaves2[i])
                    return false;

            return true;
        }

        private static void GetLeaf(TreeNode tree, List<int> list)
        {
            if (tree.left == null && tree.right == null)
            {
                list.Add(tree.val);
                return;
            }
            if (tree.left != null)
                GetLeaf(tree.left, list);
            if (tree.right != null)
                GetLeaf(tree.right, list);
        }

        #endregion

        //https://leetcode-cn.com/problems/middle-of-the-linked-list/description/
        #region 876. 链表的中间结点
        public static ListNode MiddleNode(ListNode head)
        {
            var slower = head;
            var faster = head;

            while (faster != null && faster.next != null)
            {
                faster = faster.next.next;
                slower = slower.next;
            }

            return slower;
        }
        #endregion

        //https://leetcode-cn.com/problems/uncommon-words-from-two-sentences/description/
        #region 884. 两句话中的不常见单词
        public static string[] UncommonFromSentences(string A, string B)
        {
            var a1 = A.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var a2 = B.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var s1 = RemoveDuplicate(a1);
            var s2 = RemoveDuplicate(a2);
            HashSet<string> res = new HashSet<string>();
            RemoveDuplicate(s1, a2, res);
            RemoveDuplicate(s2, a1, res);
            return res.ToArray();
        }

        private static HashSet<string> RemoveDuplicate(string[] arr)
        {
            HashSet<string> res = new HashSet<string>();
            HashSet<string> duplicate = new HashSet<string>();
            foreach (var item in arr)
            {
                if (!duplicate.Contains(item))
                {
                    if (!res.Add(item))
                    {
                        res.Remove(item);
                        duplicate.Add(item);
                    }
                }
            }
            return res;
        }

        private static void RemoveDuplicate(HashSet<string> set, string[] arr, HashSet<string> res)
        {
            HashSet<string> s = new HashSet<string>(arr);
            foreach (var item in set)
                if (!s.Contains(item))
                    res.Add(item);
        }

        #endregion

        //https://leetcode-cn.com/problems/sort-array-by-parity/description/
        #region 905. 按奇偶校验排序数组
        public static int[] SortArrayByParity(int[] A)
        {
            int l = 0, r = A.Length - 1;
            while (l < r)
            {
                int v = A[l];
                if ((v & 1) == 1)
                {
                    A[l] = A[r];
                    A[r] = v;
                    r--;
                }
                else
                {
                    l++;
                }
            }
            return A;
        }
        #endregion

        //https://leetcode-cn.com/problems/reverse-only-letters/description/
        #region 917. 仅仅反转字母
        public static string ReverseOnlyLetters(string S)
        {
            int l = 0, r = S.Length - 1;
            var arr = S.ToCharArray();
            while (l < r)
            {
                char lc = arr[l], rc = arr[r];
                if (!char.IsLetter(lc))
                {
                    l++;
                }
                else if (!char.IsLetter(rc))
                {
                    r--;
                }
                else
                {
                    arr[l] = rc;
                    arr[r] = lc;
                    l++;
                    r--;
                }
            }
            return new string(arr);
        }

        #endregion

        //https://leetcode-cn.com/problems/sort-array-by-parity-ii/description/
        #region 922. 按奇偶排序数组 II
        public static int[] SortArrayByParityII(int[] A)
        {
            int[] B = new int[A.Length];
            int m = 0, n = 1;
            for (int i = 0; i < A.Length; i++)
            {
                int x = A[i];
                if ((x & 1) == 0)
                {
                    B[m] = x;
                    m += 2;
                }
                else
                {
                    B[n] = x;
                    n += 2;
                }
            }

            return B;
        }
        #endregion

        //https://leetcode-cn.com/problems/unique-email-addresses/description/
        #region 929. 独特的电子邮件地址
        public static int NumUniqueEmails(string[] emails)
        {
            HashSet<string> mails = new HashSet<string>();

            foreach (var mail in emails)
            {
                mails.Add(ParseEmail(mail));
            }

            return mails.Count;
        }

        private static string ParseEmail(string email)
        {
            List<char> chars = new List<char>(email.Length);
            bool addAll = false;
            bool skip = false;
            for (int i = 0; i < email.Length; i++)
            {
                char c = email[i];
                if (addAll)
                {
                    chars.Add(c);
                    continue;
                }

                if (c == '@')
                {
                    addAll = true;
                    chars.Add(c);
                    continue;
                }

                if (skip)
                {
                    continue;
                }

                if (c == '+')
                {
                    skip = true;
                    continue;
                }

                if (c != '.')
                {
                    chars.Add(c);
                }
            }
            return new string(chars.ToArray());
        }
        #endregion

        //https://leetcode.cn/problems/complement-of-base-10-integer/
        #region 1009. 十进制整数的反码
        public static int BitwiseComplement(int n) 
        {
            if(n == 0)
            {
                return 1;
            }
            int l = 0;
            int m = n;
            while (m > 0)
            {
                m >>= 1;
                l = (l << 1) | 1;
            }
            return l & (~n);
        }
        #endregion
        
        //https://leetcode-cn.com/problems/day-of-the-week/comments/
        #region 1185. 一周中的第几天
        /// <summary>
        /// 蔡勒公式
        /// https://zh.wikipedia.org/wiki/%E8%94%A1%E5%8B%92%E5%85%AC%E5%BC%8F
        /// https://en.wikipedia.org/wiki/Zeller%27s_congruence
        /// w：星期（计算所得的数值对应的星期：0 - 星期日；1 - 星期一；2 - 星期二；3 - 星期三；4 - 星期四；5 - 星期五；6 - 星期六）[注 1]
        /// c：年份前两位数
        /// y：年份后两位数
        /// m：月（m的取值范围为3至14，即在蔡勒公式中，某年的1、2月要看作上一年的13、14月来计算，比如2003年1月1日要看作2002年的13月1日来计算）
        /// d：日
        /// []：称作高斯符号，代表向下取整，即，取不大于原数的最大整数。
        /// mod：同余（这里代表括号里的答案除以7后的余数）
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static string DayOfTheWeek(int day, int month, int year)
        {
            string[] array = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            int m = month;
            int y = year;
            if (month <= 2)
            {
                m += 12;
                y -= 1;
            }
            int c = y / 100;
            y = y % 100;
            int w = (y + y / 4 + c / 4 - 2 * c + (26 * (m + 1) / 10) + day - 1) % 7;
            return array[(w + 7) % 7];
        }
        #endregion
        
        //https://leetcode.cn/problems/rearrange-spaces-between-words/
        #region 1592. 重新排列单词间的空格
        public static string ReorderSpaces(string text)
        {
            if (text.Length <= 1)
            {
                return text;
            }
            string[] array = text.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            int total = 0;
            foreach (string s in array)
            {
                total += s.Length;
            }

            int l = 0;
            if (array.Length > 1)
            {
                l = (text.Length - total) / (array.Length - 1);
            }
            
            string str = string.Join("".PadRight(l, ' '), array);
            return str.PadRight(text.Length, ' ');
        }
        #endregion
        
        //https://leetcode.cn/problems/sum-of-digits-in-base-k/
        #region 1837. K 进制表示下的各位数字总和
        public static int SumBase(int n, int k)
        {
            int v = 0;
            while (n > 0)
            {
                v += n % k;
                n /= k;
            }

            return v;
        }
        #endregion
    }
}
