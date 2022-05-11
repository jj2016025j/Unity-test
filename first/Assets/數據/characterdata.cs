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
    public float baseHealthRestore;//��q�^�_
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
    public float criticalMultiplier;//�z���[��
    public float criticalChance;//�z�����v
    [Header("Other Info")]
    public bool �԰����A;
    public float �����԰��ɶ�;
    public float baseSpeed;
    public float currentSpeed;
    public float luck;
    public int money;
    public bagData bagData;
}
