using Models.World.TileManagement;
using UnityEngine;

namespace Models.Algorithm_Code
{
    [CreateAssetMenu(fileName = "WaterAlgorithm", menuName = "Algorithms/WaterWorld")]


    public class WaterAlgorithm : AlgorithmBase
    {
        public override void Apply(TilemapStructure tilemap)
        {
            int length = tilemap.Width;
            
            
            
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    
                    if ((tilemap.GetTileElevation(i, j) > 0.3) && (tilemap.GetTileElevation(i, j) < 0.5) && tilemap.GetTileBiome(i, j) != 3)
                    {
                        bool North_South;
                        bool West_East;
                       
                            tilemap.SetTileBiome(i, j,3 ); // 3 is Water
                        

                    }

                    
                }
            }
        }
    }
}