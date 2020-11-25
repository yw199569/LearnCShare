using System.Reflection;
using System;
using System.Threading;
using System.IO;
namespace DepthInCShare.深入理解CShare.C2
{
    public class Delegates
    {
       
       delegate Stream StreamFactory();
        delegate void StringFactory(string str);

       static MemoryStream GenerateSampleData()
       {
           byte[] buffer=new byte[16];
           for (int i = 0; i < buffer.Length; i++)
           {
               buffer[i]=(byte)i;
           }
           return new MemoryStream(buffer);
       }
      //委托的协变
       public  static void MainMethod()
        {
            StreamFactory factory=GenerateSampleData;//利用委托的协变来转换方法组
            using(Stream stream=factory())//调用委托来获取stream
            {
                int data;
                while((data=stream.ReadByte())!=-1)
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
        
    }
}