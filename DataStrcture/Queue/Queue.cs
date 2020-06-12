using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrcture.Queue
{
    /// <summary>
    /// 環狀佇列
    /// Tips: 先進先出，就像排隊一樣
    /// </summary>
    public class Queue
    {
        public Queue(int capacity)
        {
            // 問題: 每次DeQueue就得把所有資料往左挪，很沒效率
            // 解決辦法: 可實作環狀Queue來解決
            // 關鍵點: 
            // 1. rear為queue尾 front為queue頭
            // (判斷queue是否full)↓
            // 2. 從沒dequeue過 一直enqueue
            // 3. dequeue過 所以front不在queue[0]上
            if (capacity == 0)
            {
                throw new ArgumentException("大小不可為0");
            }

            Capacity = capacity;
            fQueue = new int[Capacity];
            fRear = -1;
            fFront = -1;
            fMaxItem = fQueue.Length;
        }

        /// <summary>
        /// 佇列大小
        /// </summary>
        public int Capacity { internal set; get; }

        /// <summary>
        /// 佇列容器
        /// </summary>
        private int[] fQueue;

        /// <summary>
        /// 指標，代表queue尾
        /// </summary>
        private int fRear;

        /// <summary>
        /// 指標，代表queue頭
        /// </summary>
        private int fFront;

        /// <summary>
        /// 代表Queue上限
        /// </summary>
        private int fMaxItem;

        /// <summary>
        /// 把新項目加入至佇列
        /// </summary>
        /// <param name="value">欲加入的值</param>
        public void EnQueue(int value)
        {
            // 例外處理
            if (IsFull())
            {
                throw new IndexOutOfRangeException("超出Queue大小");
            }

            // 第一次enqueue
            if (fFront == -1)
            {
                fFront = 0;
            }

            fRear = (fRear + 1) % fMaxItem;
            fQueue[fRear] = value;
        }

        /// <summary>
        /// 移除佇列最頂端的值並傳回數值
        /// </summary>
        /// <returns></returns>
        public int DeQueue()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException("Queue為空");
            }

            int result = 0;
            result = fQueue[fFront];
            fQueue[fFront] = 0;

            // 如果一樣 代表是空的了 所以設為初始
            if (fFront == fRear)
            {
                fFront = -1;
                fRear = -1;
            }
            else
            {
                fFront = (fFront + 1) % fMaxItem;
            }

            return result;
        }

        /// <summary>
        /// check the queue is full
        /// </summary>
        /// <returns></returns>
        private bool IsFull()
        {
            // 從沒dequeue過 一直enqueue
            if (fFront == 0 && fRear == fMaxItem - 1)
            {
                return true;
            }
            else if (fFront == fRear + 1) // dequeue過 所以front不在array[0]
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// check the queue is empty
        /// </summary>
        /// <returns></returns>
        private bool IsEmpty()
        {
            if (fFront == -1)
            {
                return true;
            }

            return false;
        }
    }
}
