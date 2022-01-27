using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid2Contour 
{
    public Graph Contours(int[] grid, int width){
        int scenario = 0;
        foreach (int cell in grid) {
            scenario = scenario << 1;
            if (cell != 0) {
                scenario += 1;
            }
        }
        if (scenario == 1) {
            Vector3[] vertices = new Vector3[]{
                new Vector3(2, 0, 1),
                new Vector3(1, 0, 0),
            };
            int[] edges = new int[]{0, 1};
            return new Graph(vertices, edges);
        }
        else if (scenario == 10) {
            Vector3[] vertices = new Vector3[]{
                new Vector3(1, 0, 2),
                new Vector3(1, 0, 0),
            };
            int[] edges = new int[]{0, 1};
            return new Graph(vertices, edges);
        } else { 
            Vector3[] vertices = new Vector3[]{
                new Vector3(0, 0, 1),
                new Vector3(2, 0, 1),
            };
            int[] edges = new int[]{0, 1};
            return new Graph(vertices, edges);
        }
    }
}
