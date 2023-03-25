namespace ReorderRoutesMakeAllPathsLeadCityZero
{
    internal class Program
    {
        public class ReorderRoutesMakeAllPathsLeadCityZero
        {
            int minReorder = 0;

            private class NodeInfo
            {
                public readonly int node;
                public readonly int forward;

                public NodeInfo(int node, int forward)
                {
                    this.node = node;
                    this.forward = forward;
                }
            }

            private void BFS(Dictionary<int, List<NodeInfo>> graph, int n, int node)
            {
                Queue<int> queue = new();
                bool[] visited = new bool[n];
                queue.Enqueue(node);
                visited[node] = true;
                while(queue.Count > 0)
                {
                    int parent = queue.Dequeue();
                    if (!graph.ContainsKey(parent))
                    {
                        continue;
                    }
                    foreach(NodeInfo child in graph[parent])
                    {
                        if (!visited[child.node])
                        {
                            minReorder += child.forward;
                            visited[child.node] = true;
                            queue.Enqueue(child.node);
                        }
                    }
                }
            }

            private void DFS(Dictionary<int, List<NodeInfo>> graph, int node, int parent)
            {
                if (!graph.ContainsKey(node))
                {
                    return;
                }
                foreach (NodeInfo vertex in graph[node])
                {
                    if (vertex.node != parent)
                    {
                        minReorder += vertex.forward;
                        DFS(graph, vertex.node, node);
                    }
                }
            }

            public int MinReorder(int n, int[][] connections)
            {

                Dictionary<int, List<NodeInfo>> graph = new();
                foreach (int[] connection in connections)
                {
                    if (!graph.ContainsKey(connection[0]))
                    {
                        graph[connection[0]] = new List<NodeInfo>();
                    }
                    graph[connection[0]].Add(new NodeInfo(connection[1], 1));
                    if (!graph.ContainsKey(connection[1]))
                    {
                        graph[connection[1]] = new List<NodeInfo>();
                    }
                    graph[connection[1]].Add(new NodeInfo(connection[0], 0));
                }
                //DFS(graph, 0, -1);
                BFS(graph, n, 0);
                return minReorder;
            }
        }

        static void Main(string[] args)
        {
            ReorderRoutesMakeAllPathsLeadCityZero reorderRoutesMakeAllPathsLeadCityZero1 = new();
            Console.WriteLine(reorderRoutesMakeAllPathsLeadCityZero1.MinReorder(6, new int[][] 
            { 
                new int[] { 0, 1 },
                new int[] { 1, 3 },
                new int[] { 2, 3 },
                new int[] { 4, 0 },
                new int[] { 4, 5 }
            }));
            ReorderRoutesMakeAllPathsLeadCityZero reorderRoutesMakeAllPathsLeadCityZero2 = new();
            Console.WriteLine(reorderRoutesMakeAllPathsLeadCityZero2.MinReorder(5, new int[][]
            {
                new int[] { 1, 0 },
                new int[] { 1, 2 },
                new int[] { 3, 2 },
                new int[] { 3, 4 }
            }));
            ReorderRoutesMakeAllPathsLeadCityZero reorderRoutesMakeAllPathsLeadCityZero3 = new();
            Console.WriteLine(reorderRoutesMakeAllPathsLeadCityZero3.MinReorder(3, new int[][]
            {
                new int[] { 1, 0 },
                new int[] { 2, 0 }
            }));
        }
    }
}