using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Grid2ContourTest
{
    private Grid2Contour grid2Contour = new Grid2Contour();

    [Test]
    public void ContainsNone()
    {
        Graph expected =
            new Graph(new Vector3[0], new int[0]);
        Graph actual = grid2Contour.Contours(0b0000);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void ContainsAll()
    {
        Graph expected =
            new Graph(new Vector3[0], new int[0]);
        Graph actual = grid2Contour.Contours(0b1111);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void DiagonalContainsTopLeft()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(1, 0, 2),
                    new Vector3(0, 0, 1)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(0b1000);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void DiagonalExcludeTopLeft()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(1, 0, 2),
                    new Vector3(0, 0, 1)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(0b0111);
        AssertGraphEquals (expected, actual);
    }
    
    [Test]
    public void DiagonalContainsTopRight()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(1, 0, 2),
                    new Vector3(2, 0, 1)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(0b0100);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void DiagonalExcludesTopRight()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(1, 0, 2),
                    new Vector3(2, 0, 1)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(0b1011);
        AssertGraphEquals (expected, actual);
    }
    
    [Test]
    public void DiagonalContainsBottomLeft()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(0, 0, 1),
                    new Vector3(1, 0, 0)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(0b0010);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void DiagonalExcludesBottomLeft()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(0, 0, 1),
                    new Vector3(1, 0, 0)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(0b1101);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void DiagonalContainsBottomRight()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(2, 0, 1),
                    new Vector3(1, 0, 0)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(0b0001);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void DiagonalExcludesBottomRight()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(2, 0, 1),
                    new Vector3(1, 0, 0)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(0b1110);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void HorizontalContainsBelow()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(0, 0, 1),
                    new Vector3(2, 0, 1)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(0b0011);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void HorizontalContainsAbove()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(0, 0, 1),
                    new Vector3(2, 0, 1)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(0b1100);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void VerticalContainsLeft()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(1, 0, 2),
                    new Vector3(1, 0, 0)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(0b1010);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void VerticalContainsRight()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(1, 0, 2),
                    new Vector3(1, 0, 0)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(0b0101);
        AssertGraphEquals (expected, actual);
    }

    private static void AssertGraphEquals(Graph expected, Graph actual)
    {
        CollectionAssert.AreEqual(expected.Vertices, actual.Vertices);
        CollectionAssert.AreEqual(expected.Edges, actual.Edges);
    }
}
