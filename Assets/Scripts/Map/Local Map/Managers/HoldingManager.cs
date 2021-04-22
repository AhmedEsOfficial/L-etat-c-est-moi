using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingManager 
{
    List<Holding> mapHoldings = new List<Holding>();
    public void buildHoldingAt(float x, float y)
    {
        Holding newHolding = new Holding(x, y);
        mapHoldings.Add(newHolding);
        HoldingVisual hv = new HoldingVisual(newHolding);
        GridManager.tiles[GridManager.ConvertWorldToTileGridX(x), GridManager.ConvertWorldToTileGridZ(y)].holding = newHolding;

    }
}
