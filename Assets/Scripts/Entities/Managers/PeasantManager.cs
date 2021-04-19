using Assets.Scripts.Entities.Behaviour;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PeasantManager
{
    private List<Peasant> peasants = new List<Peasant>();
    public static float RefreshRate;
    public static float baseMovementSpeed;

    CompassDirection CurrentDirection;
    public PeasantManager(int startPeasantNum, int rowNum, float movementRefreshRate, int movementSpeed)
    {
        RefreshRate = movementRefreshRate;
        baseMovementSpeed = movementSpeed;
        
        //Create The Peasants
        for (int x = 0; x < startPeasantNum; x++)
        {
            for (int z = 0; z < rowNum; z++)
            {
                Peasant newPeasant = new Peasant(GridManager.tiles[x, z]);
                addPeasant(newPeasant);
            }   
           
        }
        //Draw Them
        for(int i = 0; i < startPeasantNum* rowNum; i++)
        {
            CreatePeasantGraphics(peasants[i]);
        }
    }

    
    public void addPeasant(Peasant newComer)
    {

        peasants.Add(newComer);
        
    }

    public void CreatePeasantGraphics(Peasant newComer)
    {
        
        newComer.GetCurrentTile().SetHasEntity(true);

        PeasantLink bobAlive = new PeasantLink();
        newComer.EstablishLink(bobAlive);
        bobAlive.PeasantSpawn(newComer, baseMovementSpeed);
        PeasantBrain brain = new PeasantBrain(bobAlive);
        newComer.GiveBrain(brain);

    }

    public void UpdateWholePeasant()
    {
        
        foreach(Peasant p in peasants)
        {
            p.myBrain.sense();
        }
       
    }
}
