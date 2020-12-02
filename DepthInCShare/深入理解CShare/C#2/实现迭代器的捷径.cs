using System;
using System.Collections;

namespace DepthInCShare.深入理解CShare.C2
{
    public class Enumerable : IEnumerable
    {
        //实现迭代器的途径
        object[] values;
        int startingPoint;
        #region 手写迭代器
        public Enumerable(object[] values)
        {
            this.values = values;
            startingPoint = -1;
        }
        public Enumerable(object[] values, int startingPoint)
        {
            this.values = values;
            this.startingPoint = startingPoint;
        }
        public bool MoveNext()
        {
            if (startingPoint < values.Length)
            {
                startingPoint++;
            }
            return startingPoint < values.Length;
        }
        public object Current
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

        public void Reset()
        {
            startingPoint = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
