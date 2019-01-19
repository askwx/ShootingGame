﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : MonoBehaviour {

    public GameObject effectPrefab;
    public AudioClip getSound;
    private TankHealth th;
    private int reward = 3;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            // Find()メソッドの使い方をマスターすること
            th = GameObject.Find("Tank").GetComponent<TankHealth>();

            // AddHP()メソッドを呼び出して「引数」にrewardを与えている。
            th.AddHP(reward);

            Destroy(gameObject);
            GameObject effect = (GameObject)Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(getSound, Camera.main.transform.position);
        }
    }
}