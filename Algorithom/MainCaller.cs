using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithom
{
    class MainCaller
    {
        static void Main(string[] args)
        {
            var rndList = GetRandomList(10);

            // binary search
            //int targetIndex = BinarySearch.DoAlgorithom(new List<int> { 1, 2, 3, 4, 5, 6, 7 }, 1);
            //if (targetIndex.Equals(default))
            //{
            //    Console.WriteLine("找無此元素");
            //}
            //else
            //{
            //    Console.WriteLine($"目標index:{targetIndex}");
            //}

            // selection sort 
            //Func<List<int>> selectionSort = () =>
            //{
            //    var result = SelectionSort.DoAlgorithom(rndList);
            //    return result;
            //};
            //var watchSelection = StopWatcher(selectionSort);
            //Console.WriteLine(watchSelection.Ms);

            //// insertion sort
            //Func<List<int>> insertionSort = () =>
            //{
            //    var result = InsertionSort.DoAlgorithm(rndList);
            //    return result;
            //};
            //var watchInsertion = StopWatcher(insertionSort);
            //Console.WriteLine(watchInsertion.Ms);

            var a = BubbleSort.DoAlgorithom(rndList);
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine(); 
        }

        /// <summary>
        /// 觀察執行毫秒數，將會傳出毫秒數跟已經排序好的集合
        /// </summary>
        /// <param name="func">要進行觀察的Func</param>
        public static (long Ms, List<int> SortedList) StopWatcher(Func<List<int>> func)
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
