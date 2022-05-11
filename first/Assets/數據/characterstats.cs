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
                //objectStateText.text = "待命";
                break;
            case ObjectState.Patrol:
                //objectStateText.text = "Patrol";
                break;
            case ObjectState.Dead:
                //objectStateText.text = "死亡";
                currentDeadTime = 0;
                break;
        }
        //objectStateText.text = "狀態:" + objectStateText.text;
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
    }//爆擊加成
    //public Text criticalmultipliertext;

    public float criticalChance
    {
        get { if (CharacterData != null) return CharacterData.criticalChance; else return 0; }
        set { CharacterData.criticalChance = value; }
    }//爆擊機率
    //public Text criticalchanceText;
    public bool 戰鬥狀態
    {
        get { if (CharacterData != null) return CharacterData.戰鬥狀態; else return false; }
        set { CharacterData.戰鬥狀態 = value; }
    }
    public float 脫離戰鬥時間
    {
        get { if (CharacterData != null) return CharacterData.脫離戰鬥時間; else return 0; }
        set { CharacterData.脫離戰鬥時間 = value; }
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
        //復原
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
        if (objectState != ObjectState.Dead)//確保死亡不補血、不會被攻擊
        {
            HealthRestore();
        }
        if (戰鬥狀態)
        {
            脫離戰鬥時間 -= Time.deltaTime;
            if (脫離戰鬥時間 < 0)
            {
                戰鬥狀態 = false;
                脫離戰鬥時間 = 10;
            }
        }
        MakeSureHealth();
        UpdateDeadTime();
    }
    public void UpdateDeadTime()//計算死亡時間
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
    public void UpdateCharacter()//更新資訊
    {
        switch (objectType)
        {
            case ObjectType.Player:
                //objectTypeText.text = "Player";
                //currentHealthRestoreText.text = "回復:" + (100 * currentHealthRestore).ToString("f0") + "%";

                //criticalchanceText.text = "爆擊機率:" + (100 * criticalchance).ToString("f0") + "%";
                //currentDamageText.text = "攻擊力:" + currentDamage.ToString("f0");

                break;
            case ObjectType.Monster:
                //objectTypeText.text = "Monster";
                //currentDamageText.text = "攻擊力:" + currentDamage.ToString("f0");

                break;
            case ObjectType.Material:
                //objectTypeText.text = "Material";
                break;
        }
        objectStateSwitch();
        //objectTypeText.text = "種類:" + objectTypeText.text;
        //objcetNameText.text = "名稱:" + objcetName;
        //currentHealthText.text = "血量" + currentHealth.ToString("f0") + "/" + currentMaxHealth.ToString("f0");
        //currentDefenceText.text = "防禦:" + currentDefense.ToString("f0");
        //Convert.ToString(currentHealthRestore)小數用這個
        //criticalchance.ToString("f0.00")整數用這個
        //currentDeadTimeText.text = (objectState == ObjectState.Dead) ? currentDeadTime + "/" + deadTime : " ";
    }
    public void HealthRestore()//血量回復
    {
        currentHealth = currentHealth + currentMaxHealth * currentHealthRestore * Time.deltaTime;
        //currentHealthText.text = "血量" + currentHealth.ToString("f0") + "/" + currentMaxHealth.ToString("f0");

    }
    public void MakeSureHealth()//確認血量狀態
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
        //currentHealthText.text = "血量" + currentHealth.ToString("f0") + "/" + currentMaxHealth.ToString("f0");
        if(objectState == ObjectState.Dead&& currentHealth > 0)
        {
            currentHealth = 0;
        }
    }
    public void TakeDamageByMySelf()//測試用
    {
            TakeDamage(this, this,1);
            UpdateCharacter();
    }
    public void TakeDamage(characterstats attacker, characterstats defener, float variable)//算出攻擊者的攻擊力減去被攻擊者的防禦後的傷害
    {
        float 恢復量 = 計算爆擊(attacker) * variable;// 恢復技能加成
        
        float damage = Math.Max(currentDamage *100/(defener.currentDefense+100), 1);//MOBA算法
        defener.currentHealth = Math.Max(defener.currentHealth - damage, 0);
        UpdateCharacter();
        attacker.戰鬥狀態 = true;
        defener.戰鬥狀態 = true;
        defener.acimator.SetTrigger("Hit");
        if (attacker.iscritical)
        {
            Debug.Log("爆擊" + "攻擊力:" + damage.ToString("f0") + "剩餘血量: " + defener.currentHealth.ToString("f0"));
            return;
            //defener.GetComponent<Animator>().SetTrigger("Hit");
        }

        Debug.Log("攻擊力:" + damage.ToString("f0") + "剩餘血量: " + currentHealth.ToString("f0"));
    }
    public void 補血(characterstats 補師, characterstats 被補, float variable)
    {
        float 恢復量 = 計算爆擊(補師) * variable;// 恢復技能加成
        被補.currentHealth = Math.Min(被補.currentHealth + 恢復量, 被補.currentMaxHealth);
        UpdateCharacter();
        Debug.Log("回復量:" + 恢復量.ToString("f0") + "剩餘血量: " + 被補.currentHealth.ToString("f0"));
    }

    float 計算爆擊(characterstats attacker)
    {
        float random = UnityEngine.Random.value;
        attacker.iscritical = random <= attacker.criticalChance;//亂數小於爆擊率=爆擊
        float currentDamage = iscritical ? attacker.currentDamage * 2 : attacker.currentDamage;
        return currentDamage;
    }
    public float CurrentValue(characterstats attacker,float variable)//計算隨機傷害
    {
        float random = 0.3f;//隨機傷害範圍
        float currentDamage = attacker.currentDamage* variable;
        currentDamage = UnityEngine.Random.Range(currentDamage - currentDamage * random, currentDamage + currentDamage * random);

        return currentDamage;
    }

}
