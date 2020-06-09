using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrcture.LinkedList
{
    /// <summary>
    /// 環狀 Linked List
    /// </summary>
    public class CircularLinkedList : LinkedList
    {
        public CircularLinkedList() : base(){ }
        
        /// <summary>
        /// 將元素附加至末端，末端元素將會鏈結至第一個元素，形成環狀鏈結串列
        /// </summary>
        /// <param name="value">要append的元素</param>
        /// <returns></returns>
        public override Node Append(int value)
        {
            // NOTE: 如果忘記就下逐步看 關鍵點是First跟Last的指標
            // 最後一個節點會指回First節點
            Node result = new Node() { Value = value };
            if (First == default)
            {
                First = result;
            }
            else
            {
                Last.Next = result;
            }

            Last = result;
            Last.Next = First;

            Count++;

            return result;
        }

        public override Node InsertBefore(Node target, int value)
        {
            if (target == default)
            {
                return First;
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
            
            // 最後一個節點指向First
            Last.Next = First;

            Count++;

            return result;
        }

        public override void Concat(LinkedList linkedList)
        {
            if (linkedList == default)
            {
                return;
            }

            Last.Next = linkedList.First;
            Last = linkedList.Last;
            Last.Next = First;

            Count += linkedList.Count;
        }
    }
}
