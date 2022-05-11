using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//傳送門
public class portal : MonoBehaviour
{
    public GameObject player;//玩家
    public GameObject destinationA;//目的地
    public GameObject destinationB;//目的地
    public Vector3 offSet;//避免只會出現在傳送門正中央
    public bool isSend;//剛被傳送，離開傳送門才能下一次傳送
    public float time;//倒數
    public float sendTime;//傳送需要的時間
    public bool cantrans;//可以傳送

    void Update()
    {
        if (cantrans)
        {
            time += Time.deltaTime;
            if (time >= 5)
            {
                cantrans = false;
                time = 0;
                offSet = new Vector3(Random.Range(-1, 1), Random.Range(1, 5), Random.Range(-1, 1));
                player.transform.position = destinationA.transform.position+ offSet;
                isSend = true;
            }
        }
        
    }
    public void OnTriggerStay(Collider other)
    {
        cantrans = true;
        player = other.gameObject;
    }
    public void OnTriggerExit(Collider other)
    {
        cantrans = false;
        time = 0;
        player = null;
        isSend = false;

    }
}
