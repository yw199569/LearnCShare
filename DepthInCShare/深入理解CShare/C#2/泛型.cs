using System;
using System.Collections;
using System.Collections.Generic;
namespace DepthInCShare.深入理解CShare.C2
{
    public class FanXing
    {
        //泛型有两种形式
        //1、泛型类型和泛型方法

        public Dictionary<object,object> DictionaryFanxing()
        {
            // Dictionary<TKey,TValue> 泛型字典
            Dictionary<object,object> dic=new Dictionary<object, object>();

            return dic;

        }
        //泛型方法
        static List<T> MakeList<T>(T First,T Second)
        {
            List<T> list=new List<T>();
            list.Add(First);
            list.Add(Second);
            return list;
        }

        //类型约束
        //1、引用类型约束，确保参数使用的类型参数是引用类型
        //struct RefSample<T> where T :class   --表示泛型必须是class类型的


        //1、值类型约束，确保参数使用的类型是值类型
        //class ValueSample<T> where T:struct  --表示泛型参数必须是引用类型的


    }
}