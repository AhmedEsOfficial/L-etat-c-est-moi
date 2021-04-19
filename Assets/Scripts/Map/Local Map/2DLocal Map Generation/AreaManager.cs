using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AreaManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int length;
    [SerializeField] public RuleTile Biome;
    [SerializeField] public Sprite grass;
    public Tile tile;
    private Tilemap _graphicMap = new Tilemap();

    void Awake()
    {
        _graphicMap = this.GetComponent<Tilemap>() ;
        tile = ScriptableObject.CreateInstance<Tile>();
        tile.sprite = grass;
        RenderMap();
    }

    public void RenderMap()
    {
        var positionArray = new Vector3Int[length * length];
        var tilesArray = new RuleTile[length* length];

        for (int x = 0; x < length; x++)
        {
            for (int y = 0; y < length; y++)
            {
                positionArray[(y * length) + x] = new Vector3Int(x, y, 0);
                tilesArray[(y * length) + x] = Biome;
            }
        }
        


            
        _graphicMap.SetTiles(positionArray,tilesArray);
        _graphicMap.RefreshAllTiles();

    }

}
