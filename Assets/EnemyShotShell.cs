﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotShell : MonoBehaviour {

    public GameObject enemyShellPrefab;
    public float shotSpeed;
    public AudioClip shotSound;
    private float shotIntarval;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        shotIntarval += 1;
        if(shotIntarval % 60 == 0){
            GameObject enemyShell = (GameObject)Instantiate(enemyShellPrefab,transform.position, Quaternion.identity);
            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();

            //forward z軸方向に力を加える
            enemyShellRb.AddForce(transform.forward * shotSpeed);
            AudioSource.PlayClipAtPoint(shotSound, transform.position);
            Destroy(enemyShell, 3.0f);
        }
		
	}
}
