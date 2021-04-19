using System;
using System.Collections;
using System.Collections.Generic;
using Definitions;
using UnityEngine;

public class GridManager
{
    public static int Width, Height;
    public static float CellSize;

    GameObject Grid = new GameObject("Grid");
    Material Mat;
    public static GridTile[,] tiles;


    /*
     * Layer 1 is for landscape, layer 2 is Plots, layer 3 is grid within the plot;
     */

    public GridManager(int width, int height, float cellSize, Material mat)
    {
        Width = width;
        Height = height;
        CellSize = cellSize;
        Mat = mat;
        tiles = new GridTile[Width, Height];


        for (int x = 0; x < Width; x++)
        {
            for (int z = 0; z < Height; z++)
            {
                CreateGridTileAt(x,z);
            }
        }

    }

    public GridTile[,] GetTileArray()
    {
        return tiles;
    }


    // Creates The Game object for the tile and attaches all nessecary components
    private void CreateGridTileAt(int x, int z)
    {
        //Create Object and Set Position
        Vector3 worldCord = GetWorldPosition(x, z, CellSize);
        tiles[x, z] = new GridTile(x, z, worldCord.x, worldCord.z);
        //Assign Data


        //Assign Visuals
        GameObject tile = new GameObject("tile");
        tile.transform.SetParent(Grid.transform);
        tile.transform.SetPositionAndRotation(worldCord, Quaternion.identity);
        tile.AddComponent<MeshFilter>();
        tile.AddComponent<MeshRenderer>();
        tile.AddComponent<GridTileMesh>();
        tile.GetComponent<GridTileMesh>().Initiate(CellSize, Mat);



        //Assign the tile to the array



    }

    private Vector3 GetWorldPosition(int x, int z, float size)
    {
        return new Vector3(x,0 ,z) * size;
    }


    public static int ConvertWorldToTileGridX(float x)
    {
        float loc = x / CellSize;
        int gridX = Mathf.FloorToInt(loc);
        return gridX;
    }
    public static int ConvertWorldToTileGridZ(float z)
    {
        float loc = z / CellSize;
        int gridZ = Mathf.FloorToInt(loc);
        return gridZ;
    }


    private void GenerateGameObject(Vector3 position, PrimitiveType type)
    {
        GameObject thing = GameObject.CreatePrimitive(type);
        Transform transform = thing.transform;
        transform.localPosition = position;
       
    }
}
