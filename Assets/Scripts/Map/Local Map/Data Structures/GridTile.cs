using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile
{
    private int GridX;
    private int GridZ;
    float WorldX, WorldZ;
    private bool hasEntity;
    

    public GridTile(int gridX, int gridZ, float worldX, float worldZ)
    {
        GridX = gridX;
        GridZ = gridZ;
        WorldX = worldX + (GridManager.CellSize/2);
        WorldZ = worldZ + (GridManager.CellSize/2);
    }

    public int GetTileGridX()
    {
        return GridX;
    }
    public int GetTileGridZ()
    {
        return GridZ;
    }
    public float GetTileWorldX()
    {
        return WorldX;
    }
    public float GetTileWorldZ()
    {
        return WorldZ;
    }
    public bool HasEntity()
    {
        return hasEntity;
    }
    public void SetHasEntity(bool occupied)
    {
        hasEntity = occupied;
    }
    public Vector3 GetWorldCords()
    {
        return new Vector3(WorldX, 1, WorldZ);
    }

}
