using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    void Start()
    {
        UnityEngine.Mesh mesh = new UnityEngine.Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices =
            new Vector3[] {
                new Vector3(0, 0, 0),
                new Vector3(2, 0, 0),
                new Vector3(1, 0, Mathf.Sqrt(3)),
                new Vector3(1,
                    2 * Mathf.Sqrt(2) / Mathf.Sqrt(3),
                    1 / Mathf.Sqrt(3))
            };
        mesh.triangles = new int[] { 0, 1, 2, 1, 0, 3, 0, 2, 3, 2, 1, 3 };
    }
}
