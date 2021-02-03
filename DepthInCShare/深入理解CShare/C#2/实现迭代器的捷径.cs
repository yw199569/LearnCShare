using System;
using System.Collections;
using System.Collections.Generic;

namespace DepthInCShare.深入理解CShare.C2
{
    public class Enumerable : IEnumerable
    {
        //实现迭代器的途径

        #region 手写迭代器
        object[] values;
        int startingPoint;
        public Enumerable(object[] values)
        {
            this.values = values;
            startingPoint = -1;
        }
        public bool MoveNext()//判断数组是否有还有下一个值
        {
            if (startingPoint < values.Length)
            {
                startingPoint++;
            }
            return startingPoint < values.Length;
        }
        public object Current//返回数组的每一个值
        {
            get
            {
                if (startingPoint == -1 || startingPoint > values.Length)//还没开始或者循环已经结束
                {
                    //throw new InvalidOperationException();
                }
                int index = startingPoint + values.Length;//循环总数相加  2（当前循环数）+8（数组长度）
                index = index % values.Length;//用总数余数组长度就能得到当前是在循环的哪一步   10%8=2
                return values[index];//  values[2] 返回
                //返回结果的封装
            }

        }

        public void Reset()//执行完成之后重置迭代原始值
        {
            startingPoint = -1;
        }



        #endregion

        #region 利用yield语句简化迭代器
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < values.Length; i++)
            {
                yield return values[(i + startingPoint) % values.Length];
                //使用yield return语句可一次返回一个元素
                //yield return 可通过foreach或linq查询来使用从迭代器方法返回的序列。foreach循环的每次迭代都会调用迭代器方法。迭代器方法运行到yield return语句的时候，会返回结果，并保留当前在代码种的位置，下次调用迭代器函数时，将从该位置重新开始执行


                //yield break 语句来终止迭代；

            }
        }
        #endregion

        #region 观察迭代器的工作流程

        static readonly string padding = new string(' ', 30);
        public static IEnumerable<int> CreateEnumerable()
        {
            Console.WriteLine("{0}Start of CreateEnumerable()", padding);//只会执行一次
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("{0} About to yield{1}", padding, i);//每次循环都从yield return出重新开始
                yield return i;//告诉编译器下次循环从这里开始
                if (i == 2)
                {
                    yield break;//结束循环
                }

            }
            Console.WriteLine("{0}Yielding finl value", padding);//下面也只会执行一次
            yield return -1;
            Console.WriteLine("{0}End of CreateEnumerable()", padding);
        }
        #endregion

    }
}
