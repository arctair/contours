using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid2Contours
{
    private IQuad2Contour quad2Contour;

    public Grid2Contours(IQuad2Contour quad2Contour)
    {
        this.quad2Contour = quad2Contour;
    }

    public Graph Contours(float[] grid, int width, float threshold)
    {
        List<Vector3> vertices = new List<Vector3>();
        List<int> edges = new List<int>();
        int height = grid.Length / width;
        for (int y = 0; y < height - 1; y++)
        {
            for (int x = 0; x < width - 1; x++)
            {
                int vertexOffset = vertices.Count;
                int edgeOffset = edges.Count;
                Graph graph =
                    quad2Contour
                        .Contours(grid[width * y + x],
                        grid[width * y + x + 1],
                        grid[width * (y + 1) + x],
                        grid[width * (y + 1) + x + 1],
                        threshold);
                vertices.AddRange(graph.Vertices);
                for (int i = 0; i < graph.Vertices.Length; i++)
                {
                    vertices[vertexOffset + i] +=
                        new Vector3(x, 0, height - y - 2);
                }
                edges.AddRange(graph.Edges);
                for (int i = 0; i < graph.Edges.Length; i++)
                {
                    edges[edgeOffset + i] += vertexOffset;
                }
            }
        }
        return new Graph(vertices.ToArray(), edges.ToArray());
    }
}
