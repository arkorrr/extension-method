using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class Task1
{
    public static bool AreBracketsValid(this string str)
    {
        var stack = new Stack<char>();
        foreach (char ch in str)
        {
            if (ch == '(' || ch == '{' || ch == '[')
                stack.Push(ch);
            else if (ch == ')' && (stack.Count == 0 || stack.Pop() != '(') ||
                     ch == '}' && (stack.Count == 0 || stack.Pop() != '{') ||
                     ch == ']' && (stack.Count == 0 || stack.Pop() != '['))
                return false;
        }
        return stack.Count == 0;
    }
    public static void Task()
    {
        string[] testStrings = { "{}[]", "(())", "[{}]", "[}", "[[{]}]" };
        foreach (string test in testStrings)
        {
            Console.WriteLine($"{test} валидность скобок: {test.AreBracketsValid()}");
        }
    }
}