using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

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
            //排序 由自定义的实现icomprare接口 到icomprare<>强类型 到委托实现icomprare 到 linq,lambda表达式进化


            //查询集合
            //循环，打印
            List<Part1.Products> list = Part1.Products.GetSmallProducts();

            #region 使用委托的方法实现循环筛选打印
            //Predicate<>委托返回的是一个关于这个对象的条件表达式（判断条件） 这里Predicate<>返回的是Price>2这个条件；
            //这样做的好处是可以将一个条件传递给多个方法使用，方便更改；
            //           Predicate<Part1.Products> test=delegate(Part1.Products p) {
            //               return p.Price > 2;
            //};
            //           List<Part1.Products> matche = list.FindAll(test);
            //           Action<Part1.Products> print = Console.WriteLine;
            //           matche.ForEach(print);

            #endregion

            #region 使用委托匿名函数的方法实现判断循环
            //list.FindAll(delegate (Part1.Products p)
            //{
            //    return p.Price > 2;
            //}).ForEach(Console.WriteLine);
            #endregion

            #region 使用Lambda表达式实现判断循环
            //foreach (var item in list.Where(p=>p.Price>2))
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

        }
    }
}