using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrcture.LinkedList
{
    /// <summary>
    /// 雙向環狀鏈結串列
    /// </summary>
    public class DoublyLinkedList : LinkedList
    {
        // HACK 還未實作RemoveAt
        public DoublyLinkedList() : base() { }

        public override Node Append(int value)
        {
            var result = new Node() { Value = value, Next = default, Previous = default };

            // Linear版本
            //if (First == default)
            //{
            //    First = result;
            //}
            //else
            //{
            //    Last.Next = result;
            //    result.Previous = Last;
            //}
            //Last = result;

            // Circular版本
            if (First == default)
            {
                First = result;
            }
            else
            {
                Last.Next = result;
                result.Previous = Last;
            }
            Last = result;
            Last.Next = First;
            First.Previous = Last;

            Count++;
            return result;
        }

        public override Node InsertBefore(Node target, int value)
        {
            if (target == default)
            {
                return default;
            }

            var current = First;
            var pre = new Node();
            var result = new Node() { Value = value };
            if (target == First)
            {
                Last.Next = result;
                result.Next = First;
                result.Previous = Last;
                First = result;
            }

            while (current != target)
            {
                current = current.Next;
            }

            // 1 <-> 2 <-> 3
            // 1 <-> 5 <-> 2 <-> 3
            pre = current.Previous;

            pre.Next = result; // 改掉1原本所指向的位址 1 -> "5"
            current.Previous = result;

            result.Next = current;
            result.Previous = pre;
             
            Count++;

            return result;
        }

        public override Node InsertAfter(Node target, int value)
        {
            if (target == default)
            {
                return default;
            }

            var current = First;
            var nextNode = new Node();
            var result = new Node() { Value = value };
            if (target == Last)
            {
                Last = result;
                Last.Next = First;
                First.Previous = Last;
            }

            // 找到target
            while (target != current)
            {
                current = current.Next;
            }

            // 用node去想 比較好理解
            // 關鍵點是: 處理toAppend的指標 還有原本node的指標
            // e.g. insertAfter 2 
            // 2 <-> 5 <-> 3
            nextNode = current.Next;

            nextNode.Previous = result; // 改掉3原本指向的位址 5 <- "3"(nextNode)
            current.Next = result; // 改掉2原本指向的位址 2 -> 5

            result.Next = nextNode; // "5" -> 3
            result.Previous = current; // 2 <- "5"

            Count++;

            return result;
        }

        public override void Concat(LinkedList linkedList)
        {
            if (linkedList == default)
            {
                return;
            }

            // 處理中間串接過程
            Last.Next = linkedList.First;
            linkedList.First.Previous = Last;
            Last = linkedList.Last;

            // 處理頭尾指標
            First.Previous = linkedList.Last;
            linkedList.Last.Next = First;

            Count += linkedList.Count;
        }
    }
}
