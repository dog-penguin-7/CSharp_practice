using System.Collections.Generic;

using static System.Console;

using UseLock;

namespace UseFunc
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> lst = new List<string>();
            lst.Add("zhangsan");
            lst.Add("lisi");

            UseLockWithFunc funcWithLock = new UseLockWithFunc();
            var results = funcWithLock.ASyncExecTasks<string, string>(lst, (item) => {
                string result = string.Empty;

                return result;
            });


            WriteLine("Hello World!");
            ReadLine();
        }
    }
}