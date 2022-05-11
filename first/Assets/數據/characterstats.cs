using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static characterdata;

public class characterstats : MonoBehaviour
{
    public characterdata copyCharacterData;
    public characterdata CharacterData;
    public bool iscritical;
    public GameManager gameManager;
    public Animator acimator;

    //public Button attackButton;
    //public Button defenseButton;
    public ObjectType objectType
    {
        get { if (CharacterData != null) return CharacterData.objectType; else return new ObjectType(); }
    }
    //public Text objectTypeText;
    public string objcetName
    {
        get { if (CharacterData != null) return CharacterData.objcetName; else return " "; }
        set { CharacterData.objcetName = value; }
    }
    //public Text objcetNameText;
    public ObjectState objectState
    {
        get { if (CharacterData != null) return CharacterData.objectState; else return new ObjectState(); }
        set { CharacterData.objectState = value; }
    }
    public void objectStateSwitch()
    {
        switch (objectState)
        {
            case ObjectState.Guard:
                //objectStateText.text = "�ݩR";
                break;
            case ObjectState.Patrol:
                //objectStateText.text = "Patrol";
                break;
            case ObjectState.Dead:
                //objectStateText.text = "���`";
                currentDeadTime = 0;
                break;
        }
        //objectStateText.text = "���A:" + objectStateText.text;
    }
    //public Text objectStateText;

    public float maxHealth
    {
        get { if (CharacterData != null) return CharacterData.maxHealth; else return 0; }
        set { CharacterData.maxHealth = value; }
    }
    //public Text maxHealthtext;
    public float currentMaxHealth
    {
        get { if (CharacterData != null) return CharacterData.currentMaxHealth; else return 0; }
        set { CharacterData.currentMaxHealth = value; }
    }
    //public Text currentMaxHealthText;
    public float currentHealth
    {
        get { if (CharacterData != null) return CharacterData.currentHealth; else return 0; }
        set { CharacterData.currentHealth = value; }
    }
    //public Text currentHealthText;
    public float baseHealthRestore
    {
        get { if (CharacterData != null) return CharacterData.baseHealthRestore; else return 0; }
        set { CharacterData.baseHealthRestore = value; }
    }
    //public Text baseHealthRestoretext;
    public float currentHealthRestore
    {
        get { if (CharacterData != null) return CharacterData.currentHealthRestore; else return 0; }
        set { CharacterData.currentHealthRestore = value; }
    }
    //public Text currentHealthRestoreText;
    public float baseDefense
    {
        get { if (CharacterData != null) return CharacterData.baseDefense; else return 0; }
        set { CharacterData.baseDefense = value; }
    }
    //public Text baseDefencetext;
    public float deadTime
    {
        get { if (CharacterData != null) return CharacterData.deadTime; else return 0; }
        set { CharacterData.deadTime = value; }
    }
    //public Text deadTimeText;
    public float currentDeadTime
    {
        get { if (CharacterData != null) return CharacterData.currentDeadTime; else return 0; }
        set { CharacterData.currentDeadTime = value; }
    }
    //public Text currentDeadTimeText;

    public float currentDefense
    {
        get { if (CharacterData != null) return CharacterData.currentDefense; else return 0; }
        set { CharacterData.currentDefense = value; }
    }
    //public Text currentDefenceText;

    public float baseDamage
    {
        get { if (CharacterData != null) return CharacterData.baseDamage; else return 0; }
        set { CharacterData.baseDamage = value; }
    }
    //public Text baseDamagetext;

    public float currentDamage
    {
        get { if (CharacterData != null) return CharacterData.currentDamage; else return 0; }
        set { CharacterData.currentDamage = value; }
    }
    //public Text currentDamageText;

    public float attackRange
    {
        get { if (CharacterData != null) return CharacterData.attackRange; else return 0; }
        set { CharacterData.attackRange = value; }
    }

    public float skillRange
    {
        get { if (CharacterData != null) return CharacterData.skillRange; else return 0; }
        set { CharacterData.skillRange = value; }
    }

