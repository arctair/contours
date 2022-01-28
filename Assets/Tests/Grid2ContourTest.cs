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
        Graph expected = new Graph(new Vector3[0], new int[0]);
        Graph actual = grid2Contour.Contours(0, 0, 0, 0, 0.5f);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void ContainsAll()
    {
        Graph expected = new Graph(new Vector3[0], new int[0]);
        Graph actual = grid2Contour.Contours(1, 1, 1, 1, 0.5f);
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
        Graph actual = grid2Contour.Contours(1, 0, 0, 0, 0.5f);
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
        Graph actual = grid2Contour.Contours(0, 1, 1, 1, 0.5f);
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
        Graph actual = grid2Contour.Contours(0, 1, 0, 0, 0.5f);
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
        Graph actual = grid2Contour.Contours(1, 0, 1, 1, 0.5f);
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
        Graph actual = grid2Contour.Contours(0, 0, 1, 0, 0.5f);
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
        Graph actual = grid2Contour.Contours(1, 1, 0, 1, 0.5f);
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
        Graph actual = grid2Contour.Contours(0, 0, 0, 1, 0.5f);
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
        Graph actual = grid2Contour.Contours(1, 1, 1, 0, 0.5f);
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
        Graph actual = grid2Contour.Contours(0, 0, 1, 1, 0.5f);
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
        Graph actual = grid2Contour.Contours(1, 1, 0, 0, 0.5f);
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
        Graph actual = grid2Contour.Contours(1, 0, 1, 0, 0.5f);
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
        Graph actual = grid2Contour.Contours(0, 1, 0, 1, 0.5f);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void SaddleContainsTopLeftAndCenter()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(1, 0, 2),
                    new Vector3(0, 0, 1),
                    new Vector3(2, 0, 1),
                    new Vector3(1, 0, 0)
                },
                new int[] { 0, 2, 1, 3 });
        Graph actual = grid2Contour.Contours(1, 0, 0, 1, 0.25f);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void SaddleContainsTopLeftAndExcludesCenter()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(1, 0, 2),
                    new Vector3(0, 0, 1),
                    new Vector3(2, 0, 1),
                    new Vector3(1, 0, 0)
                },
                new int[] { 0, 1, 2, 3 });
        Graph actual = grid2Contour.Contours(1, 0, 0, 1, 0.75f);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void SaddleContainsTopRightAndCenter()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(1, 0, 2),
                    new Vector3(0, 0, 1),
                    new Vector3(2, 0, 1),
                    new Vector3(1, 0, 0)
                },
                new int[] { 0, 1, 2, 3 });
        Graph actual = grid2Contour.Contours(0, 1, 1, 0, 0.25f);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void SaddleContainsTopRightAndExcludesCenter()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(1, 0, 2),
                    new Vector3(0, 0, 1),
                    new Vector3(2, 0, 1),
                    new Vector3(1, 0, 0)
                },
                new int[] { 0, 2, 1, 3 });
        Graph actual = grid2Contour.Contours(0, 1, 1, 0, 0.75f);
        AssertGraphEquals (expected, actual);
    }

    private static void AssertGraphEquals(Graph expected, Graph actual)
    {
        CollectionAssert.AreEqual(expected.Vertices, actual.Vertices);
        CollectionAssert.AreEqual(expected.Edges, actual.Edges);
    }
}
