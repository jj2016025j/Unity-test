using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    //W,A,S,D, SPACE, SHIFT, CTRL, TAB, F~K, V~M,     �ڻݭn������
    [Header("�ؼ�")]
    public List<characterstats> objectsOrEnemys;
    //public List<characterstats> specialObjectsOrEnemys;
    public bool �Q�аO;
    public GameObject �аO;
    public Transform noTarget;
    [Header("���a")]
    public TPPplayermovement playerController;
    public characterstats player;
    public List<GameObject> �ޯ�;
    public Vector3 offset;
    public bool �i���;

    //public GameObject talkUI;
    void Start()
    {
        �аO.SetActive(�Q�аO); 
        player = GetComponent<characterstats>();
        noTarget = Instantiate(�аO.transform);
        noTarget.position = transform.forward*1000;
        �i��� = playerController.�i���;
    }

    // Update is called once per frame
    void Update()
    {
        if (�i���)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                AttackAnyOne(objectsOrEnemys);
            }
            if (player.objectState != characterdata.ObjectState.Dead)
            {
                if (Input.GetKeyDown(KeyCode.Tab))//���ۤv
                {
                    player.TakeDamageByMySelf();
                }
                if (Input.GetKeyDown(KeyCode.H))//����
                {
                    �����аO();
                    FindObjectByFindObjectsOfType(objectsOrEnemys);
                    �ɦ�();
                }
                if (Input.GetKeyDown(KeyCode.J))
                {
                    �d��ɦ�();
                }
                if (Input.GetKey(KeyCode.K))
                {
                    ���V�ޯ�();
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    �l�ܧޯ�();
                }
                if (Input.GetKeyDown(KeyCode.G))
                {
                    �l�ܧޯ�2();
                }
                if (Input.GetKey(KeyCode.L))
                {
                    FindObjectByFindObjectsOfType(objectsOrEnemys);
                }
            }
            if(!player.�԰����A)
                �����аO();//�ק�
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Run();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Walk();
            }
        }
    }
    void AttackAnyOne(List<characterstats> objectsOrEnemys)//�����Ҧ��Q�аO���ĤH
    {
        foreach(var objectOrEnemy in objectsOrEnemys)
        {
            if (objectOrEnemy.objectState != characterdata.ObjectState.Dead) 
                player.TakeDamage(player, objectOrEnemy,1); 
        }
    }
    void �ɦ�()//�^�_�Ҧ��Q�аO���ĤH
    {
        foreach (var objectOrEnemy in objectsOrEnemys)
        {
            if (objectOrEnemy.objectState != characterdata.ObjectState.Dead) 
                player.�ɦ�(player, objectOrEnemy,0.7f);
        }
    }
    void �d��ɦ�()//�s�y�@�ӽd��
    {
        Instantiate(�ޯ�[1], transform.position + new Vector3(0, -0.5f, 0), transform.rotation, transform);//�аO�����鬰������
        player.�ɦ�(player, player, 0.7f);
    }
    void ���V�ޯ�()
    {
        offset = new Vector3(0, 1, 0);
        Instantiate(�ޯ�[0], transform.position + offset, transform.rotation, transform);//�аO�����鬰������
    }
    void �l�ܧޯ�()
    {
        offset = new Vector3(0, 1, 0);
        FindObjectByFindObjectsOfType(objectsOrEnemys);
        for (int i = 0; i <= 15; i++)
        {
            Instantiate(�ޯ�[2], transform.position + offset, transform.rotation, transform);//�аO�����鬰������
            �ޯ�[2].GetComponent<skill>().target = �̪�ؼ�(objectsOrEnemys).transform;
        }
    }
    void �l�ܧޯ�2()
    {
        offset = new Vector3(0, 1, 0);
        FindObjectByFindObjectsOfType(objectsOrEnemys);
        for (int i = 0; i <= 20; i++)
        {
            Instantiate(�ޯ�[2], transform.position + offset, transform.rotation, transform);//�аO�����鬰������
            �ޯ�[2].GetComponent<skill>().target = �H���ؼ�(objectsOrEnemys).transform;
        }
    }
    public characterstats �H���ؼ�(List<characterstats> objectsOrEnemys)
    {
        characterstats target = objectsOrEnemys[Random.Range(0, objectsOrEnemys.Count)];
        if (target.transform.GetComponent<characterstats>()==player)
        {
            target = �H���ؼ�(objectsOrEnemys);
        }
        return target;
    }
    public characterstats �̪�ؼ�(List<characterstats> objectsOrEnemys)
    {
        characterstats clossOne = objectsOrEnemys[0];
        float minDis = Vector3.Distance(objectsOrEnemys[0].transform.position, transform.position);
        for (int i= 0;i<objectsOrEnemys.Count;i++)
        {
            if (objectsOrEnemys[i].transform != transform)
            {
                float dis = Vector3.Distance(objectsOrEnemys[i].transform.position, transform.position);
                if (minDis > dis)
                {
                    minDis = dis;
                    clossOne = objectsOrEnemys[i];
                }
            }
        }
        return clossOne;
    }
    void FindObjectByFindObjectsOfType(List<characterstats> objectsOrEnemys)
    {
        objectsOrEnemys.Clear();
        var enemys = FindObjectsOfType<characterstats>();

        foreach (var enemy in enemys)
        {
            if (enemy != player)
            {
                objectsOrEnemys.Add(enemy);
                enemy.GetComponent<playerManager>().�Q�аO = true;
                enemy.GetComponent<playerManager>().�аO.SetActive(�Q�аO);
                //GameObject �Q�аO = enemy.GetComponent<playerManager>().�Q�аO;
                //Instantiate(�аO, �Q�аO.transform.position, Quaternion.identity, �Q�аO.transform);
            }
        }
    }
    void �����аO()
    {
        foreach(var objectOrEnemy in objectsOrEnemys)
        {
            �Q�аO = false;
            �аO.SetActive(�Q�аO); 
            /*GameObject �Q�аO = objectOrEnemy.GetComponent<playerManager>().�Q�аO;
            for(int i=0;i<= �Q�аO.transform.childCount; i++)
            {
                if (�Q�аO.transform.GetChild(i)==null)
                {
                    return;

                }
                Debug.Log("0");
                Destroy(�Q�аO.transform.GetChild(i).gameObject);
            }*/

        }
        objectsOrEnemys.Clear();
    }
    void Run()
    {
        player.currentSpeed *= 2;
        playerController.GetSpeed();
    }
    void Walk()
    {
        player.currentSpeed = player.baseSpeed;
        playerController.GetSpeed();
    }

}
