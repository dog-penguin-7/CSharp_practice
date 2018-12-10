using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using static System.Console;

namespace UseLock
{
    public class UseLock
    {
        public IList<TResult> ASyncExecTasks<TInput, TResult>(IList<TInput> lst, Func<TInput, TResult> invoke)
        {
            var tasks = new List<Task<TResult>>();
            var results = new List<TResult>();
            var dicASyncExecTaskPostUrl = new Dictionary<int, string>();

            foreach (var item in lst)
            {
                Func<object, TResult> fun = (obj) => {

                    TResult r = default(TResult);
                    var mid = System.Threading.Thread.CurrentThread.ManagedThreadId;

                    try
                    {
                        r = invoke((TInput)obj);
                    }
                    catch (Exception ex)
                    {
                        WriteLine(ex.ToString());
                    }

                    //从字典中去除。
                    lock (dicASyncExecTaskPostUrl)
                    {
                        dicASyncExecTaskPostUrl.Remove(mid);
                    }

                    return r;
                };

                var task = new Task<TResult>(fun, item);
                tasks.Add(task);
                task.Start();
            }

            Task.WaitAll(tasks.ToArray());

            //获取结果集。
            foreach (var _task in tasks)
            {
                if (null != _task.Result)
                {
                    results.Add(_task.Result);
                }
                else
                {
                    //累加异常次数。
                    WriteLine("失败 。。。");
                }
            }

            dicASyncExecTaskPostUrl.Clear();
            dicASyncExecTaskPostUrl = null;

            return results;
        }
    }
}