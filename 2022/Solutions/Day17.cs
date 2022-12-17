using System.Collections.Generic;
using System.Linq;

namespace Advent_2022.Solutions
{
    public static class Day17
    {
        private static HashSet<(int, int)> placedRocks;
        private static string gusts;

        private static int windIndex = -1;


        private static readonly List<ShapeClass> shapes = new List<ShapeClass>(new[]
        {
            new ShapeClass(new[] {(-1, 0), (0, 0), (1, 0), (2, 0)}),
            new ShapeClass(new[] {(0, 0), (0, 1), (1, 1), (-1, 1), (0, 2)}),
            new ShapeClass(new[] {(-1, 0), (0, 0), (1, 0), (1, 1), (1, 2)}),
            new ShapeClass(new[] {(-1, 0), (-1, 1), (-1, 2), (-1, 3)}),
            new ShapeClass(new[] {(-1, 0), (0, 0), (-1, 1), (0, 1)})
        });

        public static int SolvePartOne(string input, int cycles)
        {
            gusts = input;
            int highestPoint = 0;
            placedRocks = new HashSet<(int, int)>();
            for (int currentCycle = 0; currentCycle < cycles; currentCycle++)
            {
                (int, int) spawnPoint = (3, highestPoint + 3);
                bool hasSettled = false;
                ShapeClass currentShape = GetShapeForCycle(currentCycle);
                (int, int) checkPoint = spawnPoint;
                while (!hasSettled)
                {
                    (int, int) temp = (checkPoint.Item1 + GetWindGust(), checkPoint.Item2);

                    if (currentShape.CanShapeGoToPosition(temp)) //Check if can move in direction
                        checkPoint = temp; //Move in the direction

                    temp = (checkPoint.Item1, checkPoint.Item2 - 1);

                    if (currentShape.CanShapeGoToPosition(temp))
                    {
                        checkPoint = temp;
                    }
                    else
                    {
                        currentShape.PlaceShape(checkPoint);
                        hasSettled = true;
                        int highestPointJustPlaced = checkPoint.Item2 + currentShape.GetHighestPoint();
                        if (highestPointJustPlaced > highestPoint)
                            highestPoint = highestPointJustPlaced;
                    }
                }
            }


            return highestPoint;
        }

        private static int GetWindGust()
        {
            windIndex++;
            return gusts[windIndex % gusts.Length] == '<' ? -1 : 1;
        }


        private static bool CanExistAtPosition((int, int) positionToCheck)
        {
            if (positionToCheck.Item2 < 0)
                return false;
            if (positionToCheck.Item1 < 0 || positionToCheck.Item1 > 6)
                return false;
            return !placedRocks.Contains(positionToCheck);
        }

        private static ShapeClass GetShapeForCycle(int cycle)
        {
            return shapes[cycle % 5];
        }

        private class ShapeClass
        {
            private readonly (int, int)[] shapePoints;

            public ShapeClass((int, int)[] points)
            {
                shapePoints = points;
            }


            public bool CanShapeGoToPosition((int, int) centerPosition)
            {
                foreach ((int, int) point in shapePoints)
                {
                    (int, int) testPoint = (centerPosition.Item1 + point.Item1, centerPosition.Item2 + point.Item2);

                    if (!CanExistAtPosition(testPoint))
                        return false;
                }

                return true;
            }

            public int GetHighestPoint()
            {
                return shapePoints.Select(testPoint => testPoint.Item2).Prepend(0).Max() + 1;
            }

            public void PlaceShape((int, int) centerPosition)
            {
                foreach ((int, int) point in shapePoints)
                {
                    (int, int) placedPoint = (centerPosition.Item1 + point.Item1, centerPosition.Item2 + point.Item2);

                    placedRocks.Add(placedPoint);
                }
            }
        }
    }
}