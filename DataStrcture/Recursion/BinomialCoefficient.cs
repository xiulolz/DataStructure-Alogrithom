using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrcture.Recursion
{
    /// <summary>
    /// 二項式係數
    /// </summary>
    public class BinomialCoefficient
    {
        /// <summary>
        /// 根據組合公式C(n, k) => n! / k!(n-k)!，利用遞迴求解
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int C(int n, int k)
        {
            if (k == 0 || k == n)
            {
                return 1;
            }

            return C(n - 1, k) + C(n - 1, k - 1);
        }
    }
}
