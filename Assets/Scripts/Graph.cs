using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph 
{
    public List<Vector3> Vertices;
    public List<int> Edges;
    public Graph(List<Vector3> vertices, List<int> edges){
        this.Vertices = vertices;
        this.Edges = edges;
    }
}
