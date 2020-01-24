using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathAlgorithm
{
    public class RouteResult
    {
        public int Distance { get; private set; }
        public List<Node> Path { get; private set; }
        public RouteResult(List<Node> path, int distance)
        {
            Path = path;
            Distance = distance;
        }
    }
}
