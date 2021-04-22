using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityInteract
{
   
    public static void EngageEntities(Entity e1, Entity e2)
    {
        e1.EngageWith(e2);
        e2.EngageWith(e1);
    }
    public static void DisengageEntities(Entity e1, Entity e2)
    {
        e1.disengage();
        e2.disengage();
    }
}
