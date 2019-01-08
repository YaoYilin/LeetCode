# -*- coding: utf-8 -*-

# 434. 字符串中的单词数
# https://leetcode-cn.com/problems/number-of-segments-in-a-string/

'''
统计字符串中的单词个数，这里的单词指的是连续的不是空格的字符。

请注意，你可以假定字符串里不包括任何不可打印的字符。

示例:

输入: "Hello, my name is John"
输出: 5
'''

class Solution:
    def countSegments(self, s):
        """
        :type s: str
        :rtype: int
        """
        i = 0
        f = False
        s = s.strip()
        if s == '':
            return 0

        for c in s:
            if c == ' ':
                f = True
            elif f:
                i += 1
                f = False

        return i + 1
