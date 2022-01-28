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
        Graph actual = grid2Contour.Contours(-1f, 0f, 0.25f, 0.49f, 0.5f);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void ContainsAll()
    {
        Graph expected = new Graph(new Vector3[0], new int[0]);
        Graph actual = grid2Contour.Contours(0.5f, 1, 1, 1, 0.5f);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void DiagonalContainsTopLeft()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(0.25f, 0, 1f),
                    new Vector3(0, 0, 0.75f)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(20, 0, 0, 0, 15);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void DiagonalExcludeTopLeft()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(0.25f, 0, 1f),
                    new Vector3(0, 0, 0.8f)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(0, 20, 25, 20, 5);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void DiagonalContainsTopRight()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(0.875f, 0, 1f),
                    new Vector3(1f, 0, 0.75f)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(0, 8, 0, 4, 7);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void DiagonalExcludesTopRight()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(0.875f, 0, 1f),
                    new Vector3(1f, 0, 0.75f)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(8, 0, 1, 4, 1);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void DiagonalContainsBottomLeft()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(0, 0, 0.75f),
                    new Vector3(0.25f, 0, 0)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(4, 4, 8, -4, 5);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void DiagonalExcludesBottomLeft()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(0, 0, 0.75f),
                    new Vector3(0.25f, 0, 0)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(4, 999, 0, 12, 3);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void DiagonalContainsBottomRight()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(1f, 0, 0.75f),
                    new Vector3(0.8f, 0, 0)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(4, 4, -7, 8, 5);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void DiagonalExcludesBottomRight()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(1f, 0, 0.75f),
                    new Vector3(0.8f, 0, 0)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(999, 4, 15, 0, 3);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void HorizontalContainsBelow()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(0, 0, 0.25f),
                    new Vector3(1f, 0, 0.75f)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(0, 2, 4, 6, 3);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void HorizontalContainsAbove()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(0, 0, 0.75f),
                    new Vector3(1f, 0, 0.25f)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(4, 6, 0, 2, 3);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void VerticalContainsLeft()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(0.25f, 0, 1f),
                    new Vector3(0.75f, 0, 0)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(4, 0, 6, 2, 3);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void VerticalContainsRight()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(0.75f, 0, 1f),
                    new Vector3(0.25f, 0, 0)
                },
                new int[] { 0, 1 });
        Graph actual = grid2Contour.Contours(0, 4, 2, 6, 3);
        AssertGraphEquals (expected, actual);
    }

    [Test]
    public void SaddleContainsTopLeftAndCenter()
    {
        Graph expected =
            new Graph(new Vector3[] {
                    new Vector3(0.75f, 0, 1f),
                    new Vector3(0, 0, 0.25f),
                    new Vector3(1f, 0, 0.75f),
                    new Vector3(0.25f, 0, 0)
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
                    new Vector3(0.25f, 0, 1f),
                    new Vector3(0, 0, 0.75f),
                    new Vector3(1f, 0, 0.25f),
                    new Vector3(0.75f, 0, 0)
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
                    new Vector3(0.25f, 0, 1f),
                    new Vector3(0, 0, 0.75f),
                    new Vector3(1f, 0, 0.25f),
                    new Vector3(0.75f, 0, 0)
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
                    new Vector3(0.75f, 0, 1f),
                    new Vector3(0, 0, 0.25f),
                    new Vector3(1f, 0, 0.75f),
                    new Vector3(0.25f, 0, 0)
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
