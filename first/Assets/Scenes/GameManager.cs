using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    characterstats attacker;
    characterstats defener;
    internal static object Instance;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void GetAttacker(characterstats attacker)
    {
        this.attacker = attacker;

    }
    public void GetAttack(characterstats attacker, characterstats defener)
    {
        this.attacker = attacker;
        this.defener = defener;
    }
    public void DefenerGetAttacker(characterstats defener)
    {
        if (this.attacker)
        {
            float damage = Math.Max(attacker.currentDamage * 100 / (defener.currentDefense + 100), 1);//MOBA+MMOºâªk
            defener.currentHealth = Math.Max(defener.currentHealth - damage, 0);
            //TODO:Upadt+e UI
            //TODO:¸gÅç Upadte
            defener.UpdateCharacter();
            Debug.Log("-" + damage.ToString("f0") + " " + defener.currentHealth.ToString("f0"));
            this.attacker = null;
        }
    }
}
