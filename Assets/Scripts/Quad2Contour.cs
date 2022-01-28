using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad2Contour
{
    private static int[] EDGE_01 = new int[] { 0, 1 };

    private static int[] EDGES_0123 = new int[] { 0, 1, 2, 3 };

    private static int[] EDGES_0213 = new int[] { 0, 2, 1, 3 };

    public Graph
    Contours(float tl, float tr, float bl, float br, float threshold)
    {
        int scenario = tl >= threshold ? 1 : 0;
        scenario = (scenario << 1) + (tr >= threshold ? 1 : 0);
        scenario = (scenario << 1) + (bl >= threshold ? 1 : 0);
        scenario = (scenario << 1) + (br >= threshold ? 1 : 0);
        switch (scenario)
        {
            case 1:
            case 14:
                return new Graph(new Vector3[] {
                        new Vector3(1f, threshold, lerp(threshold , br, tr)),
                        new Vector3(lerp(threshold , bl, br), threshold, 0)
                    },
                    EDGE_01);
            case 2:
            case 13:
                return new Graph(new Vector3[] {
                        new Vector3(0, threshold, lerp(threshold , bl, tl)),
                        new Vector3(lerp(threshold , bl, br), threshold, 0)
                    },
                    EDGE_01);
            case 3:
            case 12:
                return new Graph(new Vector3[] {
                        new Vector3(0, threshold, lerp(threshold , bl, tl)),
                        new Vector3(1f, threshold, lerp(threshold , br, tr))
                    },
                    EDGE_01);
            case 4:
            case 11:
                return new Graph(new Vector3[] {
                        new Vector3(lerp(threshold , tl, tr), threshold, 1f),
                        new Vector3(1f, threshold, lerp(threshold , br, tr))
                    },
                    EDGE_01);
            case 5:
            case 10:
                return new Graph(new Vector3[] {
                        new Vector3(lerp(threshold , tl, tr), threshold, 1f),
                        new Vector3(lerp(threshold , bl, br), threshold, 0)
                    },
                    EDGE_01);
            case 6:
            case 9:
                float average = (tl + tr + bl + br) / 4;
                return new Graph(new Vector3[] {
                        new Vector3(lerp(threshold , tl, tr), threshold, 1f),
                        new Vector3(0, threshold, lerp(threshold , bl, tl)),
                        new Vector3(1f, threshold, lerp(threshold , br, tr)),
                        new Vector3(lerp(threshold , bl, br), threshold, 0)
                    },
                    average > threshold ^ scenario == 6
                        ? EDGES_0213
                        : EDGES_0123);
            case 7:
            case 8:
                return new Graph(new Vector3[] {
                        new Vector3(lerp(threshold , tl, tr), threshold, 1f),
                        new Vector3(0, threshold, lerp(threshold , bl, tl))
                    },
                    EDGE_01);
            default:
                return new Graph(new Vector3[0], new int[0]);
        }
    }

    private static float lerp(float value, float start, float end) {
        return (value - start) / (end - start);
    }
}
