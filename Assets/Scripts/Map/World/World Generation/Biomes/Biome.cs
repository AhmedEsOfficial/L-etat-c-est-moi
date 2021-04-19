namespace Models.World.Biomes
{
 
    public class Biome
    {
        public int BiomeID;
        
        // Inclusive of Min, Exclusive of Max
        public float MinElevation, MaxElevation, 
            MinTemperature, MaxTemperature, 
            MinRain, MaxRain;

        public void AssignThreshholdsForLandMass( int biomeType)
        {
            BiomeID = biomeType;
            
            //Land
            if (BiomeID == 0)
            {
                MinElevation = 0.3f;
                MaxElevation = 0.7f;
                

            } else if (BiomeID == 1) // Hills
            {
                MinElevation =  0.7f;
                MaxElevation = 0.8f;
                
            } else if (BiomeID == 2) // Mountains
            {
                MinElevation = 0.8f;
                MaxElevation = 1f;
                
            }else if (BiomeID == 3) // Water
            {
                MinElevation = 0.3f;
                MaxElevation = 0.5f;

            }
        }
        
        

    }
}