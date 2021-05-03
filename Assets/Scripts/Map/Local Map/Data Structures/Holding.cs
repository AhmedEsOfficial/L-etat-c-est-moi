using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holding 
{
    int exampleValue = 124;
    public float xPos, yPos;
    public GridTile myTile;
    public int product = 1;

    public Holding(float x, float y)
    {
        myTile = GridManager.tiles[GridManager.ConvertWorldToTileGridX(x), GridManager.ConvertWorldToTileGridZ(y)];
        xPos = x;
        yPos = y;
    }


}
