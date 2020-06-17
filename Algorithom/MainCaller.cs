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
using DataStrcture.Graph;
using DataStrcture.LinkedList;
using DataStrcture.Queue;
using DataStrcture.Recursion;
using DataStrcture.Stack;

namespace Algorithom
{
    class MainCaller
    {
        static void Main(string[] args)
        {
            // TODO 整理到notion筆記
            // TODO 整理readme.md
            // TODO Merge Sort還未實作
            UndirectedAdjacenyList graph = new UndirectedAdjacenyList();
            
            //https://media.geeksforgeeks.org/wp-content/cdn-uploads/bfs1.png
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);

            graph.AddEdge(2, 4);
            graph.AddEdge(2, 5);
            graph.AddEdge(2, 1);

            graph.AddEdge(3, 1);
            graph.AddEdge(3, 5);

            graph.AddEdge(4, 2);
            graph.AddEdge(4, 5);
            graph.AddEdge(4, 6);

            graph.AddEdge(5, 3);
            graph.AddEdge(5, 2);
            graph.AddEdge(5, 4);
            graph.AddEdge(5, 6);
            
            graph.AddEdge(6, 4);
            graph.AddEdge(6, 5);

            var path = graph.Bfs(1, 6);
            foreach (var vertice in path)
            {
                Console.WriteLine(vertice);
            }
            Console.Read();
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
