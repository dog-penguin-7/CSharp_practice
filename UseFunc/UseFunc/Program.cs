using System.Collections.Generic;
using System;

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

                var dataTimeParam = GetDataTimeParam();

                return result;
            });


            WriteLine("Hello World!");
            ReadLine();
        }

        public static SortedDictionary<string, string> GetDataTimeParam()
        {
            // 准备时间戳。ETC：1540220907287
            DateTime dtFrom = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long currentMillis = (DateTime.Now.Ticks - dtFrom.Ticks) / 10000;

            return new SortedDictionary<string, string>() {
            { "timestamp", currentMillis.ToString() }
        };
        }
    }

    
}