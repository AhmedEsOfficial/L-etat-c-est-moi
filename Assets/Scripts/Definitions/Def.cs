using UnityEngine;

namespace Definitions
{
    public class Def
    {
        public string uid { get; set; }

        public override int GetHashCode()
        {
            return this.uid.GetHashCode();
        }
    }

    public class GraphicDef : Def
    {
        
    }

    public class TilableDef : Def
    {
        public Layer layer;
        
    }

    public class GroundDef : Def
    {
        public GroundTile groundTile;
    }
}
