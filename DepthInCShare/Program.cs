using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Part1;

namespace DepthInCShare
{
    class Program
    {
        public static string MyProperty
        {
            get => MyProperty;
            set => MyProperty = value ?? throw new ArgumentNullException(nameof(value), $"{nameof(MyProperty)} cannot be null");
        }
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
            #region nameof()方法
            //nameof()方法，返回的就是当前对象的名称
            // Console.WriteLine(nameof(System.String));------  String
            // int j = 5;
            // Console.WriteLine(nameof(j));  ------j
            // List<string> names = new List<string>();
            // Console.WriteLine(nameof(names)); ------names
            // Console.WriteLine(Program.MyProperty); ------MyProperty
            #endregion


            // string s=null;
            // System.Console.WriteLine(s?.Length);
            //?.如果问号左边为空则直接返回null

            // try 
            // {
            //     string s = null;
            //     Console.WriteLine(s.Length);

            // } catch (Exception e) when (false)
            // {
            // }
            //when可以加判断条件，条件返回bool，决定要不要进catch

            #region C#扩展方法
            //扩展方法是一个对无需对现有的类修改，就能实现现有的类，和不修改原来的类就能修改实现的方法
            // Products products=new Products();
            // products.TestExtensions();
            // Part1.Extensions.Extensions.SetExtensions(products);
            #endregion

        }
    }
}