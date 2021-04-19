using Models.Algorithm_Code.OpenSimplex;
using Models.World.TileManagement;
using UnityEngine;

namespace Models.Algorithm_Code
{
    public abstract class AlgorithmBase : ScriptableObject
    {
        public abstract void Apply(TilemapStructure tilemap);

        public virtual float GenerateNoiseForElement(int height, int width, int x, int y, float freq, OpenSimplex2S Generator, long seed, 
            float amplitude1, float amplitude2 )
        {
            float elementValue = 0f;
            double xCord;  
            double yCord;

            yCord = (double) y / height;
            xCord = (double) x / width;

            yCord = yCord * freq ;
            xCord = xCord * freq;
            
            elementValue = (float) (Generator.Noise2(xCord, yCord) + 1 ) * 0.5f;
            
            Generator = new OpenSimplex2S(seed + 1);
            elementValue = elementValue + ((float) amplitude1 * (float) ((Generator.Noise2(2 * xCord, 2 * yCord) ) +1) * 0.5f);
            
            Generator = new OpenSimplex2S(seed - 1);
            elementValue = elementValue + ((float) amplitude2 * (float) ((Generator.Noise2(4 * xCord, 4 * yCord)) +1)* 0.5f);

            elementValue = elementValue / (1.0f + amplitude1 + amplitude2);
            

                return elementValue;
        }
    }
}