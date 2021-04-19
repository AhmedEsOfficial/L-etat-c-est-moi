using Assets.Scripts.Entities.Behaviour;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class Peasant
{
    int ID;
    private GridTile CurrentTile;
    private GridTile NextTile;
    public PeasantLink myLink;
    public PeasantBrain myBrain;
    int Direction;

    public Peasant (GridTile StartTile)
    {
        CurrentTile = StartTile;
        CurrentTile.SetHasEntity(true);
   
    }

    public GridTile GetCurrentTile()
    {
        return CurrentTile;
    }
    public void SetCurrentTile(GridTile tile)
    {
        CurrentTile = tile;
        ;
    }
    public GridTile GetNextTile()
    {
        return NextTile;
    }
    public void SetNextTile(GridTile tile)
    {
        NextTile = tile;
    }

    public void EstablishLink(PeasantLink link)
    {
        myLink = link;
    }

    public PeasantLink GetLink()
    {
        return myLink;
    }
    public void GiveBrain(PeasantBrain b)
    {
        myBrain = b;
    }
}
