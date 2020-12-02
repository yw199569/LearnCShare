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
            // #region Linq
            // Part1.LinqLearn.LinqLearn linq=new Part1.LinqLearn.LinqLearn();
            // //linq.TestProgram();
            // #endregion

            //Part1.asyncANDawait异步函数.async异步函数 async=new Part1.asyncANDawait异步函数.async异步函数();
            ////async.Step1();
            // Part2.Delegate.Delegate testdel=new Part2.Delegate.Delegate();

            //testdel.TestDelegateAddRemove();

            深入理解CShare.C2.Delegates delegates = new 深入理解CShare.C2.Delegates();
            //delegates.TestMethod();


            //delegates.TestHEMethod();
            object[] lis = new object[2];
            lis[0] = 1;
            lis[1] = 2;
            深入理解CShare.C2.Enumerable enumerable = new 深入理解CShare.C2.Enumerable(lis);
            while (enumerable.MoveNext())
            {
                Console.WriteLine(enumerable.Current);
            }
            enumerable.Reset();


        }
    }
}