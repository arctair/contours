using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid2Contour 
{
    public Graph Contours(int[] grid, int width){
        List<Vector3> vertices = new List<Vector3>();
        List<int> edges = new List<int>();
        return new Graph(vertices, edges);
    }
}
