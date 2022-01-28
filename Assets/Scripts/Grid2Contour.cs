using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid2Contour
{
    public Graph
    Contours(float tl, float tr, float bl, float br, float threshold)
    {
        int scenario = tl > 0 ? 1 : 0;
        scenario = (scenario << 1) + (tr > 0 ? 1 : 0);
        scenario = (scenario << 1) + (bl > 0 ? 1 : 0);
        scenario = (scenario << 1) + (br > 0 ? 1 : 0);
        switch (scenario)
        {
            case 1:
            case 14:
                return new Graph(new Vector3[] {
                        new Vector3(2, 0, 1),
                        new Vector3(1, 0, 0)
                    },
                    new int[] { 0, 1 });
            case 2:
            case 13:
                return new Graph(new Vector3[] {
                        new Vector3(0, 0, 1),
                        new Vector3(1, 0, 0)
                    },
                    new int[] { 0, 1 });
            case 4:
            case 11:
                return new Graph(new Vector3[] {
                        new Vector3(1, 0, 2),
                        new Vector3(2, 0, 1)
                    },
                    new int[] { 0, 1 });
            case 7:
            case 8:
                return new Graph(new Vector3[] {
                        new Vector3(1, 0, 2),
                        new Vector3(0, 0, 1)
                    },
                    new int[] { 0, 1 });
            case 6:
            case 9:
                float average = (tl + tr + bl + br) / 4;
                return new Graph(new Vector3[] {
                        new Vector3(1, 0, 2),
                        new Vector3(0, 0, 1),
                        new Vector3(2, 0, 1),
                        new Vector3(1, 0, 0)
                    },
                    average > threshold ^ scenario == 6
                        ? new int[] { 0, 2, 1, 3 }
                        : new int[] { 0, 1, 2, 3 });
            case 3:
            case 12:
                return new Graph(new Vector3[] {
                        new Vector3(0, 0, 1),
                        new Vector3(2, 0, 1)
                    },
                    new int[] { 0, 1 });
            case 5:
            case 10:
                return new Graph(new Vector3[] {
                        new Vector3(1, 0, 2),
                        new Vector3(1, 0, 0)
                    },
                    new int[] { 0, 1 });
            default:
                return new Graph(new Vector3[0], new int[0]);
        }
    }
}
