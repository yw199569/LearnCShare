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
            //排序 由自定义的实现icomprare接口 到icomprare<>强类型 到委托实现icomprare 到lambda表达式进化
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