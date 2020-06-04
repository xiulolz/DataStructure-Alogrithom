using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithom
{
    /// <summary>
    /// Big-O：Quadratic Time O(n^2)
    /// </summary>
    public class SelectionSort
    {
        /// <summary>
        /// 使用選擇排序法將亂數集合進行排序
        /// </summary>
        /// <param name="list">亂數list</param>
        /// <returns>將會傳出已排序好的集合</returns>
        public static List<int> DoAlgorithom(List<int> list)
        {
            // [41, 33, 17, 80, 61, 5, 55]

            // 執行步驟為 n * (n+1) / 2
            // step1. 從集合中找到最小的數
            // step2. 丟到集合最左邊 代表已排序好
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                count++;
                int min = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    count++;
                    if (list[min] > list[j])
                    {
                        min = j;
                    }
                }

                // 沒有在同一個位置上 就做swap
                // ex. [5, 17, 33, 80, 61, 41, 55]
                //             ↑ 
                // 現在要從33開始往後找最小的數 因為33是最小的了 所以 min == i 不用swap
                if (min != i)
                {
                    int temp = 0;
                    temp = list[i];
                    list[i] = list[min];
                    list[min] = temp;
                }
            }

            return list;
        }
    }
}
