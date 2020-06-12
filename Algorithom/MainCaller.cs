using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataStrcture.LinkedList;
using DataStrcture.Queue;
using DataStrcture.Stack;

namespace Algorithom
{
    class MainCaller
    {
        static void Main(string[] args)
        {

        }

        /// <summary>
        /// 觀察執行毫秒數，將會傳出毫秒數跟已經排序好的集合
        /// </summary>
        /// <param name="func">要進行觀察的Func</param>
        public static (long Ms, List<T> SortedList) StopWatcher<T>(Func<List<T>> func)
        {
            Stopwatch sw = Stopwatch.StartNew();
            var result = func.Invoke();
            sw.Stop();

            return (sw.ElapsedMilliseconds, result);
        }

        /// <summary>
        /// 取得指定大小的random list
        /// </summary>
        /// <param name="capacity">指定的陣列大小</param>
        /// <returns></returns>
        public static List<int> GetRandomList(int capacity)
        {
            if (capacity == 0)
            {
                throw new ArgumentException("陣列大小不可為0");
            }

            List<int> result = new List<int>();
            Random random = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < capacity; i++)
            {
                result.Add(random.Next(0, 1000));
            }

            return result;
        }
    }
}
