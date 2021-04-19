using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PeasantMovement: MonoBehaviour


{
    GameObject  movePoint ;
    private float moveSpeed = 2f;
    private float gridMove = 1f;
    private PeasantLink Link;
    float targetDirectionX, targetDirectionZ ;
    bool alternateDirection;
    bool update = true;


    Vector3 targetPosition;

    void Start()
    {
        movePoint = new GameObject();
        movePoint.transform.SetParent(Link.peasant.transform);
        movePoint.transform.localPosition = new Vector3(0,0,0);
}
    private void Update()
    {
        Link.GridUpdate(movePoint.transform);
        setDirection(Link.GetActiveCompassDirection());
        updateMovePointOnGrid();

        if (Link.ChangedTiles)
        {
            Link.PeasantUpdate();
        }
        else
        {
            if(Link.GetActiveMovingStateX() == MovingState.Moving || Link.GetActiveMovingStateZ() == MovingState.Moving)
            {
                transform.position = Vector3.MoveTowards(Link.peasant.transform.position, movePoint.transform.position, moveSpeed * Time.deltaTime);

            }

        }



    }

   

    public void LinkToData(PeasantLink link)
    {
        Link = link;
    }
    private void MakeAMove()
    {
       
    }
    private bool HasReachedTargetStep()
    {
        return false;
    }

    private String CurrentGridLocation()
    {
        int gridX = GridManager.ConvertWorldToTileGridX(transform.position.x);
        int gridZ = GridManager.ConvertWorldToTileGridZ(transform.position.z);

        int plotX = PlotManager.ConvertWorldToPlotX(transform.position.x);
        int plotZ = PlotManager.ConvertWorldToPlotZ(transform.position.z);

        String message = "the peasant is at tile " + gridX + ", " + gridZ + " and at plot: " + plotX + ", " + plotZ;
        return message;
    }

    private void updateMovePointOnGrid()
    {

        //Debug.Log(x + " , " + z);
        
        movePoint.transform.localPosition = new Vector3(targetDirectionX, 0, targetDirectionZ);

    }

    public void setDirection(CompassDirection compass)
    {
        
        targetDirectionX = (GridManager.CellSize/PeasantManager.RefreshRate) * (int)Link.GetActiceDirectionX() * (int)Link.GetActiveMovingStateX();
        targetDirectionZ = (GridManager.CellSize/PeasantManager.RefreshRate) * (int)Link.GetActiceDirectionZ() * (int)Link.GetActiveMovingStateZ();

    }

    public void SetMovementSpeed(float speed)
    {
        moveSpeed = speed;
    }

    void createPathTo(Transform target)
    {
        
        
    }
}
