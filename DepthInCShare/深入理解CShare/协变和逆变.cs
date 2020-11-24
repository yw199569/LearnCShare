namespace DepthInCShare.深入理解CShare
{
    public class 协变和逆变
    {
        //泛型委托
        public delegate T MyFuncA<T>();//不支持协变和逆变
        public delegate T MyFuncB<out T>();//支持协变
        public delegate T MyFuncC<out T>();//支持逆变
        MyFuncA<object> funcobjA=null;
        MyFuncA<string> funcstringA=null;
        MyFuncB<object> funcobjc=null;
        MyFuncB<string> funcstringd=null;
        MyFuncB<int> funcinta=null;
        MyFuncC<object> funcobjd=null;
        MyFuncC<string> funcstringe=null;


        //funcobjA=funcstringA  编译报错， MyFuncA不支持协变和逆变
        //funcobjc=funcstringd  协变成功  (协变 把子类赋值给父类)
        //funcstringe=funcobjd   逆变成功  (逆变 把父类赋值类子类)

    }
}