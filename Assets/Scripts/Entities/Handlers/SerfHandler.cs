using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerfHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public int Serfs;
    public int rows;
    public int refreshRate;
    public int movementSpeed;
    PeasantManager manager;
    void Start()
    {
        manager = new PeasantManager(Serfs, rows, refreshRate, movementSpeed);
        InvokeRepeating("tellPeasant", 2.0f, 5f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void tellPeasant()
    {
        manager.UpdateSerfs();
    }
}
