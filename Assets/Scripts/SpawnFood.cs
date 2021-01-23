using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    // Food prefab
    public GameObject foodPrefab;

    // Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    // Start is called before the first frame update
    void Start()
    {
            //Spawn food every 6 seconds, starting in 3
            InvokeRepeating("Spawn", 3, 3);
    }

    // Food spawner
    void Spawn()
    {
        //random x position between left and right border
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x); // int is used to make sure food doesn't spawn at ex. 1.234.

        //random y position between top and bottom border
        int y = (int)Random.Range(borderTop.position.y, borderBottom.position.y);

        //instatiate foot at (x, y)
        Instantiate(foodPrefab,
                    new Vector2(x, y),
                    Quaternion.identity);
    }
}
