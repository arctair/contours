using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extensions 
{
    public static Vector3 Multiply(this Vector3 v1, Vector3 v2) {
        return new Vector3(v1[0]*v2[0],v1[1]*v2[1],v1[2]*v2[2]);
    }
}
