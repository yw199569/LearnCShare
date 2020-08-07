using System;
namespace testwebapi.Service
{
    public class ConsoleOutPut:IOutput
    {

        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}
