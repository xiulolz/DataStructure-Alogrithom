using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrcture.Recursion
{
    public class HanoiTower
    {
        /// <summary>
        /// 遞迴解河內塔
        /// </summary>
        /// <param name="disk">盤子數量</param>
        /// <param name="from">起點柱子</param>
        /// <param name="to">要搬到的終點柱子</param>
        /// <param name="by">輔助的柱子</param>
        public static void Hanoi(int disk, char from, char to, char by)
        {
            // 公式: F(n) = 2 * F(n-1) + 1
            // 證明: F(1) = 1, F(2) = 3 = 2^2 -1, F(3) = 7 = 2^3 - 1
            // 得證: 2^n - 1

            //          A       B       C
            //  1. n-1 from     to      by
            //  2.  n  from     by      to
            //  3. n-1  by      from    to
            if (disk == 1)
            {
                Console.WriteLine($"Move disk 1 from {from} to {to}");
                return;
            }

            Hanoi(disk - 1, from, by, to);
            Console.WriteLine($"Move disk {disk} from {from} to {to}");
            Hanoi(disk - 1, by, to, from);
        }
    }
}
