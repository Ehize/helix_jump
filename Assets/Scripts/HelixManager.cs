﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] helixRings;
    public float ySpawn = 0;
    public float ringDistance;

    public int numberOfRings;
    public GameObject lastRing;
    // Start is called before the first frame update
    void Start()
    {
        numberOfRings = GameManager.currentLevelIndex + 5;
        //spawn helix rings
        for(int i = 0; i < numberOfRings; i++) 
        {
            if (i == 0)
             SpawnRing(0);
            else
             SpawnRing(Random.Range(1, helixRings.Length - 1));
        }

        //spawn last ring
        SpawnRing(helixRings.Length - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRing(int ringIndex) 
    {
        GameObject go = Instantiate(helixRings[ringIndex], transform.up * ySpawn, Quaternion.identity);
        go.transform.parent = transform;
        ySpawn -= ringDistance;
    }
}
