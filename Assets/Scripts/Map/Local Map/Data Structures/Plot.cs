using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot 
{
    public int PlotIndexX;
    public int PlotIndexZ;
    private List<Holding> myHoldings = new List<Holding>();
    public int holdingNum;
    public GridTile[,] plotTiles;

    public Plot(int xIndex, int zIndex)
    {
        PlotIndexX = xIndex;
        PlotIndexZ = zIndex;
        plotTiles = new GridTile[PlotManager.PlotLength, PlotManager.PlotLength];
    }

    public void addHolding(Holding h)
    {
        myHoldings.Add(h);
        holdingNum = holdingNum + 1;
    }

    public void SetTile(int x, int y, GridTile t)
    {
        plotTiles[x, y] = t; 
    }
   

    

}
