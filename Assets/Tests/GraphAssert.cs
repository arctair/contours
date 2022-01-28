using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GraphAssert
{
    public static void AreEqual(Graph expected, Graph actual)
    {
        CollectionAssert.AreEqual(expected.Vertices, actual.Vertices);
        CollectionAssert.AreEqual(expected.Edges, actual.Edges);
    }
}
