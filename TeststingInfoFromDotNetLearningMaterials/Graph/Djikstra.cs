namespace Graph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Djikstra
    {
        public Dictionary<Vertex, int> FindPaths(Vertex vertex, List<Vertex> verteces)
        {
            Dictionary<Vertex, int> pathToVerteces = new Dictionary<Vertex, int>();

            foreach (var v in verteces)
            {
                pathToVerteces[v] = int.MaxValue;
            }

            pathToVerteces[vertex] = 0;

            Vertex currentVertex = vertex;

            Queue<Edge> allEdges = new Queue<Edge>(currentVertex.Edges);

            while (allEdges.Count > 0)
            {
                Edge nextVertexEdge = allEdges.Peek();

                for (int i = 0; i < currentVertex.Edges.Count; i++)
                {
                    Edge currentEdge = allEdges.Dequeue();

                    if ((currentEdge.Weight + pathToVerteces[currentVertex]) < pathToVerteces[currentEdge.VertexTo])
                    {
                        pathToVerteces[currentEdge.VertexTo] = currentEdge.Weight + pathToVerteces[currentVertex];
                    }

                    if (currentEdge.Weight < nextVertexEdge.Weight)
                    {
                        nextVertexEdge = currentEdge;
                    }
                }

                currentVertex = verteces.Find(v => v == nextVertexEdge.VertexTo);

                foreach (var edge in currentVertex.Edges)
                {
                    allEdges.Enqueue(edge);
                }
            }

            return pathToVerteces;
        }
    }
}