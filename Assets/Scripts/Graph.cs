using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph 
{
    public Vector3[] Vertices;
    public int[] Edges;
    public Graph(Vector3[] vertices, int[] edges){
        this.Vertices = vertices;
        this.Edges = edges;
    }
}
