using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GridTileMesh: MonoBehaviour
{
    // Start is called before the first frame update
    public int X_Size; 
    public int Z_Size;
    public float TileSize;
    public float Scale;
    public Material Mat;
    Mesh Mesh;

    public void Initiate(float scale, Material mat)
    {
        Mesh = new Mesh();
        Mat = mat;
        Scale = scale;
        BuildMesh();
    }


    public void BuildMesh()
    {
        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        vertices[0] = new Vector3(0, 0, 1);
        vertices[1] = new Vector3(1, 0, 1);
        vertices[2] = new Vector3(0, 0, 0);
        vertices[3] = new Vector3(1, 0, 0);

        uv[0] = new Vector3(0, 0, 1);
        uv[1] = new Vector3(1, 0, 1);
        uv[2] = new Vector3(0, 0, 0);
        uv[3] = new Vector3(1, 0, 0);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 2;
        triangles[4] = 1;
        triangles[5] = 3;

        Mesh.vertices = vertices;
        Mesh.uv = uv;
        Mesh.triangles = triangles;
      

        this.GetComponent<MeshFilter>().mesh = Mesh;
        this.GetComponent<MeshRenderer>().material = Mat;
        this.transform.localScale = new Vector3(Scale, 1, Scale);

        
        



        /*int numOfTiles = X_Size * Z_Size;
        int triNum = numOfTiles * 2;
        int vSizeX = X_Size + 1;
        int vSizeY = Z_Size + 1;
        int numOfVert = vSizeX * vSizeY;
        
        Vector3[] vertices = new Vector3[numOfVert];
        Vector3[] normals = new Vector3[numOfVert];
        Vector2[] uv = new Vector2[numOfVert];
        int[] triangles = new int[triNum * 3];
        
        
        
        
        
        
        MeshFilter mf = GetComponent<MeshFilter>();
        MeshRenderer mr = GetComponent<MeshRenderer>();
        MeshCollider mc = GetComponent<MeshCollider>();*/
    }
    public void updateMat(Material m)
    {
        this.GetComponent<MeshRenderer>().material = m;

    }
}
