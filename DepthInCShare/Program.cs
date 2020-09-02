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
            #region Linq
            Part1.LinqLearn.LinqLearn linq=new Part1.LinqLearn.LinqLearn();
            //linq.TestProgram();
            #endregion
           

           Part1.asyncANDawait异步函数.async异步函数 async=new Part1.asyncANDawait异步函数.async异步函数();
           async.Step1();


        }
    }
}