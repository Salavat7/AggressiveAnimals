using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float whenSpawn = 2;
    private float whenTrySpawn = 4;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (whenTrySpawn - whenSpawn >= 1)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                whenSpawn = Time.realtimeSinceStartup;
            }
            whenTrySpawn = Time.realtimeSinceStartup;
        }
        
    }
}