using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot 
{
    int PlotIndexX;
    int PlotIndexZ;

    public GridTile[,] plotTiles;

    public Plot(int xIndex, int zIndex)
    {
        PlotIndexX = xIndex;
        PlotIndexZ = zIndex;
    }


}
