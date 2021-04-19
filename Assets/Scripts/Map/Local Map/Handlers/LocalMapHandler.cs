using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LocalMapHandler : MonoBehaviour
{

    public int width, height;
    public float cellSize;
    public int plotLength;
    //For the Visuals
    public Material material;


    void Awake()
    {
        GridManager MyGrid = new GridManager(width, height, cellSize,material);
        PlotManager PlotSystem = new PlotManager(width, height, plotLength, cellSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}

