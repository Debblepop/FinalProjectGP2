using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public AudioSource AS;

    public int DeadEnemies = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DeadEnemies >= 4)
        {
            GetComponent<WallScript>().canLeave = true;
        }
    }
    
}
