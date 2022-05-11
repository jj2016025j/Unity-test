using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    //W,A,S,D, SPACE, SHIFT, CTRL, TAB, F~K, V~M,     我需要的按鍵
    [Header("目標")]
    public List<characterstats> objectsOrEnemys;
    //public List<characterstats> specialObjectsOrEnemys;
    public bool 被標記;
    public GameObject 標記;
    public Transform noTarget;
    [Header("玩家")]
    public TPPplayermovement playerController;
    public characterstats player;
    public List<GameObject> 技能;
    public Vector3 offset;
    public bool 可控制的;

    //public GameObject talkUI;
    void Start()
    {
        標記.SetActive(被標記); 
        player = GetComponent<characterstats>();
        noTarget = Instantiate(標記.transform);
        noTarget.position = transform.forward*1000;
        可控制的 = playerController.可控制的;
    }

    // Update is called once per frame
    void Update()
    {
        if (可控制的)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                AttackAnyOne(objectsOrEnemys);
            }
            if (player.objectState != characterdata.ObjectState.Dead)
            {
                if (Input.GetKeyDown(KeyCode.Tab))//打自己
                {
                    player.TakeDamageByMySelf();
                }
                if (Input.GetKeyDown(KeyCode.H))//全補
                {
                    取消標記();
                    FindObjectByFindObjectsOfType(objectsOrEnemys);
                    補血();
                }
                if (Input.GetKeyDown(KeyCode.J))
                {
                    範圍補血();
                }
                if (Input.GetKey(KeyCode.K))
                {
                    指向技能();
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    追蹤技能();
                }
                if (Input.GetKeyDown(KeyCode.G))
                {
                    追蹤技能2();
                }
                if (Input.GetKey(KeyCode.L))
                {
                    FindObjectByFindObjectsOfType(objectsOrEnemys);
                }
            }
            if(!player.戰鬥狀態)
                取消標記();//修改
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
    void AttackAnyOne(List<characterstats> objectsOrEnemys)//攻擊所有被標記的敵人
    {
        foreach(var objectOrEnemy in objectsOrEnemys)
        {
            if (objectOrEnemy.objectState != characterdata.ObjectState.Dead) 
                player.TakeDamage(player, objectOrEnemy,1); 
        }
    }
    void 補血()//回復所有被標記的敵人
    {
        foreach (var objectOrEnemy in objectsOrEnemys)
        {
            if (objectOrEnemy.objectState != characterdata.ObjectState.Dead) 
                player.補血(player, objectOrEnemy,0.7f);
        }
    }
    void 範圍補血()//製造一個範圍
    {
        Instantiate(技能[1], transform.position + new Vector3(0, -0.5f, 0), transform.rotation, transform);//標記此物體為父物件
        player.補血(player, player, 0.7f);
    }
    void 指向技能()
    {
        offset = new Vector3(0, 1, 0);
        Instantiate(技能[0], transform.position + offset, transform.rotation, transform);//標記此物體為父物件
    }
    void 追蹤技能()
    {
        offset = new Vector3(0, 1, 0);
        FindObjectByFindObjectsOfType(objectsOrEnemys);
        for (int i = 0; i <= 15; i++)
        {
            Instantiate(技能[2], transform.position + offset, transform.rotation, transform);//標記此物體為父物件
            技能[2].GetComponent<skill>().target = 最近目標(objectsOrEnemys).transform;
        }
    }
    void 追蹤技能2()
    {
        offset = new Vector3(0, 1, 0);
        FindObjectByFindObjectsOfType(objectsOrEnemys);
        for (int i = 0; i <= 20; i++)
        {
            Instantiate(技能[2], transform.position + offset, transform.rotation, transform);//標記此物體為父物件
            技能[2].GetComponent<skill>().target = 隨機目標(objectsOrEnemys).transform;
        }
    }
    public characterstats 隨機目標(List<characterstats> objectsOrEnemys)
    {
        characterstats target = objectsOrEnemys[Random.Range(0, objectsOrEnemys.Count)];
        if (target.transform.GetComponent<characterstats>()==player)
        {
            target = 隨機目標(objectsOrEnemys);
        }
        return target;
    }
    public characterstats 最近目標(List<characterstats> objectsOrEnemys)
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
                enemy.GetComponent<playerManager>().被標記 = true;
                enemy.GetComponent<playerManager>().標記.SetActive(被標記);
                //GameObject 被標記 = enemy.GetComponent<playerManager>().被標記;
                //Instantiate(標記, 被標記.transform.position, Quaternion.identity, 被標記.transform);
            }
        }
    }
    void 取消標記()
    {
        foreach(var objectOrEnemy in objectsOrEnemys)
        {
            被標記 = false;
            標記.SetActive(被標記); 
            /*GameObject 被標記 = objectOrEnemy.GetComponent<playerManager>().被標記;
            for(int i=0;i<= 被標記.transform.childCount; i++)
            {
                if (被標記.transform.GetChild(i)==null)
                {
                    return;

                }
                Debug.Log("0");
                Destroy(被標記.transform.GetChild(i).gameObject);
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
