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
public class EntityLink
{

    public GameObject peasant;

    private GridTile CurrentTile;
    private GridTile NextTile;

    DirectionX ActiveDirectionX = DirectionX.Right;
    DirectionZ ActiveDirectionZ = DirectionZ.Up;
    MovingState ActiveMovingStateX = MovingState.Stationary;
    MovingState ActiveMovingStateZ = MovingState.Stationary;
    CompassDirection ActiveCompassDirection;


    public bool ChangedTiles = true;
    //System to figure out if grid tile changed
    int trackX, trackZ, trackX1, trackZ1;
    bool turn = true;

    public void CreateGameObjectForEntity(float initialMovementSpeed, GridTile startingTile)
    {
        peasant = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        SetCurrentTile(startingTile);
        GetCurrentTile().SetHasEntity(true);

        peasant.transform.position = GetCurrentTile().GetWorldCords();
        peasant.AddComponent<EntityMovement>();
        peasant.GetComponent<EntityMovement>().LinkToData(this);
        peasant.GetComponent<EntityMovement>().SetMovementSpeed(initialMovementSpeed);

        //CompassDirection d = (CompassDirection)Random.Range(0, 9) ;
        //CompassDirection d = CompassDirection.North;
        HeadInCompassDirection(ActiveCompassDirection);
        
        trackX1 = GetCurrentTile().GetTileGridX();
        trackZ1 = GetCurrentTile().GetTileGridX();


    }

    public void GridUpdate(Transform futurePos)
    {
        int x = GridManager.ConvertWorldToTileGridX(peasant.transform.position.x);
        int z = GridManager.ConvertWorldToTileGridZ(peasant.transform.position.z);
        if (x >= 0 && x < GridManager.Width && z >= 0 && z < GridManager.Height)
        {
            SetCurrentTile(GridManager.tiles[x, z]);

        }

        HeadInCompassDirection(ActiveCompassDirection);

        if (turn)
        {
            trackX = GetCurrentTile().GetTileGridX();
            trackZ = GetCurrentTile().GetTileGridZ();
            turn = false;

        }
        else
        {
            trackX1 = GetCurrentTile().GetTileGridX();
            trackZ1 = GetCurrentTile().GetTileGridZ();
            turn = true;
        }

        if (CurrentGridTileChanged())
        {
            GridManager.tiles[trackX, trackZ].SetHasEntity(false);
            ChangedTiles = true;
            SetNextTile(futurePos);
            GetCurrentTile().SetHasEntity(true);
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
        if(GetCurrentTile() != GetNextTile())
        {
            
            if (GetNextTile().HasEntity())
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
            SetNextTile(GridManager.tiles[x, z]);

        }
        else
        {
            ActiveCompassDirection = CompassDirection.Halt;
        }

    }

    public void DestroyEntity()
    {
        peasant.GetComponent<EntityMovement>().DestroyEntityGO();
    }
    public GridTile GetCurrentTile()
    {
        return CurrentTile;
    }
    public void SetCurrentTile(GridTile tile)
    {
        CurrentTile = tile;
    }
    public GridTile GetNextTile()
    {
        return NextTile;
    }
    public void SetNextTile(GridTile tile)
    {
        NextTile = tile;
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
