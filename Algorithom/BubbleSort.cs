using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithom
{
    /// <summary>
    /// Big-O (n^2)
    /// </summary>
    public class BubbleSort
    {
        public static List<int> DoAlgorithom(List<int> list)
        {
            if (list == default || list.Count == 0)
            {
                return list;
            }

            // bubble sort pseudo code
            // 注意! n-2是因為避免讀取超過陣列長度
            // 整個演算法是一直尋找 直到不用swap為止
            // repeat until no swaps
            //      for i from 0 to n-2 
            //          if i'th and i+1'th elements out of ordrer
            //              swap them

            // 每次都兩兩交換 第二層迴圈的作用是確保交換到最後最大的數會在最後(已排序) 以此類推直到做完...
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count - 1; j++)
                {
                    if (list[j] > list[i])
                    {
                        int temp = 0;
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }

            return list;
        }
    }
}
