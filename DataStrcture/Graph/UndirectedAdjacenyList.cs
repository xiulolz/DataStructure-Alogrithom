using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataStrcture.Graph
{
    /// <summary>
    /// 無向鄰接串列
    /// </summary>
    public class UndirectedAdjacenyList
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public UndirectedAdjacenyList()
        {
            fAdjacenyList = new Dictionary<int, List<int>>();
        }

        /// <summary>
        /// 無向鄰接串列
        /// </summary>
        private Dictionary<int, List<int>> fAdjacenyList;

        /// <summary>
        /// 新增相鄰的節點
        /// </summary>
        /// <param name="vertice">節點</param>
        /// <param name="neighbour">相鄰的節點</param>
        public void AddEdge(int vertice, int neighbour)
        {
            // 找不到節點就新增
            if (!fAdjacenyList.TryGetValue(vertice, out List<int> edge))
            {
                edge = new List<int>();
                edge.Add(neighbour);
                fAdjacenyList[vertice] = edge;

                return;
            }

            edge.Add(neighbour);
        }

        #region 廣度優先搜尋

        /// <summary>
        /// 廣度優先搜尋，O(V+E)->Vertice+Edge，最差的情況就是全部都得跑過一遍才能搜尋到
        /// </summary>
        /// <param name="start">指定起點節點</param>
        /// <param name="target">要查找的節點</param>
        public List<int> Bfs(int start, int target)
        {
            // maintain a queue of paths
            Queue<List<int>> queue = new Queue<List<int>>();
            List<int> path = new List<int>();

            path.Add(start);
            queue.Enqueue(path);
            if (start == target)
            {
                return path;
            }

            while (queue.Count != 0 && queue != default)
            {
                // 每次都把路徑存放進queue 然後一一比對是不是找到target
                // 如果找到就回傳先找到的路徑

                // get the path form queue
                path = queue.Dequeue();

                // get the vertice from path
                var vertice = path.Last();

                // found the target
                if (vertice == target)
                {
                    break;
                }

                // 走過所有鄰居
                foreach (var neighbour in fAdjacenyList[vertice])
                {
                    // e.g 因為1有兩條路徑 所以分別存成新的路徑
                    // 1->2
                    // 1->3
                    // 接著把這兩條路徑放到queue中 以此類推...
                    var newPath = new List<int>(path);
                    newPath.Add(neighbour);
                    queue.Enqueue(newPath);
                }
            }

            return path;
        }

        /// <summary>
        /// bfs演算法但不包含路徑(只找節點)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="target"></param>
        public void BfsWithoutPath(int start, int target)
        {
            Queue<int> q = new Queue<int>();
            List<int> visited = new List<int>();

            // 起點就是要找的答案
            if (start == target)
            {
                Console.WriteLine("Found");
                return;
            }

            q.Enqueue(start);
            while (q.Count != 0 && q != default)
            {
                // 拿出節點
                var vertice = q.Dequeue();
                visited.Add(vertice);

                if (vertice == target)
                {
                    Console.WriteLine("Found!");
                    return;
                }

                // 每個鄰居放進queue
                foreach (var n in fAdjacenyList[vertice])
                {
                    if (!visited.Contains(n))
                    {
                        q.Enqueue(n);
                    }
                }
            }
        }

        #endregion

        #region 深度優先搜尋

        /// <summary>
        /// 深度優先搜尋，以堆疊方式實作(沒有找路徑)
        /// </summary>
        /// <param name="start">指定起點頂點</param>
        /// <param name="target">要尋找的頂點</param>
        public void DfsWithoutPath(int start, int target)
        {
            if (start == target)
            {
                Console.WriteLine($"Found{target}");
                return;
            }

            List<int> visited = new List<int>();
            Stack<int> s = new Stack<int>();
            s.Push(start);

            while (s.Count != 0 && s != default)
            {
                var vertice = s.Pop();
                visited.Add(vertice);

                Console.WriteLine($"拜訪{vertice}");
                if (vertice == target)
                {
                    Console.WriteLine($"Found! {vertice}");
                    return;
                }

                foreach (var neighbour in fAdjacenyList[vertice])
                {
                    if (!visited.Contains(neighbour))
                    {
                        s.Push(neighbour);
                    }
                }
            }
        }

        /// <summary>
        /// 深度優先搜尋，以堆疊方式實作
        /// </summary>
        /// <param name="start">指定起點頂點</param>
        /// <param name="target">要尋找的頂點</param>
        /// <returns>將會return最先找到的路徑</returns>
        public List<int> Dfs(int start, int target)
        {
            List<int> path = new List<int>();
            List<int> visited = new List<int>();
            Stack<List<int>> s = new Stack<List<int>>();
            path.Add(start);
            s.Push(path);
            
            if (start == target)
            {
                return path;
            }

            while (s.Count != 0 && s != default)
            {
                path = s.Pop();
                var vertice = path.Last();
                visited.Add(vertice);

                if (vertice == target)
                {
                    break;
                }

                foreach (var neighbour in fAdjacenyList[vertice])
                {
                    if (!visited.Contains(neighbour))
                    {
                        var newPath = new List<int>(path);
                        newPath.Add(neighbour);
                        s.Push(newPath);
                    }
                }
            }

            return path;
        }
        #endregion
    }
}
