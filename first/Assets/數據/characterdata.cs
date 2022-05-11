using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Data", menuName = "Character Stats/Data")]
public class characterdata : ScriptableObject
{
    public enum ObjectType { Player, Monster, Material,AI };
    public ObjectType objectType;
    public enum ObjectState { Guard, Patrol, Chase, Dead, Attack };
    public ObjectState objectState;

    public string objcetName;
    [Header("Stats Info")]
    public float maxHealth;
    public float currentMaxHealth;
    public float currentHealth;
    public float baseHealthRestore;//血量回復
    public float currentHealthRestore;
    public float baseDefense;
    public float currentDefense;
    public float deadTime;
    public float currentDeadTime;
    [Header("Damage Info")]
    public float baseDamage;
    public float currentDamage;
    public float attackRange;
    public float skillRange;
    public float coolDown;
    public float criticalMultiplier;//爆擊加成
    public float criticalChance;//爆擊機率
    [Header("Other Info")]
    public bool 戰鬥狀態;
    public float 脫離戰鬥時間;
    public float baseSpeed;
    public float currentSpeed;
    public float luck;
    public int money;
    public bagData bagData;
}
