using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathAlgorithm
{
    
    public class Map
    {
        private List<Node> NodeMap;
        public Map()
        {
            NodeMap = new List<Node>();
        }

        /// <summary>
        /// Creates a relationship between two nodes
        /// </summary>
        /// <param name="startNode"></param>
        /// <param name="endNode"></param>
        /// <param name="distance"></param>
        public void CreateRoute(Node startNode, Node endNode, int distance)
        {
            if (!NodeMap.Exists(x=>x.Name == startNode.Name))
            {
                NodeMap.Add(startNode);
            }
            if (!NodeMap.Exists(x => x.Name == endNode.Name))
            {
                NodeMap.Add(endNode);
            }
            if (!startNode.RouteAlreadyExists(endNode))
            {
                NodeMap.First(x => x.Name == startNode.Name).ConnectedNodes.Add(new NodeConnection(endNode, distance));
            }
            if (!endNode.RouteAlreadyExists(startNode))
            {
                NodeMap.First(x => x.Name == endNode.Name).ConnectedNodes.Add(new NodeConnection(startNode, distance));
            }
        }
        /// <summary>
        /// Add a node without a relationship
        /// </summary>
        /// <param name="newNode"></param>
        public void AddNode(Node newNode)
        {
            if (!NodeMap.Exists(x=>x.Name == newNode.Name))
            {
                NodeMap.Add(newNode);
            }
        }
        /// <summary>
        /// Get shortest path between two nodes
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="endPos"></param>
        /// <returns></returns>
        public RouteResult GetShortestPath(string startPos, string endPos)
        {
            Node currentNode = NodeMap.Where(x => x.Name == startPos).First();
            Node endNode = NodeMap.Where(x => x.Name == endPos).First();
            currentNode.RunningTotalDistance = 0;
            CalculatePath(currentNode);
            return OutputPath(endNode);
        }

        private void CalculatePath(Node currentNode)
        {
           
            currentNode.HasVisited = true;
            Node nextNode;
            foreach (NodeConnection connection in currentNode.ConnectedNodes)
            {
                nextNode = connection.EndNode;
                if (nextNode.PreviousNode == null && !nextNode.HasVisited)
                {
                    nextNode.PreviousNode = currentNode;
                    nextNode.RunningTotalDistance = currentNode.RunningTotalDistance + connection.Distance;
                }
                else
                {
                    if ((currentNode.RunningTotalDistance + connection.Distance < nextNode.RunningTotalDistance) && nextNode != currentNode.PreviousNode)
                    {
                        nextNode.PreviousNode = currentNode;
                        nextNode.RunningTotalDistance = currentNode.RunningTotalDistance + connection.Distance;
                    }
                }
            }
            foreach (Node node in currentNode.ConnectedNodes.Select(x => x.EndNode))
            {
                if (!node.HasVisited)
                {
                    CalculatePath(node);
                }
            }

        }
        private RouteResult OutputPath(Node endNode)
        {
            List<Node> nodeTree = new List<Node>();
            Node currentNode = endNode;
            while (currentNode != null)
            {
                nodeTree.Add(currentNode);
                currentNode = currentNode.PreviousNode;
            }
            nodeTree.Reverse();
            RouteResult newRoute = new RouteResult(nodeTree, nodeTree.Last().RunningTotalDistance);
            ResetRoutes();
            return newRoute;
        }
        /// <summary>
        /// Clears totalRunningDistance
        /// </summary>
        private void ResetRoutes()
        {
            foreach (Node node in NodeMap)
            {
                node.RunningTotalDistance = int.MaxValue;
                node.HasVisited = false;
                node.PreviousNode = null;
            }
        }
    }
}
