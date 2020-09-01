using System;

namespace Part1.Extensions
{

    public static class Extensions
    {
        //C#扩展方法
        public static void SetExtensions(this Products test)
        {
            System.Console.WriteLine("实现Products的扩展方法");
        }
    }
}
