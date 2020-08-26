using System;
using System.Collections;
using System.Linq;

namespace DepthInCShare
{
    class Program
    {
        static void Main(string[] args)
        {

            var arrayList = Part1.Products.GetSmallProducts();
            //foreach (var item in arrayList.OrderBy(x=>x.Name))
            //{
            //    Console.WriteLine(item);
            //}
            foreach (var item in arrayList)
            {

                if (item.Price>2)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}