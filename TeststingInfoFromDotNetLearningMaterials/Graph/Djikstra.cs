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

            // set source value to 0;
            pathToVerteces[vertex] = 0;

            // loop over all edges
            for (int i = 0; i < pathToVerteces.Count; i++)
            {

                // order the paths in order to get the next shortest path. this also assures that the next vertex was visited
                pathToVerteces = pathToVerteces.OrderBy(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                // take the next vertex with its path shortest path as kvp
                var v = pathToVerteces.ElementAt(i);

                // if the next vertex was not visited do not loop over it. in case a vertex cannot be reached the algorithm
                // will not process it
                if (pathToVerteces[v.Key] != int.MaxValue)
                {
                    // set the vertex with the shortest path as current
                    Vertex currentVertex = v.Key;

                    // take all edges of the current vertex
                    Queue<Edge> allEdges = new Queue<Edge>(currentVertex.Edges);


                    // loop over all vertexes
                    while (allEdges.Count > 0)
                    {
                        // get the current edge
                        Edge currentEdge = allEdges.Dequeue();


                        // check if the path to the next vertex is the shortest path to it
                        if ((currentEdge.Weight + pathToVerteces[currentVertex]) < pathToVerteces[currentEdge.VertexTo])
                        {
                            // if the path is the shortest override it
                            pathToVerteces[currentEdge.VertexTo] = currentEdge.Weight + pathToVerteces[currentVertex];
                        }
                    }
                }
            }

            // return all verteces with their shortest path
            return pathToVerteces;
        }
    }
}

//Vertex currentVertex = vertex;

//Queue<Edge> allEdges = new Queue<Edge>(currentVertex.Edges);

//            while (allEdges.Count > 0)
//            {
//                Edge nextVertexEdge = allEdges.Peek();

//                for (int i = 0; i<currentVertex.Edges.Count; i++)
//                {
//                    Edge currentEdge = allEdges.Dequeue();

//                    if ((currentEdge.Weight + pathToVerteces[currentVertex]) < pathToVerteces[currentEdge.VertexTo])
//                    {
//                        pathToVerteces[currentEdge.VertexTo] = currentEdge.Weight + pathToVerteces[currentVertex];
//                    }

//                    if (currentEdge.Weight<nextVertexEdge.Weight)
//                    {
//                        nextVertexEdge = currentEdge;
//                    }
//                }

//                currentVertex = verteces.Find(v => v == nextVertexEdge.VertexTo);

//                foreach (var edge in currentVertex.Edges)
//                {
//                    allEdges.Enqueue(edge);
//                }
//            }

// ===========================================================================

//     foreach (var v in pathToVerteces.OrderBy(v => v.Value))
//            {
//                if (pathToVerteces[v.Key] != int.MaxValue)
//                {
//                    Vertex currentVertex = v.Key;

//Queue<Edge> allEdges = new Queue<Edge>(currentVertex.Edges);

//                    while (allEdges.Count > 0)
//                    {
//                        Edge currentEdge = allEdges.Dequeue();

//                        if ((currentEdge.Weight + pathToVerteces[currentVertex]) < pathToVerteces[currentEdge.VertexTo])
//                        {
//                            pathToVerteces[currentEdge.VertexTo] = currentEdge.Weight + pathToVerteces[currentVertex];
//                        }
//                    }
//                }
//            }