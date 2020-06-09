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

namespace Algorithom
{
    class MainCaller
    {
        static void Main(string[] args)
        {
            //var rndList = GetRandomList(10);

            //// binary search
            //int targetIndex = BinarySearch.DoAlgorithom(new List<int> { 1, 2, 3, 4, 5, 6, 7 }, 1);
            //if (targetIndex.Equals(default))
            //{
            //    Console.WriteLine("找無此元素");
            //}
            //else
            //{
            //    Console.WriteLine($"目標index:{targetIndex}");
            //}

            //// selection sort 
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

            //var a = BubbleSort.DoAlgorithom(rndList);
            //foreach (var item in a)
            //{
            //    Console.WriteLine(item);
            //}

            //LinkedList linkedList = new LinkedList();
            //linkedList.Append(1);
            //linkedList.Append(2);
            //linkedList.Append(3);
            //var target = linkedList.Append(4);
            //linkedList.RemoveAt(target);
            //var insert5 = linkedList.InsertBefore(target, 5);
            //linkedList.RemoveAt(insert5);

            //LinkedList linkedList2 = new LinkedList();
            //linkedList2.Append(5);
            //linkedList2.Append(6);
            //linkedList.Concat(linkedList2);

            //var current = linkedList.First;
            //while (current != default)
            //{
            //    Console.WriteLine(current.Value);
            //    current = current.Next;
            //}

            //// 效率比較
            //// iterative 40175ms
            //// two pointer 9ms
            //Func<List<LinkedList>> func = () =>
            //{
            //    List<LinkedList> r = new List<LinkedList>();
            //    for (int i = 0; i < 100000; i++)
            //    {
            //        linkedList.Append(i);
            //    }
            //    r.Add(linkedList);
            //    return r;
            //};
            //var a = StopWatcher(func);
            //Console.WriteLine(a.Ms);

            CircularLinkedList circular = new CircularLinkedList();
            CircularLinkedList circular2 = new CircularLinkedList();
            circular.Append(1);
            circular.Append(2);
            circular.Append(3);
            var target = circular.Append(4);
            circular2.Append(5);
            circular2.Append(6);
            circular.Concat(circular2);



            Console.ReadLine(); 
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