    public float coolDown
    {
        get { if (CharacterData != null) return CharacterData.coolDown; else return 0; }
        set { CharacterData.coolDown = value; }
    }

    public float criticalMultiplier
    {
        get { if (CharacterData != null) return CharacterData.criticalMultiplier; else return 0; }
        set { CharacterData.criticalMultiplier = value; }
    }//�z���[��
    //public Text criticalmultipliertext;

    public float criticalChance
    {
        get { if (CharacterData != null) return CharacterData.criticalChance; else return 0; }
        set { CharacterData.criticalChance = value; }
    }//�z�����v
    //public Text criticalchanceText;
    public bool �԰����A
    {
        get { if (CharacterData != null) return CharacterData.�԰����A; else return false; }
        set { CharacterData.�԰����A = value; }
    }
    public float �����԰��ɶ�
    {
        get { if (CharacterData != null) return CharacterData.�����԰��ɶ�; else return 0; }
        set { CharacterData.�����԰��ɶ� = value; }
    }

    public float baseSpeed
    {
        get { if (CharacterData != null) return CharacterData.baseSpeed; else return 0; }
        set { CharacterData.baseSpeed = value; }
    }
    public float currentSpeed
    {
        get { if (CharacterData != null) return CharacterData.currentSpeed; else return 0; }
        set { CharacterData.currentSpeed = value; }
    }
    public int money
    {
        get { if (CharacterData != null) return CharacterData.money; else return 0; }
        set { CharacterData.money = value; }
    }

    public bagData bagData
    {
        get { if (CharacterData != null) return CharacterData.bagData; else return new bagData(); }
        set { CharacterData.bagData = value; }
    }


