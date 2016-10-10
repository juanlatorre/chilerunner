﻿using UnityEngine;
using System.Collections;

public class PrefabSpawner : MonoBehaviour {
	
	private float nextSpawn = 0;
    public Transform prefabToSpawn;
   
    public AnimationCurve spawnCurve;
    public float curveLengthInSeconds = 30f;
    private float startTime;
    public float jitter = 0.25f;

	void Start () {
        startTime = Time.time;
	}
	
	void Update () {
		
        if (Time.time > nextSpawn) {
			Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
            //nextSpawn = Time.time + spawnRate + Random.Range(0, randomDelay);

            float curvePos = (Time.time - startTime) / curveLengthInSeconds;
            if (curvePos > 1f) {
                curvePos = 1f;
                startTime = Time.time;
            }

            nextSpawn = Time.time + spawnCurve.Evaluate(curvePos) + Random.Range(-jitter, jitter);
        }
	}
}