using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill : MonoBehaviour
{
    [Header("Targets And Myself")]
    public characterstats player;
    public List<characterstats> characterStatsList;
    public Transform target;

    [Header("�˼�")]

    public bool needTime;
    public float time;
    public float waitTime;
    public float destoryTime;

    [Header("�ޯ��T")]
    public float speed;
    public Collider collider;
    public Rigidbody rigidbody;
    public SkillType skillType = new SkillType();
    public enum SkillType { ���u�L�ߪ��u , �ߪ��u , Chase , �d�� , Wait };
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }
    public void Start()
    {
        player = transform.parent.GetComponent<characterstats>();
        switch (skillType)
        {
            case SkillType.���u�L�ߪ��u:
                �ť�();
                rigidbody.useGravity = false;
                transform.parent = null;
                break;
            case SkillType.�ߪ��u:
                �ť�();
                rigidbody.useGravity = true;
                transform.parent = null;
                break;
            case SkillType.Chase:
                speed = 1;
                destoryTime = 3f;
                needTime = true;
                waitTime = 1;
                rigidbody.useGravity = false;
                transform.parent = null;
                break;
            case SkillType.�d��:
                speed = 0;
                destoryTime = 0.3f;
                rigidbody.useGravity = false;
                collider.isTrigger = true;

                break;
            case SkillType.Wait:
                speed = 0;
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (target)
        {
            transform.LookAt(transform.forward + target.position);
            if (target.GetComponent<characterstats>().objectState == characterdata.ObjectState.Dead)
            {
                target = null;
            }
        }
        if (needTime)
        {
            time += Time.deltaTime;
            if (time > waitTime)
            {
                time = 0;
                needTime = false;
                speed = 50;
            }
        }
        destoryTime -= Time.deltaTime;
        if (destoryTime < 0)
        {
            Destroy(gameObject);
        }
    }
    public void �M�ťؼ�()
    {
        target = null;
        characterStatsList = null;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject != player.gameObject && collision.GetComponent<characterstats>())
        {
            switch (skillType)
            {
                case SkillType.���u�L�ߪ��u:
                    player.TakeDamage(player, collision.GetComponent<characterstats>(), 0.1f);
                    speed = 0;
                    rigidbody.useGravity = true;
                    collider.isTrigger = false;

                    break;
                case SkillType.�ߪ��u:
                    player.TakeDamage(player, collision.GetComponent<characterstats>(), 0.1f);
                    speed = 0;
                    collider.isTrigger = false;
                    break;
                case SkillType.Chase:
                    player.TakeDamage(player, collision.GetComponent<characterstats>(), 0.1f);
                    Destroy(gameObject);

                    break;
                case SkillType.�d��:

                    for (int i = 0; i < characterStatsList.Count; i++)
                    {
                        if (characterStatsList[i] == collision.GetComponent<characterstats>())
                            return;
                    }
                    characterStatsList.Add(collision.GetComponent<characterstats>());
                    player.�ɦ�(player, collision.GetComponent<characterstats>(), 0.7f);

                    break;
                case SkillType.Wait:
                    speed = 0;
                    break;
            }
            //Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != player.gameObject && collision.transform.GetComponent<characterstats>())
        {
            switch (skillType)
            {
                case SkillType.���u�L�ߪ��u:
                    player.TakeDamage(player, collision.transform.GetComponent<characterstats>(), 0.1f);
                    speed = 0;
                    rigidbody.useGravity = true;
                    collider.isTrigger = false;

                    break;
                case SkillType.�ߪ��u:
                    player.TakeDamage(player, collision.transform.GetComponent<characterstats>(), 0.1f);
                    speed = 0;
                    collider.isTrigger = false;
                    break;
                case SkillType.Chase:
                    player.TakeDamage(player, collision.transform.GetComponent<characterstats>(), 0.1f);
                    Destroy(gameObject);

                    break;
                case SkillType.�d��:

                    for (int i = 0; i < characterStatsList.Count; i++)
                    {
                        if (characterStatsList[i] == collision.transform.GetComponent<characterstats>())
                            return;
                    }
                    characterStatsList.Add(collision.transform.GetComponent<characterstats>());
                    player.�ɦ�(player, collision.transform.GetComponent<characterstats>(), 0.7f);

                    break;
                case SkillType.Wait:
                    speed = 0;
                    break;
            }
            //Destroy(gameObject);
        }
    }
    public void �ť�()
    {
        var enemys = FindObjectsOfType<characterstats>();
        speed = 50;
        needTime = true;
        waitTime = 1;
        destoryTime = 2;
    }
}
