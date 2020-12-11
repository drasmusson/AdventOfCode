using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AOC2020.Eleventh
{
    public static class Logic
    {
        public static int Run()
        {
            var input = InputParser.InputList;
            //var result1 = First(input);
            var result2 = Second(input);
            return result2;
        }

        private static int First(List<string> input)
        {
            
            var ferry = new Ferry(input);

            bool differentFromLast;
            var sw = new Stopwatch();
            do
            {
                sw.Start();
                
                var newFerry = NewFerryWithSwitchedPlaces(ferry);

                differentFromLast = !ferry.AreEqual(newFerry);
                ferry = newFerry;

                sw.Stop();
                Debug.WriteLine(sw.Elapsed);
                sw.Reset();
            } while (differentFromLast);

            return ferry.OccupiedTiles;
        }

        private static int Second(List<string> input)
        {

            var ferry = new Ferry(input);

            bool differentFromLast;
            var sw = new Stopwatch();
            do
            {
                sw.Start();

                var newFerry = NewFerryWithSwitchedPlaces2(ferry);

                differentFromLast = !ferry.AreEqual(newFerry);
                ferry = newFerry;

                sw.Stop();
                Debug.WriteLine(sw.Elapsed);
                Debug.WriteLine(ferry.OccupiedTiles);
                sw.Reset();
            } while (differentFromLast);

            return ferry.OccupiedTiles;
        }

        public static Ferry NewFerryWithSwitchedPlaces(Ferry oldFerry)
        {
            var newFerry = new Ferry();

            newFerry.TileMap = new Dictionary<Point, FloorTile>();

            foreach (var tile in oldFerry.TileMap)
            {
                var newSeat = new Seat { IsOccupied = true };

                if (tile.Value.Seat is null)
                {
                    newSeat = null;
                }
                else if (tile.Value.Seat.IsOccupied && tile.Value.AreMyNeighboursOccupied(tile.Key, 4))
                {
                    newSeat.IsOccupied = false;
                }
                else if (!tile.Value.Seat.IsOccupied && tile.Value.AreMyNeighboursOccupied(tile.Key, 1))
                {
                    newSeat.IsOccupied = false;
                }

                newFerry.TileMap.Add(tile.Key, new FloorTile
                {
                    Coordinate = tile.Key,
                    Ferry = newFerry,
                    Seat = newSeat
                });
            }
            return newFerry;
        }

        public static Ferry NewFerryWithSwitchedPlaces2(Ferry oldFerry)
        {
            var newFerry = new Ferry();

            newFerry.TileMap = new Dictionary<Point, FloorTile>();

            foreach (var tile in oldFerry.TileMap)
            {
                var newSeat = new Seat();

                if (tile.Value.Seat is null)
                {
                    newSeat = null;
                }
                else if (tile.Value.Seat.IsOccupied && tile.Value.NumberOfTilesInLineOfSight() >= 5)
                {
                    newSeat.IsOccupied = false;
                }
                else if (!tile.Value.Seat.IsOccupied && tile.Value.NumberOfTilesInLineOfSight() == 0)
                {
                    newSeat.IsOccupied = true;
                }
                else
                {
                    newSeat.IsOccupied = tile.Value.Seat.IsOccupied;
                }
                var ft = new FloorTile
                {
                    Coordinate = tile.Key,
                    Ferry = newFerry,
                    Seat = newSeat
                };
                newFerry.TileMap.Add(tile.Key, ft);
            }
            return newFerry;
        }
    }

    public class Ferry
    {
        public Dictionary<Point, FloorTile> TileMap { get; set; }
        public int OccupiedTiles => TileMap.Where(ft => ft.Value.IsOccupied).Count();

        public bool AreEqual(Ferry ferry2)
        {
            foreach (var tile in TileMap)
            {
                var tileToCompare = ferry2.TileMap[tile.Key];

                if (tile.Value.Seat is null && tileToCompare.Seat is null)
                {
                    continue;
                }

                if (tile.Value.IsOccupied == tileToCompare.IsOccupied)
                {
                    continue;
                }
                return false;
            }

            return true;
        }

        public Ferry()
        {
        }

        public Ferry(List<string> input)
        {
            TileMap = new Dictionary<Point, FloorTile>();

            for (int i = 0; i < input.Count; i++)
            {
                var row = input[i];

                for (int j = 0; j < row.Length; j++)
                {
                    switch (row[j])
                    {
                        case '.':
                            TileMap.Add(new Point(j, i), new FloorTile { Coordinate = new Point(j, i), Ferry = this, Seat = null });
                            break;

                        case 'L':
                            TileMap.Add(new Point(j, i), new FloorTile { Coordinate = new Point(j, i), Ferry = this, Seat = new Seat { IsOccupied = false } });
                            break;

                        case '#':
                            TileMap.Add(new Point(j, i), new FloorTile { Coordinate = new Point(j, i), Ferry = this, Seat = new Seat { IsOccupied = true } });
                            break;

                        default:
                            break;
                    }
                }
            }
        }
    }


    public class FloorTile
    {
        public Ferry Ferry { get; set; }
        public Point Coordinate { get; set; }
        public Seat? Seat { get; set; }
        public bool IsOccupied => !(this.Seat is null) && this.Seat.IsOccupied;

        public bool AreMyNeighboursOccupied(Point coordinate, int occCheck)
        {
            var occupiedAdjacent = 0;

            var topLeft = new Point(coordinate.X - 1, coordinate.Y - 1);
            var topMid = new Point(coordinate.X, coordinate.Y - 1);
            var topRight = new Point(coordinate.X + 1, coordinate.Y - 1);
            var left = new Point(coordinate.X - 1, coordinate.Y);
            var right = new Point(coordinate.X + 1, coordinate.Y);
            var bottLeft = new Point(coordinate.X - 1, coordinate.Y + 1);
            var bottMid = new Point(coordinate.X, coordinate.Y + 1);
            var bottRight = new Point(coordinate.X + 1, coordinate.Y + 1);

            if (Ferry.TileMap.TryGetValue(topLeft, out var floorTile) && floorTile.IsOccupied)
            {
                occupiedAdjacent++;
            }
            if (Ferry.TileMap.TryGetValue(topMid, out var floorTile2) && floorTile2.IsOccupied)
            {
                occupiedAdjacent++;
            }
            if (Ferry.TileMap.TryGetValue(topRight, out var floorTile3) && floorTile3.IsOccupied)
            {
                occupiedAdjacent++;
            }
            if (Ferry.TileMap.TryGetValue(left, out var floorTile4) && floorTile4.IsOccupied)
            {
                occupiedAdjacent++;
            }
            if (Ferry.TileMap.TryGetValue(right, out var floorTile5) && floorTile5.IsOccupied)
            {
                occupiedAdjacent++;
            }
            if (Ferry.TileMap.TryGetValue(bottLeft, out var floorTile6) && floorTile6.IsOccupied)
            {
                occupiedAdjacent++;
            }
            if (Ferry.TileMap.TryGetValue(bottMid, out var floorTile7) && floorTile7.IsOccupied)
            {
                occupiedAdjacent++;
            }
            if (Ferry.TileMap.TryGetValue(bottRight, out var floorTile8) && floorTile8.IsOccupied)
            {
                occupiedAdjacent++;
            }

            return occupiedAdjacent >= occCheck;
        }

        public int NumberOfTilesInLineOfSight()
        {
            var directions = new List<string> { "topleft", "topmid", "topright", "left", "right", "bottleft", "bottmid", "bottright" };

            var numberOfOccupied = 0;

            foreach (var direction in directions)
            {
                if (OccupiedInLineOfSight(direction)) numberOfOccupied++;
            }
            return numberOfOccupied;
        }

        private bool OccupiedInLineOfSight(string direction)
        {
            switch (direction)
            {
                case "topleft":
                    if (Ferry.TileMap.TryGetValue(new Point(Coordinate.X - 1, Coordinate.Y - 1), out var topLeftTile))
                    {
                        if (topLeftTile.IsOccupied)
                        {
                            return true;
                        }
                        else if (!(topLeftTile.Seat is null) && !topLeftTile.IsOccupied)
                        {
                            return false;
                        }
                        return topLeftTile.OccupiedInLineOfSight(direction);
                    }
                    return false;
                case "topmid":
                    if (Ferry.TileMap.TryGetValue(new Point(Coordinate.X, Coordinate.Y - 1), out var topMidTile))
                    {
                        if (topMidTile.IsOccupied)
                        {
                            return true;
                        }
                        else if (!(topMidTile.Seat is null) && !topMidTile.IsOccupied)
                        {
                            return false;
                        }
                        return topMidTile.OccupiedInLineOfSight(direction);
                    }
                    return false;
                case "topright":
                    if (Ferry.TileMap.TryGetValue(new Point(Coordinate.X + 1, Coordinate.Y - 1), out var topRightTile))
                    {
                        if (topRightTile.IsOccupied)
                        {
                            return true;
                        }
                        else if (!(topRightTile.Seat is null) && !topRightTile.IsOccupied)
                        {
                            return false;
                        }
                        return topRightTile.OccupiedInLineOfSight(direction);
                    }
                    return false;
                case "left":
                    if (Ferry.TileMap.TryGetValue(new Point(Coordinate.X - 1, Coordinate.Y), out var leftTile))
                    {
                        if (leftTile.IsOccupied)
                        {
                            return true;
                        }
                        else if (!(leftTile.Seat is null) && !leftTile.IsOccupied)
                        {
                            return false;
                        }
                        return leftTile.OccupiedInLineOfSight(direction);
                    }
                    return false;
                case "right":
                    if (Ferry.TileMap.TryGetValue(new Point(Coordinate.X + 1, Coordinate.Y), out var rightTile))
                    {
                        if (rightTile.IsOccupied)
                        {
                            return true;
                        }
                        else if (!(rightTile.Seat is null) && !rightTile.IsOccupied)
                        {
                            return false;
                        }
                        return rightTile.OccupiedInLineOfSight(direction);
                    }
                    return false;
                case "bottleft":
                    if (Ferry.TileMap.TryGetValue(new Point(Coordinate.X - 1, Coordinate.Y + 1), out var bottLeftTile))
                    {
                        if (bottLeftTile.IsOccupied)
                        {
                            return true;
                        }
                        else if (!(bottLeftTile.Seat is null) && !bottLeftTile.IsOccupied)
                        {
                            return false;
                        }
                        return bottLeftTile.OccupiedInLineOfSight(direction);
                    }
                    return false;
                case "bottmid":
                    if (Ferry.TileMap.TryGetValue(new Point(Coordinate.X, Coordinate.Y + 1), out var bottMidTile))
                    {
                        if (bottMidTile.IsOccupied)
                        {
                            return true;
                        }
                        else if (!(bottMidTile.Seat is null) && !bottMidTile.IsOccupied)
                        {
                            return false;
                        }
                        return bottMidTile.OccupiedInLineOfSight(direction);
                    }
                    return false;
                case "bottright":
                    if (Ferry.TileMap.TryGetValue(new Point(Coordinate.X + 1, Coordinate.Y + 1), out var bottRightTile))
                    {
                        if (bottRightTile.IsOccupied)
                        {
                            return true;
                        }
                        else if (!(bottRightTile.Seat is null) && !bottRightTile.IsOccupied)
                        {
                            return false;
                        }
                        return bottRightTile.OccupiedInLineOfSight(direction);
                    }
                    return false;
                default:
                    break;
            }

            return false;
        }
    }

    public class Seat
    {
        public bool IsOccupied { get; set; }
    }

    public static class Help
    {
        public static bool SameCoordinates((int y, int x) coord1, (int y, int x) coord2)
        {
            if (coord1.y == coord2.y && coord1.x == coord2.x)
            {
                return true;
            }
            return false;
        }
    }
}
