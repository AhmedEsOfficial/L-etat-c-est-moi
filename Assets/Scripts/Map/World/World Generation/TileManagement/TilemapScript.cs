using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using Models.Algorithm_Code;
using Models.World;
using Models.World.TileManagement;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;



    public class TilemapScript : MonoBehaviour
    {

        
 
        
        [Serializable] 
        public class TileType
        {
            public TilemapStructure.GroundTileBiome groundTile;
            public Sprite tilebase;
        }
        
        
        [FormerlySerializedAs("tileTypes")] [SerializeField] [NotNull]
        private TileType[] _tileTypes = new TileType[4];
       

        [FormerlySerializedAs("_algorithms")] [SerializeField] [NotNull]
        private AlgorithmBase[] algorithms;


  
        
        // World Generation parameters
        public int Height, Width;
        public float ElevationScale; 
        private TilemapStructure Manager ;
        [NotNull] public Dictionary<int, Tile> _tileTypeDictionary = new Dictionary<int, Tile>();

      
        
        void Awake()
        {
            GameObject messenger = new GameObject("messenger");

            messenger.AddComponent<TilemapStructure>();
            Manager = messenger.GetComponent<TilemapStructure>();

            
            Manager.InitializeWorld(Width, Height, ElevationScale);
            Manager.TakeBiomes(Manager.LoadWorld());
            //ApplyAlgorithms();
            SetDictionary();
            //Manager.SaveWorld();
            Manager.TakeDictionary(_tileTypeDictionary);
            messenger.AddComponent<TilemapStructure>() ;






            // Render our data
        }


       void SetDictionary()
        {

            foreach (var tileType in _tileTypes)
            {
                
                // Create a scriptable object instance of type Tile (inherits from TileBase)
                Tile tile;
                tile = ScriptableObject.CreateInstance<Tile>();
              
                // Assign the sprite we created earlier to our tiles
                tile.sprite = tileType.tilebase;
                // Add to dictionary by key GroundTileType int value, value Tile
                int type;
                type = (int) tileType.groundTile;
                
                _tileTypeDictionary.Add(type , tile);
            }

        }
         void ApplyAlgorithms()
        {
            foreach (var algorithm in algorithms)
            {
                Manager.Generate(algorithm);
            }
        }

        /// <summary>
        /// Renders the entire data structure to unity's tilemap.
        /// </summary>
         void RenderAllTiles()
        {
            // Create a positions array and tile array required by _graphicMap.SetTiles
            var positionsArray = new Vector3Int [Width * Height];
            var tilesArray = new Tile[Width * Height];

            // Loop over all our tiles in our data structure
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    var typeOfTile = 0;
                    // Add the position at the same index position as the Tile
                    positionsArray[(y * Width) + x] = new Vector3Int(x, y, 0);
                    // Get what tile is at this position
                   
                        typeOfTile = Manager.GetTileBiome(x, y);



                        // Get the ScriptableObject that matches this type and insert it
                    tilesArray[(y * Width) + x] = _tileTypeDictionary[typeOfTile];
                }
            }

 
        }


    }    
    
 
    
        

