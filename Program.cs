using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathAlgorithm
{
    class Program
    {
        static void Main()
        {
            Map newMap = new Map();
            InitaliseMap(ref newMap);
            RouteResult route = newMap.GetShortestPath("a", "e");
            Console.WriteLine("Shortest Path: " + string.Join(" -> ", route.Path.Select(x=>x.Name)).ToUpper());
            Console.WriteLine("Total Distance: " + route.Distance);
            Console.WriteLine("=====================");
            route = newMap.GetShortestPath("e", "b");
            Console.WriteLine("Shortest Path: " + string.Join(" -> ", route.Path.Select(x => x.Name)).ToUpper());
            Console.WriteLine("Total Distance: " + route.Distance);
            Console.WriteLine("=====================");
            route = newMap.GetShortestPath("f", "c");
            Console.WriteLine("Shortest Path: " + string.Join(" -> ", route.Path.Select(x => x.Name)).ToUpper());
            Console.WriteLine("Total Distance: " + route.Distance);
            Console.WriteLine("=====================");
            route = newMap.GetShortestPath("a", "d");
            Console.WriteLine("Shortest Path: " + string.Join(" -> ", route.Path.Select(x => x.Name)).ToUpper());
            Console.WriteLine("Total Distance: " + route.Distance);
            Console.ReadLine();
        }

        private static void InitaliseMap(ref Map newMap)
        {
            Node nodeA = new Node("a");
            Node nodeB = new Node("b");
            Node nodeC = new Node("c");
            Node nodeD = new Node("d");
            Node nodeE = new Node("e");
            Node nodeF = new Node("f");
            newMap.CreateRoute(nodeA, nodeB, 7);
            newMap.CreateRoute(nodeA, nodeC, 9);
            newMap.CreateRoute(nodeA, nodeF, 14);
            newMap.CreateRoute(nodeB, nodeC, 10);
            newMap.CreateRoute(nodeB, nodeD, 15);
            newMap.CreateRoute(nodeC, nodeF, 2);
            newMap.CreateRoute(nodeC, nodeD, 11);
            newMap.CreateRoute(nodeD, nodeE, 6);
            newMap.CreateRoute(nodeE, nodeF, 9);
        }

    }
    

}
