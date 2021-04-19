using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        for (int i = 0; i < 100; i++)
        {
            Instantiate(myPrefab, new Vector3(2, 5, -40), Quaternion.identity);
        }
    }
}
