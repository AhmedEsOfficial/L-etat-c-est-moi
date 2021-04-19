using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectionX
{
   Right = 1, Left = -1
} // Horizontal
public enum DirectionZ
{
    Up = 1, Down = -1
} // Vertical
public enum MovingState
{
    Stationary = 0, Moving = 1
}


public enum CompassDirection // Going ClockWise
{
    North = 0, NorthEast = 1, East = 2, SouthEast = 3, South = 4, SouthWest = 5, West = 6, NorthWest = 7, Halt = 8
}
public class PeasantLink
{

    Peasant myPeasant;
    public GameObject peasant;

    DirectionX ActiveDirectionX = DirectionX.Right;
    DirectionZ ActiveDirectionZ = DirectionZ.Up;
    MovingState ActiveMovingStateX = MovingState.Stationary;
    MovingState ActiveMovingStateZ = MovingState.Stationary;
    CompassDirection ActiveCompassDirection;
    public bool ChangedTiles = true;
    //System to figure out if grid tile changed
    int trackX, trackZ, trackX1, trackZ1;
    bool turn = true;

    public void PeasantSpawn(Peasant bob, float movementSpeed)
    {
        peasant = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        peasant.transform.position = bob.GetCurrentTile().GetWorldCords();
        peasant.AddComponent<PeasantMovement>();
        peasant.GetComponent<PeasantMovement>().LinkToData(this);
        peasant.GetComponent<PeasantMovement>().SetMovementSpeed(movementSpeed);
        myPeasant = bob;
        //CompassDirection d = (CompassDirection)Random.Range(0, 9) ;
        //CompassDirection d = CompassDirection.North;
        HeadInCompassDirection(ActiveCompassDirection);
        
        trackX1 = myPeasant.GetCurrentTile().GetTileGridX();
        trackZ1 = myPeasant.GetCurrentTile().GetTileGridX();


    }

    public void GridUpdate(Transform futurePos)
    {
        int x = GridManager.ConvertWorldToTileGridX(peasant.transform.position.x);
        int z = GridManager.ConvertWorldToTileGridZ(peasant.transform.position.z);
        if (x >= 0 && x < GridManager.Width && z >= 0 && z < GridManager.Height)
        {
            myPeasant.SetCurrentTile(GridManager.tiles[x, z]);

        }

        HeadInCompassDirection(ActiveCompassDirection);

        if (turn)
        {
            trackX = myPeasant.GetCurrentTile().GetTileGridX();
            trackZ = myPeasant.GetCurrentTile().GetTileGridZ();
            turn = false;

        }
        else
        {
            trackX1 = myPeasant.GetCurrentTile().GetTileGridX();
            trackZ1 = myPeasant.GetCurrentTile().GetTileGridZ();
            turn = true;
        }

        if (CurrentGridTileChanged())
        {
            GridManager.tiles[trackX, trackZ].SetHasEntity(false);
            ChangedTiles = true;
            SetNextTile(futurePos);
            myPeasant.GetCurrentTile().SetHasEntity(true);
        }
        else
        {
            ChangedTiles = false;
        }
    }


    public void PeasantUpdate()
    {
        if (DetectCollision())
            {
                HeadInCompassDirection(CompassDirection.Halt);
            }
        else
        {

        }
        //Debug.Log("Current TIle at " + myPeasant.GetCurrentTile().GetTileGridX() + " , " + myPeasant.GetCurrentTile().GetTileGridZ() + " and next Tile at " + myPeasant.GetNextTile().GetTileGridX() + " , " + myPeasant.GetNextTile().GetTileGridZ());
    }

    public void UpdateDirection(CompassDirection D)
    {
        ActiveCompassDirection = D;
    }
    public bool DetectCollision()
    {
        
        bool willCollide = false;
        if(myPeasant.GetCurrentTile() != myPeasant.GetNextTile())
        {
            
            if (myPeasant.GetNextTile().HasEntity())
            {
                willCollide = true;
            }
        }
        return willCollide;
        
    }

    public bool CurrentGridTileChanged()
    {
        return (trackX != trackX1 || trackZ != trackZ1);
    }
    public void SetNextTile(Transform pos)
    {
        int x = GridManager.ConvertWorldToTileGridX(pos.position.x);
        int z = GridManager.ConvertWorldToTileGridZ(pos.position.z);

        if (x >= 0 && x < GridManager.Width && z >= 0 && z < GridManager.Height)
        {
            myPeasant.SetNextTile(GridManager.tiles[x, z]);

        }
        else
        {
            ActiveCompassDirection = CompassDirection.Halt;
        }






    }

    public void HeadInCompassDirection(CompassDirection thatWay)
    {
        ActiveCompassDirection = thatWay;
        int Id = (int)thatWay;
        if (Id == 0)
        {
            ActiveDirectionZ = DirectionZ.Up;
            ActiveMovingStateZ = MovingState.Moving;
            ActiveMovingStateX = MovingState.Stationary;
        }
        if (Id == 1)
        {
            ActiveDirectionX = DirectionX.Right;
            ActiveDirectionZ = DirectionZ.Up;
            ActiveMovingStateX = MovingState.Moving;
            ActiveMovingStateZ = MovingState.Moving;

        }
        if (Id == 2)
        {
            ActiveDirectionX = DirectionX.Right;
            ActiveMovingStateX = MovingState.Moving;
            ActiveMovingStateZ = MovingState.Stationary;
        }
        if (Id == 3)
        {
            ActiveDirectionX = DirectionX.Left;
            ActiveDirectionZ = DirectionZ.Down;
            ActiveMovingStateX = MovingState.Moving;
            ActiveMovingStateZ = MovingState.Moving;
        }
        if (Id == 4)
        {
            ActiveDirectionZ = DirectionZ.Down;
            ActiveMovingStateZ = MovingState.Moving;
            ActiveMovingStateX = MovingState.Stationary;
        }
        if (Id == 5)
        {
            ActiveDirectionX = DirectionX.Right;
            ActiveDirectionZ = DirectionZ.Down;
            ActiveMovingStateX = MovingState.Moving;
            ActiveMovingStateZ = MovingState.Moving;
        }
        if (Id == 6)
        {
            ActiveDirectionX = DirectionX.Left;
            ActiveMovingStateX = MovingState.Moving;
            ActiveMovingStateZ = MovingState.Stationary;
        }
        if (Id == 7)
        {
            ActiveDirectionX = DirectionX.Left;
            ActiveDirectionZ = DirectionZ.Up;
            ActiveMovingStateX = MovingState.Moving;
            ActiveMovingStateZ = MovingState.Moving;
        }
        if (Id == 8)
        {
            ActiveDirectionX = DirectionX.Right;
            ActiveDirectionZ = DirectionZ.Up;
            ActiveMovingStateX = MovingState.Stationary;
            ActiveMovingStateZ = MovingState.Stationary;
        }
     
    }




    public DirectionX GetActiceDirectionX()
    {
        return ActiveDirectionX;
    }
    public DirectionZ GetActiceDirectionZ()
    {
        return ActiveDirectionZ;
    }
    public MovingState GetActiveMovingStateX()
    {
        return ActiveMovingStateX;
    }
    public MovingState GetActiveMovingStateZ()
    {
        return ActiveMovingStateZ;
    }
    public CompassDirection GetActiveCompassDirection()
    {
        return ActiveCompassDirection;
    }
}
