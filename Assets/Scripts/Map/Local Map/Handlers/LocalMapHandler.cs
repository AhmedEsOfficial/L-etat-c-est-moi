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
    HoldingManager holdingManager;
    GridManager MyGrid;
    PlotManager PlotSystem;

    void Awake()
    {
        MyGrid = new GridManager(width, height, cellSize,material);
        PlotSystem = new PlotManager(width, height, plotLength, cellSize);
        holdingManager = new HoldingManager();
        InvokeRepeating("updateIncome", 5.0f, 3.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Clicked(0);
        }

    }

    void Clicked(int type)
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();
        

        if (Physics.Raycast(ray, out hit))
        {
            GameObject interactTile;
            interactTile = hit.collider.gameObject;
            if (interactTile.layer == 13)
            {
                holdingManager.buildHoldingAt(interactTile.transform.position.x, interactTile.transform.position.z);
                Debug.Log(PlotManager.GetPlotAtWorld(interactTile.transform.position.x, interactTile.transform.position.z).holdingNum);
            }

        }
    }

    void updateIncome()
    {
        holdingManager.updateHoldings();
        Debug.Log(holdingManager.wheat);
    }


}

