using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStrcture.LinkedList
{
    // TODO impelment generic LinkedList<T>

    /// <summary>
    /// Linear Linked List
    /// </summary>
    public class LinkedList
    {
        public LinkedList()
        {
            // 成員初始化
            Count = 0;
            First = default;
            Last = default;
        }

        /// <summary>
        /// 第一個Node
        /// </summary>
        public Node First { internal set; get; }

        /// <summary>
        /// 最後一個Node
        /// </summary>
        public Node Last { internal set; get; }

        /// <summary>
        /// LinkedList總數
        /// </summary>
        public int Count { internal set; get; }

        /// <summary>
        /// 新增資料到LinkedList最末端
        /// </summary>
        /// <param name="value">要新增的資料</param>
        public virtual Node Append(int value)
        {
            Node result = new Node() { Value = value };

            // 效率比較
            // iterative 40175ms
            // two pointer 9ms

            // Iterative O(n) 
            //var current = First;
            //if (First == default)
            //{
            //    First = result;
            //}
            //else
            //{
            //    while (current.Next != default)
            //    {
            //        // 找到最後一個 最後一個node一定沒指東西
            //        current = current.Next;
            //    }

            //    // 最後一個node指向新增的node
            //    current.Next = result;
            //}

            // NOTE 2個指標版本 比較不好懂 要下逐步去看 這個效率是O(1)
            // NOTE 關鍵點：觀察每個Node有誰Ref
            if (First == default)
            {
                First = result;
            }
            else
            {
                Last.Next = result;
            }
            Last = result;

            Count++;

            return result;
        }

        /// <summary>
        /// 將值插入指定node前
        /// </summary>
        /// <param name="target">要插入的目標</param>
        /// <param name="value">值</param>
        public virtual Node InsertBefore(Node target, int value)
        {
            if (target == default)
            {
                return default;
            }

            // 存下previous的原因是 
            // 1 -> 3的linkedlist 如果要在1後面插入2
            // 1 -> [toInsert] -> 3
            // 原本1指向3要改為指向result
            // 而result則指向3
            var previous = new Node();
            var current = First;
            var result = new Node() { Value = value };

            // 如果插在最前面
            if (target == First)
            {
                First = result;
            }

            while (current != target)
            {
                previous = current;
                current = current.Next;
            }

            previous.Next = result;
            result.Next = current;

            Count++;

            return result;
        }

        /// <summary>
        /// 將值插入現有node後
        /// </summary>
        /// <param name="target">要插入的目標</param>
        /// <param name="value">值</param>
        public virtual Node InsertAfter(Node target, int value)
        {
            if (target == default)
            {
                return default;
            }

            var current = First;
            var nextNode = new Node();
            var result = new Node() { Value = value };

            // 如果target跟Last相同
            if (target == Last)
            {
                Last = result;
            }

            while (target != current)
            {
                current = current.Next;
            }

            // 在2後面插入
            // 1 -> 2 -> 3 
            // 1 -> 2 -> result -> 3
            // 所以存下current.Next (3)
            // 然後result的下一個就會是Next(3)
            // 再把current(2).Next 指向 result
            nextNode = current.Next;
            result.Next = nextNode;
            current.Next = result;

            Count++;

            return result;
        }

        /// <summary>
        /// 刪除指定Node
        /// </summary>
        /// <param name="target">指定要刪除的目標</param>
        public virtual void RemoveAt(Node target)
        {
            if (target == default)
            {
                return;
            }

            // 刪除第一個
            if (target == First)
            {
                First = First.Next;
            }

            var current = First;
            var previous = new Node();
            while (target != current)
            {
                previous = current;
                current = current.Next;
            }
            if (target == Last)
            {
                Last = previous;
            }

            // 1 > 2 > 3 > 4, removeAt (3)
            // current = 3
            // 1 > 2 > 4, so 2 point to  4
            previous.Next = current.Next;

            Count--;
        }

        /// <summary>
        /// 串接兩個LinkedList
        /// </summary>
        /// <param name="linkedList">要進行串接的LinkedList</param>
        public virtual void Concat(LinkedList linkedList)
        {
            if (linkedList == default)
            {
                return;
            }

            Last.Next = linkedList.First;
            Last = linkedList.Last;

            Count += linkedList.Count;
        }
    }
}
