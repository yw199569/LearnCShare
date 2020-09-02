namespace Part1.COMAndDynamic
{
    public class COMAndDynamic
    {
        #region Dynamic动态类型
        //c#4新增了一个dynamic类型，该类型是一个静态类型，在编译的时候会跳过静态类型的检查
        //dynamic类型可以隐式转换任意类型（Null除外）
        //dynamic也可以隐式转换成其他类型
        dynamic a="c";
            object obj=3;
            dynamic dyn=2;
            //obj+=3;  这里会报错提示object类型不能和int类型相加
        #endregion
    }
}