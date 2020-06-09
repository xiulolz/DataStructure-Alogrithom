using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrcture.LinkedList
{
    /// <summary>
    /// Node有兩個屬性
    /// 分別是：
    /// <list type="bullet">
    ///     <item> Data [存放資料]</item>
    ///     <item> Pointer [指標，指向下一個資料的位址]</item>
    /// </list>
    /// </summary>
    public class Node
    {
        /// <summary>
        /// 資料
        /// </summary>
        public int Value { set; get; }

        /// <summary>
        /// 指標，指向下一個資料位址
        /// </summary>
        public Node Next { set; get; }
    }
}
