using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Entities.Behaviour
{
    public class PeasantBrain 
    {
        PeasantLink link;

        public PeasantBrain(PeasantLink l)
        {
            link = l;
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

        }

    }
}