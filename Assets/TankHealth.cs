using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{

    public GameObject effectPrefab1;
    public GameObject effectPrefab2;
    public int tankHP;

    // ★追加
    public Text HPLabel;


    // ★追加
    void Start()
    {
        HPLabel.text = "HP:" + tankHP;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "EnemyShell")
        {

            tankHP -= 1;

            // ★追加
            HPLabel.text = "HP:" + tankHP;

            Destroy(other.gameObject);

            if (tankHP > 0)
            {
                GameObject effect1 = (GameObject)Instantiate(effectPrefab1, transform.position, Quaternion.identity);
                Destroy(effect1, 1.0f);
            }
            else
            {
                GameObject effect2 = (GameObject)Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 1.0f);

                this.gameObject.SetActive(false);

                Invoke("GoToGameOver", 1.5f);
            }


        }
    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    // ★追加
    public void AddHP(int amount)
    {

        tankHP += amount;

        // こんとろる
        if (tankHP > 10)
        {
            tankHP = 10;
        }

        HPLabel.text = "HP:" + tankHP;
    }

   
}

