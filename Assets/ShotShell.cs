using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ★追加
using UnityEngine.UI;

public class ShotShell : MonoBehaviour
{

    public GameObject shellPrefab;
    public float shotSpeed;
    public AudioClip shotSound;
    public int shotCount;

    // ★追加
    public Text shellLabel;

    private float timeBetweenShot = 0.35f;
    private float timer;

    // ★追加
    // Startの「S」は大文字なので注意！
    void Start()
    {
        shellLabel.text = "Bullut：" + shotCount;
    }


    void Update()
    {

        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && timer > timeBetweenShot)
        {

            if (shotCount < 1)
            {
                return;
            }

            shotCount -= 1;

            // ★追加
            shellLabel.text = "Bullut：" + shotCount;

            timer = 0.0f;

            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity) as GameObject;

            Rigidbody shellRb = shell.GetComponent<Rigidbody>();

            shellRb.AddForce(transform.forward * shotSpeed);

            Destroy(shell, 3.0f);

            AudioSource.PlayClipAtPoint(shotSound, transform.position);
        }
    }
    public void AddShell(int amount){
        shotCount += amount;
        if(shotCount > 30){
            shotCount = 30;

        }
        shellLabel.text = "x" + shotCount;
    }
}