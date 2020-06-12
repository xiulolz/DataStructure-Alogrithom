using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithom
{
    /// <summary>
    /// Big-O (n^2)
    /// </summary>
    public class InsertionSort
    {
        public static List<int> DoAlgorithm(List<int> list)
        {
            List<int> result = default;
            if (list == default || list.Count == 0)
            {
                return result;
            }

            // context: 玩撲克牌的時候的排序法
            result = list;

            // selection sort pseudo code
            // for i from 0 to n-1
            //      for j form 1 to n-1
            //          call 0'th through i-1'th elements the "soreted side"
            //          remove i'th element
            //          insert it into sorted side in order

            // [41, 33, 17, 80, 61, 5, 55]
            for (int i = 0; i < result.Count; i++)
            {
                // key is the item to be inserted
                int key = result[i];
                int j = i - 1;

                // 迴圈跟著i越變越大
                for (; j>=0 && result[j] > key; j--)
                {
                    // shift element to right side
                    // it means, make a place for "key"
                    // i的位置放result[j] 因為要留位置給key
                    result[j + 1] = result[j];
                }

                result[j + 1] = key;
            }

            return result;
        }
    }
}
