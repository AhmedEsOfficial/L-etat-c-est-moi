using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager
{
    int PlotNumX, PlotNumZ;
    int PlotLength;
    public static float PlotSize;

    public static Plot[,] plots;

    public PlotManager(int width, int height, int plotLength, float cellSize)
    {
        PlotLength = plotLength;
        PlotNumX = width / plotLength;
        PlotNumZ = height / plotLength;
        PlotSize = PlotLength * cellSize;
        plots = new Plot[PlotNumX, PlotNumZ];
       
        for (int x = 0; x < PlotNumX; x++)
        {
            for (int z = 0; z < PlotNumZ; z++)
            {
                CreatePlotAt(x, z);
            }
        }
    }

    private void CreatePlotAt(int x, int z)
    {
        plots[x, z] = new Plot(x, z);
        plots[x, z].plotTiles = new GridTile[PlotLength, PlotLength];
        // assign grid tiles references
        for(int i = x*PlotLength; i < (x*PlotLength) + PlotLength; i++)
        {
            for (int j = z*PlotLength; j < (z * PlotLength) + PlotLength; j++)
            {
                plots[x, z].plotTiles[i - (x*PlotLength), j - (z * PlotLength)] = GridManager.tiles[i , j];
            }
        }

    }

    public static int ConvertWorldToPlotX(float x)
    {
        float loc = x / PlotManager.PlotSize;
        int gridX = Mathf.FloorToInt(loc);
        return gridX;
    }
    public static int ConvertWorldToPlotZ(float z)
    {
        float loc = z / PlotManager.PlotSize;
        int gridZ = Mathf.FloorToInt(loc);
        return gridZ;
    }
}
