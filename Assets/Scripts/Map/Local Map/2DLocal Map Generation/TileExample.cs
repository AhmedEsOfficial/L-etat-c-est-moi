using System.Collections.Generic;
using Models.Algorithm_Code;
using UnityEngine;
using UnityEngine.Tilemaps;
/*
    public class TileExample : MonoBehaviour
    {
    

        public enum GroundTileBiome
        {
            Land = 0, Hills = 1, Mountains = 2, Water = 3
            
        }




        public int Width;
        public int Height;

    
    
    
        private float[] _tilesElevation; // Elevation of each tile
        private float[] _tilesTemperature; // Temperature of each tile
        private float[] _tilesRain; // Frequency of rainfall on each tile
    
        private int[] _tilesBiome; // Determines the biome of the tile, based on all of the above

        private int[] _tilesWater;
        
        
    

        public Dictionary<int, Tile> TileTypeDictionary = new Dictionary<int, Tile>();


        // Conditions for each tile certain biomes


        [SerializeField] public float ElevationScale;
  

        public NoiseSettings noiseSettings = new NoiseSettings();


     //   private MapSaveLoad _loader;

    

        public void InitializeWorld(int x, int y, float ES)
        {
        //    MapSaveLoad _loader0 = new MapSaveLoad();
        //    _loader = _loader0;

            //Map Size
            Width = x;
            Height = y;
            ElevationScale = ES;
            noiseSettings.SetElevationScale(ES);


            _tilesElevation = new float[Width * Height];
            _tilesTemperature = new float[Width * Height];
            _tilesRain = new float[Width * Height];
            _tilesBiome = new int[Width * Height];
            _tilesWater = new int[Width * Height];
        }

        public void SaveWorld()
        {
           // _loader.SaveIntArray(_tilesBiome, "Landmass");
        }

        public int[] LoadWorld()
        {
            // int[] world = _loader.LoadIntArray("Landmass");
            //_tilesBiome = world;
            return null;
        }
    

        public void Generate(AlgorithmBase algorithm)
        {
            algorithm.Apply(this);
        }

  

        public void TakeDictionary(Dictionary<int, Tile> dictionary)
        {
            TileTypeDictionary = dictionary;
        }

        public bool IsInIsland()
        {
            return false;
        }
        public int GetTileBiome(int x, int y)
        {
            return InBounds(x, y) ? _tilesBiome[y * Width + x] : 0;
        }
    
        public void SetTileBiome(int x, int y, int value)
        {
            if (InBounds(x, y))
            {
                _tilesBiome[y * Width + x] = value;
            }
            else
            {
                Debug.Log(" Program Tried To set out of bounds");

            }
        }
 
    
        public float GetTileElevation(int x, int y)
        {
            return InBounds(x, y) ? _tilesElevation[y * Width + x] : 0;
        }
    
        public void SetTileElevation(int x, int y, float value)
        {
            if (InBounds(x, y))
            {
                _tilesElevation[y * Width + x] = value;
            }
            else
            {
                Debug.Log(" Program Tried To set out of bounds");

            }
        }

    
        public float GetTileTemperature(int x, int y)
        {
            return InBounds(x, y) ? _tilesTemperature[y * Width + x] : 0;
        }
    
   
        public void SetTileTemperature(int x, int y, float value)
        {
            if (InBounds(x, y))
            {
                _tilesTemperature[y * Width + x] = value;
            }
            else
            {
                Debug.Log(" Program Tried To set out of bounds");
            }
        }

        public float GetTileRain(int x, int y)
        {
            return InBounds(x, y) ? _tilesRain[y * Width + x] : 0;
        }
    
        public void SetTileRain(int x, int y, float value)
        {
            if (InBounds(x, y))
            {
                _tilesRain[y * Width + x] = value;
            }
            else
            {
                Debug.Log(" Program Tried To set out of bounds");
            }
        }
    
        public int GetTileWater(int x, int y)
        {
            return InBounds(x, y) ? _tilesWater[y * Width + x] : 0;
        }
    
        public void SetTileWater(int x, int y, int value)
        {
            if (InBounds(x, y))
            {
                _tilesWater[y * Width + x] = value;
            }
            else
            {
                Debug.Log(" Program Tried To set out of bounds");

            }
        }

        public int[] CopyBiomes()
        {
            return _tilesBiome;
        }

        public void TakeBiomes(int [] biomes)
        {
            _tilesBiome = biomes;
        }

    


        /// Check if the tile position is valid.
        public bool InBounds(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

    
    
    }

*/

