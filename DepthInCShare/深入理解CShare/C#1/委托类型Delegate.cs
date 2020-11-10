namespace Part2.Delegate {
    delegate void StringProcessor (string input);

    public class Delegate {
        //委托类型实际上只是参数类型的一个列表以及一个返回类型。它规定了类型的实例能标示的操作
        //简单委托的构成
        //1、声明委托类型；
        //2、必须有一个方法包含了要执行的代码
        //3、必须创建一个委托实例
        //4、必须调用(invoke)委托实例

        //委托的实质是间接完成某种操作

        //声明委托类型
        //委托实例必须和委托的签名和返回值一致

        //委托是不易变的，创建了委托实例后，有关于它的一切就不能改变
        #region 简单实现委托定义和调用
        public void Test () {
            //委托到底用来做什么才会发挥最大用处
            StringProcessor pro1, pro2;
            pro1 = new StringProcessor (testdelegate);
            pro1.Invoke ("test1");
            pro1.Invoke ("test11");
            pro2 = new StringProcessor (testdelegate2);
            pro2.Invoke ("test2");
        }
        static void testdelegate (string input) {
            System.Console.WriteLine (input);
        }
        static void testdelegate2 (string input) {
            System.Console.WriteLine (input);
        }
        public void SimpleDelegate () {
            Person person = new Person ("Json");
            Person person1 = new Person ("Tom");
            StringProcessor processor;
            processor = new StringProcessor (person.Say);
            processor.Invoke ("Json,Hello");
        }
        #endregion

        #region 委托的合并和删除委托
        //Combine负责将两个委托实例的调用列表连接在一起
        //Remove负责从一个委托实例中删除另一个实例的调用列表
        public void TestDelegateAddRemove () {
            Person person = new Person ("Tom");
            StringProcessor pp = new StringProcessor (person.Say);

            StringProcessor ppp = new StringProcessor (BackGround.Note);
            var list = StringProcessor.Combine (pp, ppp);//把多个委托添加到委托链
            System.Delegate[] delegateList = list.GetInvocationList ();//获取当前委托的委托链列表
            foreach (StringProcessor item in delegateList) {
                item("a");//循环执行委托链里面的方法
            }
        }

        #endregion

    }
    public class Person {
        public string Name { get; set; }

        public Person (string name) {
            Name = name;
        }
        public void Say (string message) {
            System.Console.WriteLine ("{0}My Name Is {1}", message, Name);
        }
    }

    public class BackGround {
        public static void Note (string note) {
            System.Console.WriteLine (note);
        }
    }
}