using System.Collections.Generic;
using UnityEngine;



public class PeasantManager
{
    private List<Entity> peasants = new List<Entity>();
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
                Serf newSerf = new Serf();
               
                addSerf(newSerf);
                CreateSerfGraphics(newSerf, GridManager.tiles[x, z]);
            }   
           
        }
        //Draw Them
      
    }

    
    public void addSerf(Serf newComer)
    {

        peasants.Add(newComer);
        
    }

    public void CreateSerfGraphics(Entity newComer, GridTile startTile)
    {
        
        
        EntityLink bobAlive = newComer.GetLink();
        bobAlive.SetCurrentTile(startTile);
        
        bobAlive.CreateGameObjectForEntity(baseMovementSpeed, startTile);

    }

    public void UpdateWholeSerf()
    {
        
        foreach(Entity p in peasants)
        {
            p.myBrain.sense();
            if (p.myLink.GetCurrentTile().holding != null)
            {
                p.myLink.DestroyEntity();
                
                peasants.Remove(p);
                Debug.Log("Dead!");
            }
            //p.myBrain.GoToTile(0, 0);
            
        }

        
       
    }
}
    
