using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamProblem4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ColoredGraph
    {
        public Dictionary<string, List<Tuple<string, int>>> AdjacencyList { get; }
        public Dictionary<string, string> NodeColors { get; }

        public ColoredGraph()
        {
            AdjacencyList = new Dictionary<string, List<Tuple<string, int>>>();
            NodeColors = new Dictionary<string, string>();
        }

        public void AddNode(string node, string color)
        {
            AdjacencyList.Add(node, new List<Tuple<string, int>>());
            NodeColors.Add(node, color);
        }

        public void AddEdge(string source, string destination, int weight)
        {
            AdjacencyList[source].Add(Tuple.Create(destination, weight));
            AdjacencyList[destination].Add(Tuple.Create(source, weight)); 
        }

        public List<string> DijkstraShortestPath(string startNode, string endNode)
        {
            Dictionary<string, int> distances = new Dictionary<string, int>();
            Dictionary<string, string> previousNodes = new Dictionary<string, string>();
            HashSet<string> visited = new HashSet<string>();

            // Initialize distances
            foreach (var node in AdjacencyList.Keys)
            {
                distances[node] = int.MaxValue;
                previousNodes[node] = null;
            }
            distances[startNode] = 0;

            
            while (visited.Count < AdjacencyList.Count)
            {
                string currentNode = GetMinimumDistanceNode(distances, visited);
                visited.Add(currentNode);

                foreach (var neighbor in AdjacencyList[currentNode])
                {
                    string nextNode = neighbor.Item1;
                    int weight = neighbor.Item2;

                    int newDistance = distances[currentNode] + weight;
                    if (newDistance < distances[nextNode])
                    {
                        distances[nextNode] = newDistance;
                        previousNodes[nextNode] = currentNode;
                    }
                }
            }

         
            List<string> shortestPath = new List<string>();
            string current = endNode;
            while (current != null)
            {
                shortestPath.Add(current);
                current = previousNodes[current];
            }
            shortestPath.Reverse();

            return shortestPath;
        }

        private string GetMinimumDistanceNode(Dictionary<string, int> distances, HashSet<string> visited)
        {
            return distances.Where(pair => !visited.Contains(pair.Key))
                            .OrderBy(pair => pair.Value)
                            .FirstOrDefault().Key;
        }
    }

    class Program
    {
        static void Main()
        {
            ColoredGraph coloredGraph = new ColoredGraph();

            
            coloredGraph.AddNode("red", "red");
            coloredGraph.AddNode("darkblue", "darkblue");
            coloredGraph.AddNode("yellow", "yellow");
            coloredGraph.AddNode("green", "green");

           
            coloredGraph.AddEdge("red", "darkblue", 3);
            coloredGraph.AddEdge("darkblue", "yellow", 2);
            coloredGraph.AddEdge("yellow", "green", 1);

           
            List<string> shortestPath = coloredGraph.DijkstraShortestPath("red", "green");

            
            Console.WriteLine("Shortest Path from Red to Green:");
            Console.WriteLine(string.Join(" -> ", shortestPath.Select(node => $"{node} ({coloredGraph.NodeColors[node]})")));
        }
    }


}
