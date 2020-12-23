using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts._0_bfs
{
    class Dijkstra
    {

        public static void FindPath<NodeType>(
            IGraph<NodeType> graph,
            NodeType startNode, NodeType endNode,
            List<NodeType> outputPath, int maxiterations = 1000)
        {
            
        }

        public static List<NodeType> GetPath<NodeType>(IGraph<NodeType> graph, NodeType startNode, NodeType endNode, int maxiterations = 1000)
        {
            List<NodeType> path = new List<NodeType>();
            FindPath(graph, startNode, endNode, path, maxiterations);
            return path;
        }
    }
}
