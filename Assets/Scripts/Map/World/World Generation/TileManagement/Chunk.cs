using System;

namespace Models.World.TileManagement
{
    public class Chunk
    {
        public int[] ChunkBiomes;
        public int ChunkX, ChunkY;
        public MapSaveLoad _loader = new MapSaveLoad();

        public Chunk(int x, int y)
        {
            ChunkX = x;
            ChunkY = y;
        }

        public void SaveChunk(String chunkName)
        {
            _loader.SaveIntArray(ChunkBiomes, chunkName);
        }
        
        public int[] LoadChunk(String chunkName)
        {
            return _loader.LoadIntArray(chunkName);
        }

    }
}