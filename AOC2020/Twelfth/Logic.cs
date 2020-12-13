using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AOC2020.Twelfth
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

        private static int First(List<(char action, int steps)> input)
        {
            var shipDirection = 0;
            var coordinate = new Point(0, 0);

            foreach (var command in input)
            {
                switch (command.action)
                {
                    case 'N':
                        coordinate.Y += command.steps;
                        break;

                    case 'S':
                        coordinate.Y -= command.steps;
                        break;

                    case 'E':
                        coordinate.X += command.steps;
                        break;

                    case 'W':
                        coordinate.X -= command.steps;
                        break;

                    case 'L':
                        shipDirection += command.steps;
                        shipDirection = shipDirection % 360;
                        break;

                    case 'R':
                        shipDirection -= command.steps;
                        shipDirection = shipDirection % 360;
                        break;

                    case 'F':
                        switch (shipDirection)
                        {
                            case 0:
                                coordinate.X += command.steps;
                                break;
                            case 90:
                            case -270:
                                coordinate.Y += command.steps;
                                break;
                            case 180:
                            case -180:
                                coordinate.X -= command.steps;
                                break;
                            case -90:
                            case 270:
                                coordinate.Y -= command.steps;
                                break;
                        }
                        break;

                    default:
                        break;
                }
            }

            return Math.Abs(coordinate.X) + Math.Abs(coordinate.Y);
        }

        private static int Second(List<(char action, int steps)> input)
        {
            var shipCoordinate = new Point(0, 0);
            var wayPoint =  new Point(10, 1);

            foreach (var command in input)
            {
                switch (command.action)
                {
                    case 'N':
                        wayPoint.Y += command.steps;
                        break;

                    case 'S':
                        wayPoint.Y -= command.steps;
                        break;

                    case 'E':
                        wayPoint.X += command.steps;
                        break;

                    case 'W':
                        wayPoint.X -= command.steps;
                        break;

                    case 'L':
                        wayPoint = RotateWayPoint(wayPoint, command.steps);
                        break;

                    case 'R':
                        wayPoint = RotateWayPoint(wayPoint, command.steps * -1);
                        break;

                    case 'F':
                        shipCoordinate.X += command.steps * wayPoint.X;
                        shipCoordinate.Y += command.steps * wayPoint.Y;
                        break;

                    default:
                        break;
                }
            }

            return Math.Abs(shipCoordinate.X) + Math.Abs(shipCoordinate.Y);
        }

        static Point RotateWayPoint(Point pointToRotate, double angleInDegrees)
        {
            double angleInRadians = angleInDegrees * (Math.PI / 180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
            return new Point
            {
                X =
                    (int)
                    Math.Round((cosTheta * (pointToRotate.X) -
                    sinTheta * pointToRotate.Y)),
                Y =
                    (int)
                    Math.Round((sinTheta * (pointToRotate.X) +
                    cosTheta * pointToRotate.Y))
            };
        }
    }
}
