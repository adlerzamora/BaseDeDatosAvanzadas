using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace practica2._1 {
    class Program {

        private int V; // No. of Vertices
        private List<Int32>[] adj; // Adjacency Lists

        Program (int v) {
            V = v;
            adj = new List<Int32>[v];
            for (int i = 0; i < V; i++) {
                adj[i] = new List<int> ();
            }
        }

        void addEdge (int v, int w) {
            adj[v].Add (w);
        }

        
        List<Int32> BFS (int s) {
            // Keep track of BFS Path
            List<Int32> pathTrack = new List<int> ();

            // Mark all the vertices as not visited( By default set as false)
            Boolean[] visited = new Boolean[V];

            // Create a queue for BFS
            List<Int32> queue = new List<int> ();

            // Mark the current node as visited and enqueue it
            visited[s] = true;
            queue.Add (s);

            while (queue.Count != 0) {
                // Dequeue a vertex from queue and print it
                s = queue[0];
                queue.RemoveAt (0);
                Console.WriteLine(s);
                pathTrack.Add (s);

                // Get all adjacent vertices of the dequeued vertex s
                // If a adjacent has not been visited, then mark it
                // visited and enqueue it

                foreach (int index in adj[s]) {
                    int n = index;
                    if (!visited[index]) {
                        visited[n] = true;
                        queue.Add (n);
                    }
                }
            }
            return pathTrack;
        }

        void DFSUtil(int v, bool[] visited){
            Console.WriteLine("Entra a DFSUtil");
            // Mark the current node as visited and print it
            visited[v] = true;
            Console.WriteLine(v + " ");

            // Recur for all the vertices adjacent to this vertex
            foreach(int node in adj[v]){
                Console.WriteLine("Entra a foreach con nodo " + node);
                int n = node;
                if(!visited[n]){
                    DFSUtil(n, visited);
                }
            }
        }

        // The function to do DFS traversal. It uses recursive DFSUtil()
        void DFS(int v){
            Console.WriteLine("Entra a DFS");
            // Mark all the vertices as not visited (set false as default)
            Boolean[] visited = new Boolean[v];

            // Call the recursive helper function to printDFS trasveral
            DFSUtil(v, visited);
        }

        static void Main (string[] args) {
            /*
            var Parser = new GDFParser.GDFParser ();

            Parser.LoadFile (@"F:\Documentos\Itesm\BasedeDatosAvanzada\Parcial2\Practicas\Grafos\unreal1.gdf");
            Parser.Parse ();

            var miGrafo = Parser.GetGraph ();
            var nodos = miGrafo.Vertices;
            var aristas = miGrafo.Edges;

            List<Int32> path;
            List<string> name = new List<string> ();
            List<string> nodosRelacion = new List<string> ();
            

            foreach (var node in nodos) {
                nodosRelacion.Add (node.Name);
                name.Add (node.Username);
                Console.WriteLine (node.Username + " || " + node.Name);
            }

            Program g = new Program (nodosRelacion.Count);

            foreach (var edge in aristas) {
                g.addEdge (nodosRelacion.IndexOf (edge.Source.Name), nodosRelacion.IndexOf (edge.Target.Name));
            }*/

            Console.WriteLine ("Following is Breadth First Traversal " +
                "(starting from vertex 0)");

            Program g = new Program (4);

            g.addEdge (0, 1);
            g.addEdge (0, 2);
            g.addEdge (1, 2);
            g.addEdge (2, 0);
            g.addEdge (2, 3);
            g.addEdge (3, 3);

            g.BFS (2);
            /*foreach (var nodo in path) {
                //Console.WriteLine(nodosRelacion[nodo]);
                Console.WriteLine (nodo);
            }*/
        }
    }
}