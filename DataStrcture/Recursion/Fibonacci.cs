using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrcture.Recursion
{
    /// <summary>
    /// 費氏數列
    /// </summary>
    public class Fibonacci
    {
        /// <summary>
        /// 當呼叫recusion的時候，系統會先將adress、區域變數...等 [Push] 進 [系統堆疊]
        /// 直到達到 [終止條件]，就會開始將adress等狀態資料由系統堆疊 [Pop] 出
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Fib(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            return Fib(n - 2) + Fib(n - 1);
        }
    }
}