    private void Awake()
    {
        //�_��
        if (copyCharacterData)
            CharacterData = Instantiate(copyCharacterData);
        currentHealth = maxHealth;
        currentMaxHealth = maxHealth;
        currentHealthRestore = baseHealthRestore;
        currentDefense = baseDefense;
        currentDamage = baseDamage;
        currentSpeed = baseSpeed;
        UpdateCharacter();
        //attackButton.onClick.AddListener(() => gameManager.GetAttacker(this));
        //defenseButton.onClick.AddListener(() => gameManager.DefenerGetAttacker(this));
    }
    private void Update()
    {
        if (objectState != ObjectState.Dead)//�T�O���`���ɦ�B���|�Q����
        {
            HealthRestore();
        }
        if (�԰����A)
        {
            �����԰��ɶ� -= Time.deltaTime;
            if (�����԰��ɶ� < 0)
            {
                �԰����A = false;
                �����԰��ɶ� = 10;
            }
        }
        MakeSureHealth();
        UpdateDeadTime();
    }
    public void UpdateDeadTime()//�p�⦺�`�ɶ�
    {
        if (objectState == ObjectState.Dead)
        {
            currentDeadTime += Time.deltaTime;
            //currentDeadTimeText.text = currentDeadTime.ToString("f0") + "/" + deadTime.ToString("f0");
            if (currentDeadTime >= deadTime)
            {
                objectState = ObjectState.Guard;
                acimator.SetBool("Dead", false);
                acimator.SetBool("Life", true);
                currentHealth = maxHealth;
                currentDeadTime = 0;
                UpdateCharacter();
            }
        }

    }
    public void UpdateCharacter()//��s��T
    {
        switch (objectType)
        {
            case ObjectType.Player:
                //objectTypeText.text = "Player";
                //currentHealthRestoreText.text = "�^�_:" + (100 * currentHealthRestore).ToString("f0") + "%";

                //criticalchanceText.text = "�z�����v:" + (100 * criticalchance).ToString("f0") + "%";
                //currentDamageText.text = "�����O:" + currentDamage.ToString("f0");

                break;
            case ObjectType.Monster:
                //objectTypeText.text = "Monster";
                //currentDamageText.text = "�����O:" + currentDamage.ToString("f0");

                break;
            case ObjectType.Material:
                //objectTypeText.text = "Material";
                break;
        }
        objectStateSwitch();
        //objectTypeText.text = "����:" + objectTypeText.text;
        //objcetNameText.text = "�W��:" + objcetName;
        //currentHealthText.text = "��q" + currentHealth.ToString("f0") + "/" + currentMaxHealth.ToString("f0");
        //currentDefenceText.text = "���m:" + currentDefense.ToString("f0");
        //Convert.ToString(currentHealthRestore)�p�ƥγo��
        //criticalchance.ToString("f0.00")��ƥγo��
        //currentDeadTimeText.text = (objectState == ObjectState.Dead) ? currentDeadTime + "/" + deadTime : " ";
    }
    public void HealthRestore()//��q�^�_
    {
        currentHealth = currentHealth + currentMaxHealth * currentHealthRestore * Time.deltaTime;
        //currentHealthText.text = "��q" + currentHealth.ToString("f0") + "/" + currentMaxHealth.ToString("f0");

    }
    public void MakeSureHealth()//�T�{��q���A
    {
        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;
        else if (currentHealth <= 0.5f && (objectState != ObjectState.Dead))
        {
            currentHealth = 0;
            objectState = ObjectState.Dead;
            acimator.SetBool("Dead", true);
            acimator.SetBool("Life", false);
            UpdateCharacter();
        }
        else if (currentHealth <= 0.5f)
        {
            currentHealth = 0;
        }
        //currentHealthText.text = "��q" + currentHealth.ToString("f0") + "/" + currentMaxHealth.ToString("f0");
        if(objectState == ObjectState.Dead&& currentHealth > 0)
        {
            currentHealth = 0;
        }
    }
    public void TakeDamageByMySelf()//���ե�
    {
            TakeDamage(this, this,1);
            UpdateCharacter();
    }
    public void TakeDamage(characterstats attacker, characterstats defener, float variable)//��X�����̪������O��h�Q�����̪����m�᪺�ˮ`
    {
        float ��_�q = �p���z��(attacker) * variable;// ��_�ޯ�[��
        
        float damage = Math.Max(currentDamage *100/(defener.currentDefense+100), 1);//MOBA��k
        defener.currentHealth = Math.Max(defener.currentHealth - damage, 0);
        UpdateCharacter();
        attacker.�԰����A = true;
        defener.�԰����A = true;
        defener.acimator.SetTrigger("Hit");
        if (attacker.iscritical)
        {
            Debug.Log("�z��" + "�����O:" + damage.ToString("f0") + "�Ѿl��q: " + defener.currentHealth.ToString("f0"));
            return;
            //defener.GetComponent<Animator>().SetTrigger("Hit");
        }

        Debug.Log("�����O:" + damage.ToString("f0") + "�Ѿl��q: " + currentHealth.ToString("f0"));
    }
    public void �ɦ�(characterstats �ɮv, characterstats �Q��, float variable)
    {
        float ��_�q = �p���z��(�ɮv) * variable;// ��_�ޯ�[��
        �Q��.currentHealth = Math.Min(�Q��.currentHealth + ��_�q, �Q��.currentMaxHealth);
        UpdateCharacter();
        Debug.Log("�^�_�q:" + ��_�q.ToString("f0") + "�Ѿl��q: " + �Q��.currentHealth.ToString("f0"));
    }

    float �p���z��(characterstats attacker)
    {
        float random = UnityEngine.Random.value;
        attacker.iscritical = random <= attacker.criticalChance;//�üƤp���z���v=�z��
        float currentDamage = iscritical ? attacker.currentDamage * 2 : attacker.currentDamage;
        return currentDamage;
    }
    public float CurrentValue(characterstats attacker,float variable)//�p���H���ˮ`
    {
        float random = 0.3f;//�H���ˮ`�d��
        float currentDamage = attacker.currentDamage* variable;
        currentDamage = UnityEngine.Random.Range(currentDamage - currentDamage * random, currentDamage + currentDamage * random);

        return currentDamage;
    }

}
