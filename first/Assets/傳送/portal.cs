using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�ǰe��
public class portal : MonoBehaviour
{
    public GameObject player;//���a
    public GameObject destinationA;//�ت��a
    public GameObject destinationB;//�ت��a
    public Vector3 offSet;//�קK�u�|�X�{�b�ǰe��������
    public bool isSend;//��Q�ǰe�A���}�ǰe���~��U�@���ǰe
    public float time;//�˼�
    public float sendTime;//�ǰe�ݭn���ɶ�
    public bool cantrans;//�i�H�ǰe

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
