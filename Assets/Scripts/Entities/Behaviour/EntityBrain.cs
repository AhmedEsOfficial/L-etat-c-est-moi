using System.Collections;
using UnityEngine;

public class EntityBrain 
{

    EntityLink link;
    Entity myEntity;


        public EntityBrain(EntityLink l, Entity e)
        {
            link = l;
        myEntity = e;
        }

        public void sense()
        {
            CompassDirection d = CompassDirection.Halt;
            link.UpdateDirection(d);
            d = (CompassDirection)Random.Range(0, 9);
            link.UpdateDirection(d);
        }

        public void GoToTile(int x, int y)
        {
            if(link.GetCurrentTile() == GridManager.tiles[x,y])
            {
            
                Debug.Log("We Are Here");
            }
        }
        


}