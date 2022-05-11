using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New Item", menuName = "Item Stats/Data")]
public class itemData : ScriptableObject
{
    public enum ObjectType { 武器, 工具, 藥品, 材料 };
    public ObjectType myselfObjectType;
    public string objcetName;
    [Header("ID Info")]
    public int ID;
    public int number;
    public int price;
    public Image image;
    public string overView;//概述
    public bool 可裝備;
    public bool 可使用;
    [Header("Effect Info")]
    public float 增加HP;
    public float 增加血量上限;
    public float 攻擊力加成;
    public float 防禦加成;
    public float 血量加成;
}
