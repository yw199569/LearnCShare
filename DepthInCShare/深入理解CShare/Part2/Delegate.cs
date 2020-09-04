namespace Part2.Delegate {
    public class Delegate {
        //简单委托的构成
        //1、声明委托类型；
        //2、必须有一个方法包含了要执行的代码
        //3、必须创建一个委托实例
        //4、必须调用(invoke)委托实例

        //声明委托类型
        //委托实例必须和委托的签名和返回值一致
        delegate void StringProcessor (string input);

        public void Test()
        {
            StringProcessor pro1,pro2;
            pro1=new StringProcessor(testdelegate);
            pro1.Invoke("test1");
            pro2=new StringProcessor(testdelegate2);
            pro2.Invoke("test2");
        }
        static void testdelegate(string input)
        {
            System.Console.WriteLine(input);
        }
        static void testdelegate2(string input)
        {
            System.Console.WriteLine(input);
        }
    }
}