using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamQuestion3
{
    class Graph
    {
        private int[,] adjacencyMatrix;
        private Dictionary<int, List<Tuple<int, int>>> adjacencyList;

        public Graph(int vertices)
        {
            adjacencyMatrix = new int[vertices, vertices];
            adjacencyList = new Dictionary<int, List<Tuple<int, int>>>();
            for (int i = 0; i < vertices; i++)
            {
                adjacencyList.Add(i, new List<Tuple<int, int>>());
            }
        }

        public void AddEdge(int source, int destination, int value)
        {
            adjacencyMatrix[source, destination] = value;
            adjacencyMatrix[destination, source] = value; 

            adjacencyList[source].Add(Tuple.Create(destination, value));
            adjacencyList[destination].Add(Tuple.Create(source, value)); 
        }

        public void PrintAdjacencyMatrix()
        {
            int vertices = adjacencyMatrix.GetLength(0);
            Console.WriteLine("Adjacency Matrix:");
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    Console.Write(adjacencyMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void PrintAdjacencyList()
        {
            Console.WriteLine("Adjacency List:");
            foreach (var vertex in adjacencyList.Keys)
            {
                Console.Write($"Vertex {vertex}: ");
                foreach (var edge in adjacencyList[vertex])
                {
                    Console.Write($"({edge.Item1}, {edge.Item2}) ");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Graph graph = new Graph(4);

            int[] pathValues = { 1, 5, 8, 1, 0, 1, 1, 1, 6 };

            for (int i = 0; i < pathValues.Length; i++)
            {
                int source = i / 3;
                int destination = i % 3 + 1; 
                graph.AddEdge(source, destination, pathValues[i]);
            }

            graph.PrintAdjacencyMatrix();
            graph.PrintAdjacencyList();
        }
    }



}
