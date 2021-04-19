using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Models.World.TileManagement
{
    
    public class MapSaveLoad
    {

        public void SaveIntArray(int[] array, String NameOfArray)
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Create (Application.persistentDataPath + "/"+ NameOfArray + ".gd"); 
            Debug.Log(Application.persistentDataPath);
    
            bf.Serialize(file, array);
            file.Close();
        }

        public int[] LoadIntArray(String NameOfArray)
        {
            BinaryFormatter bf = new BinaryFormatter();

            int[] array = null;
            if(File.Exists(Application.persistentDataPath + "/"+ NameOfArray +".gd")) {
                FileStream file = File.Open(Application.persistentDataPath + "/"+NameOfArray+".gd", FileMode.Open);
                array = (int[]) bf.Deserialize(file);
                file.Close();
            }
            
            return array;
        }
        

   
    }
    
}