using System;
using System.Collections;
using System.Collections.Generic;
using Models.World.TileManagement;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace Models.World.PlayableWorld
{
    
    
    public class ChunkManager : MonoBehaviour
    {


        public int ChunkLength = 32;
        public static int ChunkNum;
        public Chunk[] GameChunks;
        private int width;
        private int[] _allTiles;
        private TilemapStructure manager;

        private Tilemap _graphicMap = new Tilemap();
        private Dictionary<int, Tile> TileTypes = new Dictionary<int, Tile>();
    
        void Start()
        {

            manager = GameObject.Find("messenger").GetComponent<TilemapStructure>();
            width = manager.Width;
            ChunkNum = width / ChunkLength;
            GameChunks = new Chunk[ChunkNum * ChunkNum];
            for (int i = 0; i < 4; i++)
            {
                TileTypes.Add(i,  manager.TileTypeDictionary[i]);

            }
            _allTiles = manager.CopyBiomes();

         
            _graphicMap = this.GetComponent<Tilemap>();
            
            //fillChunks();
            for (int i = 0; i < ChunkNum; i++)
            {
                for (int j = 0; j < ChunkNum; j++)
                {
                    LoadChunkNeighbourhood(i,j);

                }
            }

       
            
            



        }
        
        
        


        // Update is called once per frame
        void Update()
        {
        
        }

      

   
        public void HasLeftChunk(int ChunkX, int ChunkY, int x, int y)
        {
        
        }

        public void fillChunks()
        {
            
            
            for (int chunkX = 0; chunkX < ChunkNum; chunkX++)
            {
                for (int chunkY = 0; chunkY < ChunkNum; chunkY++)
                {
                    GameChunks[(chunkY * ChunkNum) + chunkX] = new Chunk(chunkX, chunkY);
                    GameChunks[(chunkY * ChunkNum) + chunkX].ChunkBiomes = new int[ChunkLength * ChunkLength];
                    
                    for (int x = (ChunkLength * chunkX) ; x < ((ChunkLength * chunkX) + ChunkLength); x++)
                    {
                        for (int y = (ChunkLength * chunkY); y < ((ChunkLength * chunkY) + ChunkLength); y++)
                        {
                            var typeOfTile = 0;
                            
                            typeOfTile = _allTiles[(y * width) + x];
                            //Debug.Log(typeOfTile);
                            
                            GameChunks[(chunkY * ChunkNum) + chunkX].
                                ChunkBiomes[((y - (ChunkLength * chunkY)) * ChunkLength) + (x - (ChunkLength * chunkX))] = typeOfTile;
                            //Debug.Log("Point: " + (y - (ChunkLength * chunkY) + " , " + (x - (ChunkLength * chunkX))) + " Type: " + typeOfTile);

                        }
                    }
                    
                    GameChunks[(chunkY * ChunkNum) + chunkX].SaveChunk("chunk_"+ chunkX+"_"+chunkY);
                }
            }
        }

        public void LoadChunkNeighbourhood(int chunkX, int chunkY)
        {
            GameChunks[(chunkY * ChunkNum) + chunkX] = new Chunk(chunkX, chunkY);
            GameChunks[(chunkY * ChunkNum) + chunkX].ChunkBiomes = GameChunks[(chunkY * ChunkNum) + chunkX].LoadChunk("chunk_"+ chunkX+"_"+chunkY);
            
            var positionsArray = new Vector3Int [ChunkLength* ChunkLength];
            var tilesArray = new Tile[ChunkLength* ChunkLength];
            for (int x = 0 ; x < ChunkLength; x++)
            {
                for (int y = 0; y <  ChunkLength; y++)
                {
                    
                    var typeOfTile = 0;
                    // Add the position at the same index position as the Tile
                    positionsArray[(y * ChunkLength) + x] = new Vector3Int(x  + (chunkX * ChunkLength)  , y + (chunkY * ChunkLength) , 0);
                    // Get what tile is at this position
                   
                    typeOfTile = GameChunks[(chunkY * ChunkNum) + chunkX].ChunkBiomes[((y) * ChunkLength) + (x)];
                    //Debug.Log("Tile ( " + x + " , " + y + ") has a type of" + typeOfTile);

                    // Get the ScriptableObject that matches this type and insert it
                    tilesArray[(y * ChunkLength) + x] = TileTypes[(int)typeOfTile];
                    
                   
                }
            }
            _graphicMap.SetTiles(positionsArray, tilesArray);
            _graphicMap.RefreshAllTiles();
        }
        
        
    
        public void RenderChunkTiles()
        {
            var positionsArray = new Vector3Int [ChunkLength* ChunkLength];
            var tilesArray = new Tile[ChunkLength* ChunkLength];
            int chunkX = 1, chunkY=  1;

            //GameChunks[(chunkY * ChunkNum) + chunkX] = new Chunk(chunkX , chunkY);
            //GameChunks[(chunkY * ChunkNum) + chunkX].ChunkBiomes = GameChunks[(chunkY * ChunkNum) + chunkX].LoadChunk("chunk_"+ chunkX+"_"+chunkY);
            
            
            for (int x = 0 ; x < ChunkLength; x++)
            {
                for (int y = 0; y <  ChunkLength; y++)
                {
                    
                        var typeOfTile = 0;
                        // Add the position at the same index position as the Tile
                        positionsArray[(y * ChunkLength) + x] = new Vector3Int(x  + (chunkX * ChunkLength)  , y + (chunkY * ChunkLength) , 0);
                        // Get what tile is at this position
                   
                        typeOfTile = GameChunks[(chunkY * ChunkNum) + chunkX].ChunkBiomes[((y) * ChunkLength) + (x)];
                        //Debug.Log("Tile ( " + x + " , " + y + ") has a type of" + typeOfTile);

                        // Get the ScriptableObject that matches this type and insert it
                        tilesArray[(y * ChunkLength) + x] = TileTypes[(int)typeOfTile];
                    
                   
                }
            }
            _graphicMap.SetTiles(positionsArray, tilesArray);
            _graphicMap.RefreshAllTiles();

        }
    


    }
}
