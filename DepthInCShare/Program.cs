using System;

namespace DepthInCShare
{
    class Program
    {
        static void Main(string[] args)
        {
            var templist = Part1.Products.GetSmallProducts();
            foreach (var item in templist)
            {
                System.Console.WriteLine(item);
            }

        }
    }
}
