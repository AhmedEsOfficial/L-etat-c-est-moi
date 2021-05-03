using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingVisual
{

    GameObject holdingGO;

    public HoldingVisual (Holding h)
    {
        CreateGameObjectForHolding(h.xPos, h.yPos);
    }

    private void CreateGameObjectForHolding(float x, float y)
    {
        Vector3 scale = new Vector3(GridManager.CellSize  , GridManager.CellSize , GridManager.CellSize );
        holdingGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
        holdingGO.transform.localScale = scale;
        holdingGO.transform.position = new Vector3(x + GridManager.CellSize/ 2, GridManager.CellSize/ 2, y + GridManager.CellSize / 2);

    }


}
