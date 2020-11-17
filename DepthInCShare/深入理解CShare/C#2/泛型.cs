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


        //2、值类型约束，确保参数使用的类型是值类型
        //class ValueSample<T> where T:struct  --表示泛型参数必须是引用类型的

        //3、构造函数类型约束
        //构造函数约束表示为T:new(),必须是所有类型参数的最后一个约束，它检查类型实参是否有一个可用于创建类型实例的无参构造函数。
        // T CreateInstance<T>() when T:new()   该方法规定了参数必须有一个无参数的构造函数
        
        


    }
}