using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour {

    public Transform target;

    //トリガーがほかのコライダーに触れている間実行
    private void OnTriggerStay(Collider other)
    {
        //もしも他のオブジェクトにplayerというタグがついていたら
        if(other.CompareTag("Player")){
            //rootを使うと最上位の親の情報を取得できる
            //lookatメソッドは指定した方向にオブジェクトの向きをかえることができる
            transform.root.LookAt(target);

        }
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
