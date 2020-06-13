using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrcture.Recursion
{
    public class AckermanFunction
    {
        /// <summary>
        /// https://en.wikipedia.org/wiki/Ackermann_function
        /// http://notepad.yehyeh.net/Content/DS/CH02/7.php
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Ackerman(int m, int n)
        {
            // A(2,2) = 7, 呼叫了29次
            if (m == 0)
            {
                return n + 1;
            }

            if (n == 0)
            {
                return Ackerman(m - 1, 1);
            }

            return Ackerman(m - 1, Ackerman(m, n - 1));
        }
    }
}
