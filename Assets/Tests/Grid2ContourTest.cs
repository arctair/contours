using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Grid2ContourTest
{
    private Grid2Contour grid2Contour = new Grid2Contour();

    [Test]
    public void SimpleGridMiddleRightToBottomMiddle()
    {
        /*  +wz
         *  [0 0]
         *  [0 1] +x
         *  +sz
         */ 
        int[] grid = new int[]{0, 0, 0, 1};
        Graph expected = new Graph(
            new Vector3[]{
                new Vector3(2, 0, 1),
                new Vector3(1, 0, 0),
            },
            new int[]{0, 1}
        );
        Graph actual = grid2Contour.Contours(grid, 2);
        AssertGraphEquals(expected, actual);
    }

    [Test]
    public void SimpleGridTopStraightLine()
    {
        /*  +wz
         *  [0 0]
         *  [1 1] +x
         *  +sz
         */ 
        int[] grid = new int[]{0, 0, 1, 1};
        Graph expected = new Graph(
            new Vector3[]{
                new Vector3(0, 0, 1),
                new Vector3(2, 0, 1),
            },
            new int[]{0, 1}
        );
        Graph actual = grid2Contour.Contours(grid, 2);
        AssertGraphEquals(expected, actual);
    }

    [Test]
    public void SimpleGridBottomStraightLine()
    {
        /*  +wz
         *  [1 1]
         *  [0 0] +x
         *  +sz
         */ 
        int[] grid = new int[]{1, 1, 0, 0};
        Graph expected = new Graph(
            new Vector3[]{
                new Vector3(0, 0, 1),
                new Vector3(2, 0, 1),
            },
            new int[]{0, 1}
        );
        Graph actual = grid2Contour.Contours(grid, 2);
        AssertGraphEquals(expected, actual);
    }

    [Test]
    public void SimpleGridLeftStraightLine()
    {
        /*  +wz
         *  [1 0]
         *  [1 0] +x
         *  +sz
         */ 
        int[] grid = new int[]{1, 0, 1, 0};
        Graph expected = new Graph(
            new Vector3[]{
                new Vector3(1, 0, 2),
                new Vector3(1, 0, 0),
            },
            new int[]{0, 1}
        );
        Graph actual = grid2Contour.Contours(grid, 2);
        AssertGraphEquals(expected, actual);
    }

    private static void AssertGraphEquals(Graph expected, Graph actual) {
        CollectionAssert.AreEqual(expected.Vertices, actual.Vertices);
        CollectionAssert.AreEqual(expected.Edges, actual.Edges);
    }
}
