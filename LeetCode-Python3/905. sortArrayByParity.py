# -*- coding: utf-8 -*-

# 905. 按奇偶排序数组
# https://leetcode-cn.com/problems/sort-array-by-parity/

'''
给定一个非负整数数组 A，返回一个由 A 的所有偶数元素组成的数组，后面跟 A 的所有奇数元素。

你可以返回满足此条件的任何数组作为答案。

示例：

输入：[3,1,2,4]
输出：[2,4,3,1]
输出 [4,2,3,1]，[2,4,1,3] 和 [4,2,1,3] 也会被接受。

提示：

1 <= A.length <= 5000
0 <= A[i] <= 5000
'''

class Solution:
    def sortArrayByParity(self, A):
        """
        :type A: List[int]
        :rtype: List[int]
        """
        i = 0
        r = len(A) - 1
        while (i < r):
            t = A[i]
            if (t % 2 != 0):
                A[i] = A[r]
                A[r] = t
                r = r - 1
            else:
                i = i + 1
        return A
