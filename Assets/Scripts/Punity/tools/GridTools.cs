using System;
using System.Collections.Generic;
using UnityEngine;

namespace Punity.tools
{
    public static class GridTools
    {



        public static Coordinate DirectionCoordinate(this Direction d)
        {
            var x = d switch
            {
                Direction.Left => -1,
                Direction.Right => 1,
                _ => 0
            };
            var y = d switch
            {
                Direction.Top => -1,
                Direction.Bottom => 1,
                _ => 0
            };
            return new Coordinate(y,x);
        }

        public static Vector2 UnitDirection(this Direction d)
        {
            var x = d switch
            {
                Direction.Left => -1f,
                Direction.Right => 1f,
                _ => 0f
            };
            var y = d switch
            {
                Direction.Top => 1f,
                Direction.Bottom => -1f,
                _ => 0f
            };
            return new Vector2(x,y);
        }


        public static Direction DirectionFromCoordinates(Coordinate from, Coordinate to)
        {
            var dr = to.Row - from.Row;
            var dc = to.Col - from.Col;
            if (Math.Abs(dr) + Math.Abs(dc) != 1) throw new Exception($"invalid entry from {from.Row},{from.Col}, to {to.Row},{to.Col}");

            if (dr < 0)
            {
                return Direction.Top;
            }else if (dr > 0)
            {
                return Direction.Bottom;
            }else if (dc > 0)
            {
                return Direction.Right;
            }
            else
            {
                return Direction.Left;
            }
            
        }
        

        public static Coordinate CoordinateDifference(Direction dir)
        {
            return dir switch
            {
                Direction.Left => new Coordinate(0, -1),
                Direction.Right => new Coordinate(0, 1),
                Direction.Top => new Coordinate(-1, 0),
                _ => new Coordinate(1, 0)
            };
        }



        [Serializable]
        public record Coordinate(int Row, int Col)
        {
            public static Coordinate operator +(Coordinate self, Coordinate other)
            {
                return new Coordinate(self.Row + other.Row, self.Col + other.Col);
            }
            
            public static Coordinate operator -(Coordinate self, Coordinate other)
            {
                return new Coordinate(self.Row - other.Row, self.Col - other.Col);
            }
            
            public static Coordinate operator *(Coordinate self, Coordinate other)
            {
                return new Coordinate(self.Row * other.Row, self.Col * other.Col);
            }

            public bool Adjacent(Coordinate other, bool noDiagonal =false)
            {
                var dr = Math.Abs(Row - other.Row);
                var dc = Math.Abs(Col - other.Col);

                if ((dr == 0 && dc == 1) || (dc == 1 && dr == 0)) return true;
                if (noDiagonal) return false;
                return dr == 1 && dc == 1;
            }

            public bool IsEqualTo(Coordinate other)
            {
                return (Row == other.Row) && (Col == other.Col);
            }


            public List<Coordinate> DivideToSingleLengthSegments()
            {
                var list = new List<Coordinate>();

                var magRow = Math.Abs(Row);
                var magCol = Math.Abs(Col);
                var signRow = Math.Sign(Row);
                var signCol = Math.Sign(Col);
                var m = Math.Max(magRow, magCol);
                for (int i = 0; i < m; i++)
                {
                    var r =  i >= magRow ? 0 : signRow;
                    var c =  i >= magCol ? 0 : signCol;
                    
                    list.Add(new Coordinate(r,c));
                }
                return list;
            }
        }

        public static bool Opposing(Direction d1, Direction d2)
        {
            return (d1 == Direction.Left && d2 == Direction.Right) || (d1 == Direction.Right && d2 == Direction.Left) ||
                (d1 == Direction.Top && d2 == Direction.Bottom) || (d1 == Direction.Bottom && d2 == Direction.Top);
        }
        
        
        
        public enum Direction
        {
            Left,Right,Top,Bottom
        }
    }
}
