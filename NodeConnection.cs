using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathAlgorithm
{
    public class NodeConnection
    {
        public Node EndNode;
        public int Distance;
        public NodeConnection(Node endNode, int distance)
        {
            EndNode = endNode;
            Distance = distance;
        }
    }

}
