using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithom
{
    /// <summary>
    /// 2分搜尋法又稱為對半搜尋 <para/>
    /// 優點：O(logn) 非常快 <para/>
    /// 缺點：只能用在已經排序好的list 
    /// </summary>
    class BinarySearch
    {
        /// <summary>
        /// 將已排序好的集合進行2分搜尋法
        /// </summary>
        /// <param name="list">已經排序好的List</param>
        /// <param name="target">要尋找的目標</param>
        /// <returns>回傳目標index，若找不到則為default。</returns>
        public static int DoAlgorithom(List<int> list, int target)
        {
            // Context: 終極密碼

            // step1. 找到集合的中間值
            // step2. 集合的中間值 == target 代表找到了
            // step3. 集合的中間值 < target 代表 target在集合右半邊 
            // step4. 集合的中間值 > target 代表 target在集合左半邊
            // 重複找 直到找到為止
            int step = 0;
            int leftIndex = 0;
            int rightIndex = list.Count - 1;
            while (leftIndex <= rightIndex)
            {
                // 執行次數+1
                step++;

                // 取得中間數的index
                int midIndex = (leftIndex + rightIndex) / 2;
                if (list[midIndex] == target)
                {
                    // 代表找到了
                    return midIndex;
                }
                
                if (list[midIndex] > target)
                {
                    // 因為midElement比target還大 所以r移動到m-1的位置
                    // 這樣就可以縮小範圍
                    // 假設要找數字2
                    // [1, 2, 3, 4, 5, 6, 7]
                    //  l        m        r
                    // 移動過後就會變這樣
                    // [1, 2, 3, 4, 5, 6, 7]
                    //  l  m  r
                    rightIndex = midIndex - 1;
                }
                else
                {
                    // 代表element比target還小 所以l移動到m+1的位置
                    leftIndex = midIndex + 1;
                }
            }

            return default;
        }
    }
}
