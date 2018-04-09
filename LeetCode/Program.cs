using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {



            Console.WriteLine();
            Console.ReadLine();
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public ListNode(int[] arr)
        {
            val = arr[0];
            int i = 1;
            ListNode current = this;
            while(i < arr.Length)
            {
                current.next = new ListNode(arr[i]);
                current = current.next;
                i++;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            var l = this;
            while(true)
            {
                sb.Append(l.val);
                if(l.next != null)
                {
                    sb.Append(" --> ");
                    l = l.next;
                }
                else
                {
                    break;
                }
            }

            return sb.ToString();
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}


