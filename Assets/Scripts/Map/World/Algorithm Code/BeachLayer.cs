using Models.World.TileManagement;
using UnityEngine;

namespace Models.Algorithm_Code
{
    [CreateAssetMenu(fileName = "BeachAlgorithm", menuName = "Algorithms/Beach")]

    public class BeachLayer : AlgorithmBase
    {
        public override void Apply(TilemapStructure tilemap)
        {
            for (int i = 0; i < tilemap.Width; i++)
            {
                for (int j = 0; j < tilemap.Height; j++)
                {
                    if (tilemap.GetTileWater(i, j) == 1)
                    {
                        for (int k = -1; k <= 1; k++)
                        {
                            for (int l = -1; l <= 1; l++)
                            {
                                if (tilemap.InBounds(i + k, j + l))
                                {
                                    if (tilemap.GetTileWater(i + k, j + l) != 1)
                                    {
                                        tilemap.SetTileWater(i+k, j+ l, 2);
                                    }
                                }
                              
                            }
                        }
                    }

                }
            }
            {
                
            }
        }
    }
}