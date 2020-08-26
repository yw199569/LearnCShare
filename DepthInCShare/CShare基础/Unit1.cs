    using System;
    namespace TestConsoleLog.C基础12
    {
    public class Unit1
    {
        public Unit1()
        {

        }
        //C#基础


        //值类型 数值，bool struct ，enum ,char
        //值类型的赋值总是复制了值类型的本身。
        //值类型在内存中占用的空间是它本身的长度

        //引用类型  字符串，对象
        //引用类型赋值是复制 了对象的引用。
        //引用类型在内存中需要为每一个对象单独分配空间，最少是8个字节，引用还需要额外占用字节

        //byte ，sbyte,short,ushort 在进行运算的时候C#会按需对他们进行隐式转换，转换到大一点的整数类型。
        public void test()
        {
            //short x = 1, y = 1;
            //short z= x + y;  //报错 因为short相加C#duishort进行了隐式的转换，转换到了int类型，返回的是int类型
        }


        //数值类型
        //编译器的类型判断：如果有小数点或者是指数形式，那么就是double类型

        //显式转换  隐式转换
        //拆箱装箱


        //运算符
        //除数变量为0，会抛出dividebyzeroexception 的异常        int x=0;  int a = 1/x;
        //被除数为0时，会编译报错  int a = 1/0;

        //整数值计算溢出时，变量的值会从0开始从新计算 默认是不抛出异常

        //checked操作符，运行的时候如果整形的表达式或者语句溢出，则会抛出overflowexception的错误
        //checked对float，double不起作用，因为他们有无限值。

        //folat,double这俩个类型有特殊的值
        //NaN
        //+∞
        //-∞
        //-0


        //NaN
        //使用==时NaN不等于任何一个值，包括NaN
        //使用object.Equals()时两个NaN是相等的




        //数组
        //数组的长度是固定的。创建就不能改变了
        //多维数组




    }
}
