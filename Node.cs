using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathAlgorithm
{
    public class Node
    {
        public string Name { get; private set; }
        public List<NodeConnection> ConnectedNodes;
        public bool HasVisited = false;
        public Node PreviousNode = null;
        public int RunningTotalDistance = int.MaxValue;
        public Node(string name)
        {
            this.Name = name;
            ConnectedNodes = new List<NodeConnection>();
        }
        public bool RouteAlreadyExists(Node endNode)
        {
            return ConnectedNodes.Exists(x => x.EndNode.Name == endNode.Name);
        }

    }
}
