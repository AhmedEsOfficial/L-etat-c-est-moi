using System;
using System.Collections.Generic;
using Models.Algorithm_Code.OpenSimplex;
using Models.World.Biomes;
using Models.World.TileManagement;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Models.Algorithm_Code
{
    [CreateAssetMenu(fileName = "SimplexNoiseWorldGeneration", menuName = "Algorithms/SimplexWorld")]
    public class NoiseElementsGenerationAlgorithm : AlgorithmBase    
    {


        private int Width, Height;

        

        private float ElevationScale;

     

        private OpenSimplex2S Generator;
        
        public override void Apply(TilemapStructure tilemap)
        {
            // Will be used to determine type of biome
            // Column = second index of array = Number of BiomeType of Land

            // Setting threshholds of differnet biomes
            Biome currentBiome = new Biome();

                //Fetching parameters
            Width = tilemap.Width;
            Height = tilemap.Height;
            
            int columns = 4; 
            
            ElevationScale = tilemap.noiseSettings.GetElevationScale();

            
            long seed = Random.Range(-1000000000, 1000000000);
            Generator = new OpenSimplex2S(seed);
            
            //Actual Generation Code
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    float  ElevationValue = 1f;

                    
                    ElevationValue = GenerateNoiseForElement(Height, Width, x,  y, ElevationScale, Generator, seed, 
                        0.5f , 0.25f);
                    
                    

                    
                    tilemap.SetTileElevation(x, y, ElevationValue); 

                    
                    bool[,] biomeConditions = new bool[1 , columns];
                    for (int i = 0; i < columns; i++)
                    {
                        currentBiome.AssignThreshholdsForLandMass(i);

                            // Inclusive of Min, Exclusive of Max
                            Debug.Log(ElevationValue);

                            if (ElevationValue >= currentBiome.MinElevation &&
                                ElevationValue < currentBiome.MaxElevation)
                            {
                                biomeConditions[0, i] = true;
                            }
                    }
                    
                    int BiomeType;
                    for (int i = 0; i < columns; i++)
                    {
                        if (biomeConditions[0, i])
                        {
                            BiomeType = i;
                           
                            tilemap.SetTileBiome(x, y, BiomeType);


                        }
                        
                        
                    }
           
                    
                    

                }
            }
        }

       
        

      
     
    }
}

