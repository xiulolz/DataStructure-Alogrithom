using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithom
{
    /// <summary>
    /// Big-O(nlogn)
    /// </summary>
    public class MergeSort
    {
        // pseudo code
        // On input of n elements
        //      if n < 2
        //          return 
        //      else
        //          sort left half of elements
        //          sort right half of elements
        //          merge sorted halves
        // 缺點是 n 如果很大就會占用不少的記憶體

        // merge sort 最重要的兩個點是 拆分 和 合併

        // 拆分
        // 1. 把大陣列切分成兩個陣列
        // 2. 兩個陣列再切半
        // 3. 以此類推直到只剩一個元素

        // 合併 *** 很重要
        // 1. 排序兩個只剩一個元素的小陣列並合併
        // 2. 把兩邊排序好的小陣列合併並排序成一個陣列
        // 3. 重複步驟二直到所有小陣列都合併成一個大陣列

        //https://www.youtube.com/watch?v=BWrfNs7k5CY

        // examples.
        // [41, 33, 17, 80, 61, 5, 55]
        //public static List<int> DoAlogrithom(List<int> list)
        //{
        //    if (list.Count == 1)
        //    {
        //        // merge ?
        //        return list;
        //    }

        //    if (list.Count > 2)
        //    {
        //        // split
        //        var mid = (list.Count - 1) / 2;
        //        List<int> left = new List<int>();
        //        List<int> right = new List<int>();
        //        DoAlogrithom(left);
        //        DoAlogrithom(right);
        //    }
            

        //    // merge

        //}

    }
}
