using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrcture.Stack
{
    /// <summary>
    /// 堆疊資料結構
    /// Tips: 先進後出
    /// </summary>
    public class Stack
    {
        /// <summary>
        /// 初始化Stack
        /// </summary>
        /// <param name="capacity">堆疊大小</param>
        public Stack(int capacity)
        {
            // TODO Peek()
            // TODO impelment LinkedList Stack
            if (capacity == 0)
            {
                throw new ArgumentException("大小不可為0");
            }

            // 成員初始化
            Capacity = capacity;
            fStack = new int[capacity];
            fTop = 0;
        }

        /// <summary>
        /// 堆疊大小
        /// </summary>
        public int Capacity { internal set; get; }

        /// <summary>
        /// 堆疊容器
        /// </summary>
        private int[] fStack;

        /// <summary>
        /// 指標，紀錄是否到達堆疊頂端
        /// </summary>
        private int fTop;

        /// <summary>
        /// 將值插入堆疊最頂端
        /// </summary>
        /// <param name="value">欲插入的數值</param>
        public void Push(int value)
        {
            // 如果容量滿了就不必做事
            if (fTop == Capacity)
            {
                throw new IndexOutOfRangeException("超出Stack大小");
            }

            fStack[fTop] = value;
            fTop++;
        }

        /// <summary>
        /// 從堆疊最頂端傳回數值
        /// </summary>
        /// <returns></returns>
        public int Pop()
        {
            fTop--;
            if (fTop < 0)
            {
                throw new IndexOutOfRangeException("超出Stack大小");
            }

            var result = fStack[fTop];
            return result; 
        }
    }
}
