using System;
using System.Collections.Generic;
using System.Linq;

namespace Punity.tools
{
    public static class PathfindingTools
    {

        
        /** This function takes a 2d array of values and a starting position,
         * and yields the shortest path of indices to the zero valued point on the 2d array 
         * startX and startY are indices for the array
         * ar is an array of values, that must include zero as the target
         */
        public static List<(int X, int Y)> FindPathOnDistanceWeightedTiles(int startX, int startY, float[,] ar)
        {
            var firstSpot = new GridSpot(startX,startY,ar[startX,startY]);
            var firstLine = new GridLine();
            firstLine.AddSpot(firstSpot);
            var paths = PathfindingTools.NextStep(firstLine,ar);
            
            return paths
                .OrderBy(x=> x.Spots.Sum(y=> y.Val))
                .FirstOrDefault()
                ?.Spots
                .Select(x => (x.X, x.Y))
                .ToList();
        }
        
        
        
        private static List<GridLine> NextStep(GridLine gl, float[,] vals)
        {
            var output = gl.LastPlus(vals);
            
            if(output.outputType==1) return new List<GridLine>() {gl};
            if(output.outputType==2) return new List<GridLine>() {output.res[0]};


            var p = output.res;
            var n = new List<GridLine>();
            
            
            
            
            
            foreach (var gridLine in p)
            {
                
                n.AddRange(NextStep(gridLine,vals));
            }

            return n;



        }
        
        
        class GridSpot
        {
            public int X;
            public int Y;
            public float Val;

            public GridSpot(int x, int y, float val)
            {
                X = x;
                Y = y;
                Val = val;
            }

            public List<GridSpot> PlusNeighbours(float[,] vals)
            {
                var n = new List<GridSpot>();
                
                // try influence is negligible
                try { if(vals[X-1,Y]<Val) n.Add(new GridSpot(X-1,Y,vals[X-1,Y])); } catch (Exception) { }
                try { if(vals[X+1,Y]<Val) n.Add(new GridSpot(X+1,Y,vals[X+1,Y])); } catch (Exception) { }
                try { if(vals[X,Y-1]<Val) n.Add(new GridSpot(X,Y-1,vals[X,Y-1])); } catch (Exception) { }
                try { if(vals[X,Y+1]<Val) n.Add(new GridSpot(X,Y+1,vals[X,Y+1])); } catch (Exception) { }


                return n; 
            }
        }


        class GridLine
        {
            public List<GridSpot> Spots = new List<GridSpot>();
            private GridSpot _lastGuy;
            public float LastVal => _lastGuy.Val;

            public GridLine()
            {
                
            }

            public void AddSpot(GridSpot gs)
            {
                Spots.Add(gs);
                _lastGuy = gs;
            }

            private GridLine(List<GridSpot> spots, GridSpot lastGuy)
            {
                Spots = spots;
                AddSpot(lastGuy);
            }

            public (List<GridLine> res, int outputType) LastPlus(float[,] vals)
            {
                var l = new List<GridLine>();
                var ns = _lastGuy.PlusNeighbours(vals);

                var anything = false;
                foreach (var gridSpot in ns)
                {
                    var newSpots = new List<GridSpot>(Spots);
                    if (gridSpot.Val < 0.5f)
                    {
                        return (new List<GridLine>() { new GridLine(newSpots,gridSpot)},2);
                    }
                    l.Add(new GridLine(newSpots,gridSpot));
                    anything = true;
                }

                return (l, anything?0:1);
            }
        }
        
    }
}