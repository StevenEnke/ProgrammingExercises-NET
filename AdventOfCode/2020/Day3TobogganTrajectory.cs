using System.Collections.Generic;
using System.IO;

namespace AdventOfCode
{
    public static class Day3TobogganTrajectory 
    {
        private const char TreeSquare = '#';
        private static readonly IEnumerable<(int rightStepping, int downStepping)> pathDirections = new List<(int, int)>
        {
            (1, 1),
            (3, 1),
            (5, 1),
            (7, 1),
            (1, 2)
        };

        public static int TravelerTreeCounter(string filePath)
        {
            var treeCount = 0;

            if (File.Exists(filePath))
            {
                var right = 0;
                foreach (var locations in File.ReadLines(filePath))
                {
                    var currentLocation = locations[right % locations.Length];
                    if (currentLocation.Equals(TreeSquare))
                    {
                        treeCount++;
                    }

                    right += 3;
                }
            }

            return treeCount;
        }
        public static long TravelerTreeMultiplier(string filePath)
        {
            var treeMultiple = 1L;

            if (File.Exists(filePath))
            {
                foreach (var pathDirection in pathDirections)
                {
                    var treeCount = 0;
                    var currentRight = 0;
                    var currentDown = 0;
                    foreach (var locations in File.ReadLines(filePath))
                    {
                        if(currentDown % pathDirection.downStepping == 0)
                        {
                            var currentLocation = locations[currentRight % locations.Length];
                            if (currentLocation.Equals(TreeSquare))
                            {
                                treeCount++;
                            }

                            currentRight += pathDirection.rightStepping;
                        }

                        currentDown += 1;
                    }

                    treeMultiple *= treeCount;
                }
            }

            return treeMultiple;
        }
    }
}