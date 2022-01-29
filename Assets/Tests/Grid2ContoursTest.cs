using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Grid2ContoursTest
{
    [Test]
    public void WindowMovesVertically()
    {
        IQuad2Contour mockQuad2Contour = new MockQuad2Contour();
        Grid2Contours grid2Contours = new Grid2Contours(mockQuad2Contour);
        float[] grid = new float[]{1, 2, 3, 4, 5, 6};
        Graph expected = new Graph(new Vector3[]{
                new Vector3(0.5f, 998, 2),
                new Vector3(0.75f, 998, 1),
                new Vector3(0.75f, 998, 1),
                new Vector3(0, 998, 0.625f),
                new Vector3(1, 998, 0.25f),
                new Vector3(0.375f, 998, 0),
            },
            new int[]{0, 1, 2, 4, 3, 5}
        );
        Graph actual = grid2Contours.Contours(grid, 2, 999);
        GraphAssert.AreEqual(expected, actual);
    }

    [Test]
    public void WindowMovesHorizontally()
    {
        IQuad2Contour mockQuad2Contour = new MockQuad2Contour();
        Grid2Contours grid2Contours = new Grid2Contours(mockQuad2Contour);
        float[] grid = new float[]{7, 8, 9, 10, 11, 12};
        Graph expected = new Graph(new Vector3[]{
                new Vector3(0.75f, 997, 1),
                new Vector3(1, 997, 0.25f),
                new Vector3(0, 997, 0.25f),
                new Vector3(0.75f, 997, 0),
                new Vector3(1, 997, 0.25f),
                new Vector3(2, 997, 0.625f),
            },
            new int[]{0, 1, 2, 3, 4, 5}
        );
        Graph actual = grid2Contours.Contours(grid, 3, 999);
        GraphAssert.AreEqual(expected, actual);
    }

    class MockQuad2Contour : IQuad2Contour
    {
        public Graph Contours(float tl, float tr, float bl, float br, float threshold)
        {
            if (tl == 1 && tr == 2 && bl == 3 && br == 4 && threshold == 999) {
                return new Graph(new Vector3[]{
                        new Vector3(0.5f, 998, 1),
                        new Vector3(0.75f, 998, 0),
                    },
                    new int[]{0, 1}
                );
            } else if (tl == 3 && tr == 4 && bl == 5 && br == 6 && threshold == 999) {
                return new Graph(new Vector3[]{
                        new Vector3(0.75f, 998, 1),
                        new Vector3(0, 998, 0.625f),
                        new Vector3(1, 998, 0.25f),
                        new Vector3(0.375f, 998, 0),
                    },
                    new int[]{0, 2, 1, 3}
                );
            } else if (tl == 7 && tr == 8 && bl == 10 && br == 11 && threshold == 999) {
                return new Graph(new Vector3[]{
                        new Vector3(0.75f, 997, 1),
                        new Vector3(1, 997, 0.25f),
                        new Vector3(0, 997, 0.25f),
                        new Vector3(0.75f, 997, 0),
                    },
                    new int[]{0, 1, 2, 3}
                );
            } else if (tl == 8 && tr == 9 && bl == 11 && br == 12 && threshold == 999) {
                return new Graph(new Vector3[]{
                        new Vector3(0, 997, 0.25f),
                        new Vector3(1, 997, 0.625f),
                    },
                    new int[]{0, 1}
                );
            } else {
                Assert.Fail($"unmatched call with values tl={tl} tr={tr} bl={bl} br={br} threshold={threshold}");
                return new Graph(new Vector3[0], new int[0]);
            }
        }
    }
}
