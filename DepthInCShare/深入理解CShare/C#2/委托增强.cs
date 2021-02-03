using System.Reflection;
using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;

namespace DepthInCShare.深入理解CShare.C2
{
    public class Delegates
    {

        delegate Stream StreamFactory();
        delegate void StringFactory(string str);

        static MemoryStream GenerateSampleData()
        {
            byte[] buffer = new byte[16];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)i;
            }
            return new MemoryStream(buffer);
        }
        //委托的协变
        public static void MainMethod()
        {
            StreamFactory factory = GenerateSampleData;//利用委托的协变来转换方法组
            using (Stream stream = factory())//调用委托来获取stream
            {
                int data;
                while ((data = stream.ReadByte()) != -1)
                {
                    Console.WriteLine(data);
                }
            }
            //委托参数的逆变   ----没搞懂有啥用处？？？？？
            StringFactory strFactory = ObjectSampleData;
            strFactory.Invoke("qqq");
        }

        static void ObjectSampleData(object obj)
        {

            Console.WriteLine(obj.ToString());
        }



        //无返回值匿名委托
        #region 无返回值匿名委托
        public delegate void Action<T>(T obj);

        public static void MainMethodNMWT()
        {
            Action<string> action = delegate (string text)
            {//匿名委托

                char[] chars = text.ToCharArray();
                Array.Reverse(chars);
                Console.WriteLine(new string(chars));
            };

            Action<int> actionInt = delegate (int text)
            {//匿名委托

                Console.WriteLine(Math.Sqrt(text));
            };

            List<int> x = new List<int>();
            x.Add(1);
            x.Add(2);
            x.Add(3);
            x.Add(4);
            x.Add(5);
            x.Add(6);

            x.ForEach(delegate (int i)//匿名委托方法
            {
                Console.WriteLine(Math.Sqrt(i));
            });



        }
        #endregion


        //有返回值的匿名委托
        #region 有返回值的匿名委托

        public delegate bool Predicate<T>(T obj);

        Predicate<int> isEven = delegate (int text)
        {//有返回值的匿名委托

            return text % 2 == 0;
        };


        //使用匿名方法排序文件
        static void SortAndShowFiles(string title, Comparison<FileInfo> SortOredr)
        {
            FileInfo[] files = new DirectoryInfo(@"/Users/yangwen/").GetFiles();
            Array.Sort(files, SortOredr);
            Console.WriteLine(title);
            foreach (var item in files)
            {
                Console.WriteLine("{0},{1} bytes", item.Name, item.Length);
            }
        }

        //调用委托方法
        public void DelegateMethod()
        {
            SortAndShowFiles("sorted by name :", delegate (FileInfo f1, FileInfo f2)//使用匿名委托方法调用
            {

                return f1.Name.CompareTo(f2.Name);
            });

            SortAndShowFiles("sorted by length :", delegate (FileInfo f1, FileInfo f2)//使用匿名方法调用
            {
                return f1.Length.CompareTo(f2.Length);
            });
            //使用相同的方法调用，实现不同的返回。
        }



        #endregion

        #region 匿名方法中的捕获变量
        //闭包 ： 将函数内部和函数外部链接起来的桥梁。使方法外边能够用到方法内部的变量。

        //匿名方法能使用声明在该匿名方法的内部定义的局部变量。
        //捕获的外部变量:是指在匿名函数中使用的外部变量；
        delegate void MethodInvoker();
        void EnclosingMethod()
        {
            int outerVariable = 5;
            string capturedVariable = "captured";

            if (DateTime.Now.Hour == 23)
            {
                int normalLocalVriable = DateTime.Now.Minute;
                Console.WriteLine(normalLocalVriable);
            }
            MethodInvoker invoker = delegate
            {
                string anonLocal = "local to anonymous method";
                Console.WriteLine(capturedVariable + anonLocal);

            };
        }

        public void TestMethod()
        {
            string capTured = "before x is created";
            MethodInvoker x = delegate
            {
                Console.WriteLine(capTured);//capTured就是捕获的外部变量
                capTured = "changed by x";
            };
            capTured = "directly before x is invoked";
            x();
            Console.WriteLine(capTured);
            capTured = "before second invocation";
            x();
            //使用捕获变量
        }



        //捕获变量到底有什么用处
        //写一个方法，返回低于特定年龄的所有人的另一个列表
        public class Person
        {
            public int Age { get; set; }
        }
        public List<Person> FindAllYoungerThan(List<Person> people, int limit)
        {
            return people.FindAll(delegate (Person person)
            {
                return person.Age < limit;
            });
        }

        //捕获的外部变量，只要有任何委托实例在引用它，他就会一直存在。




        #region 局部变量实例化
        List<MethodInvoker> list = new List<MethodInvoker>();
        public void testDelegateMethod()
        {
            for (int i = 0; i < 5; i++)
            {

                int counts = i * 10;
                list.Add(delegate//这个地方是把打印counts的方法添加进了委托数组里面
                {//每一个委托方法都捕获了当前循环的counts的数存进委托数组里

                    Console.WriteLine(counts);
                    counts++;
                });
            }
            foreach (var item in list)
            {
                item();
            }
            list[0]();
            list[0]();
            list[1]();
        }
        #endregion


        //共享和非共享的变量混合使用
        public void TestHEMethod()
        {
            MethodInvoker[] deleGate = new MethodInvoker[2];
            int outsid = 0;
            for (int i = 0; i < 2; i++)
            {
                int inside = 0;
                deleGate[i] = delegate
                {
                    Console.WriteLine("({0},{1})", outsid, inside);
                    outsid++;//外部变量没有实例化，会一直叠加
                    inside++;//内部变量，实例化了，同一个委托方法调用多次会叠加，不同的委托方法调用不会叠加

                };
            }
            MethodInvoker first = deleGate[0];
            MethodInvoker second = deleGate[1];
            first();
            first();
            first();

            second();
            second();
        }

        #endregion


        //捕获变量(匿名委托)的使用规则和小结
        //如果用或不用捕获变量时的代码同样简单，那就不要用。
        //捕获有for或foreach语句声明的变量之前，思考你的委托是否需要在循环迭代结束之后延续，以及是否想让它看到那个变量的后须值。如果不是，就要在循环内另建一个变量来复制你想要的值



        //要点
        //捕获的是变量，而不是创建委托实例时它的值；
        //捕获的变量的生存期被延长了，至少和捕捉它的委托一样长。
        //多个委托可以捕获同一个变量
        //在for循环的声明中创建的变量仅在循环持续期间有效----不会在每次循环迭代时都实例化
    }
}