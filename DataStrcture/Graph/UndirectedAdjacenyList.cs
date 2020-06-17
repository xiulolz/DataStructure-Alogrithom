using System;
using System.Collections.Generic;
using System.Linq;
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
            fAdjacrenyList = new Dictionary<int, List<int>>();
        }

        /// <summary>
        /// 無向鄰接串列
        /// </summary>
        private Dictionary<int, List<int>> fAdjacrenyList;

        /// <summary>
        /// 新增相鄰的節點
        /// </summary>
        /// <param name="vertice">節點</param>
        /// <param name="neighbour">相鄰的節點</param>
        public void AddEdge(int vertice, int neighbour)
        {
            // 找不到節點就新增
            if (!fAdjacrenyList.TryGetValue(vertice, out List<int> edge))
            {
                edge = new List<int>();
                edge.Add(neighbour);
                fAdjacrenyList[vertice] = edge;

                return;
            }

            edge.Add(neighbour);
        }

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

            while (queue.Count != 0 || queue != default)
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
                foreach (var neighbour in fAdjacrenyList[vertice])
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
    }
}
