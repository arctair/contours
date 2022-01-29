using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinContours : MonoBehaviour
{

    public int scale;

    public Texture2D texture;

    void Start()
    {
        Color[] colors = texture.GetPixels(0, 0, texture.width, texture.height);
        float[] grid = new float[colors.Length];
        for (int i = 0 ; i < colors.Length; i++) {
            grid[i] = colors[i][0];
        }
        for (float isovalue = 0; isovalue < 1; isovalue += 0.1f) {
            Graph graph = new Grid2Contours(new Quad2Contour()).Contours(grid, texture.width, isovalue);
            for (int i = 0; i < graph.Edges.Length; i += 2) {
                var start = (graph.Vertices[graph.Edges[i]] / texture.width * scale).Multiply(new Vector3(1, 40, 1));
                var end = (graph.Vertices[graph.Edges[i + 1]] / texture.width * scale).Multiply(new Vector3(1, 40, 1));
                Debug.DrawLine(start, end, Color.HSVToRGB(0.25f, 0.5f, 0.5f), 99999f);
            }
        }
    }
}
