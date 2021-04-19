using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasantHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public int peasants;
    public int rows;
    public int refreshRate;
    public int movementSpeed;
    PeasantManager manager;
    void Start()
    {
        manager = new PeasantManager(peasants, rows, refreshRate, movementSpeed);
        InvokeRepeating("tellPeasant", 2.0f, 1f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void tellPeasant()
    {
        manager.UpdateWholePeasant();
    }
}
