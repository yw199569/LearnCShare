using System;
using System.Threading;
using System.Threading.Tasks;
namespace Part1.asyncANDawait异步函数
{
    public class async异步函数
    {
     //async用来中断代码的执行，而不阻塞线程。   
     
     public async void Step1()
     {

        System.Console.WriteLine("第0步");
        System.Console.WriteLine(await Step2()); 
        System.Console.WriteLine("第四步");
     }
     public static async Task<string> Step2()
     {
         System.Console.WriteLine("第一步");
         Thread.Sleep(1000);
         System.Console.WriteLine("第二步");
         return "方法执行一半";
     }
        //执行结果    
        // 第0步
        // 第一步
        // 第二步
        // 方法执行一半
        // 第四步
    }
}