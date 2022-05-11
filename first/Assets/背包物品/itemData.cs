using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New Item", menuName = "Item Stats/Data")]
public class itemData : ScriptableObject
{
    public enum ObjectType { �Z��, �u��, �ī~, ���� };
    public ObjectType myselfObjectType;
    public string objcetName;
    [Header("ID Info")]
    public int ID;
    public int number;
    public int price;
    public Image image;
    public string overView;//���z
    public bool �i�˳�;
    public bool �i�ϥ�;
    [Header("Effect Info")]
    public float �W�[HP;
    public float �W�[��q�W��;
    public float �����O�[��;
    public float ���m�[��;
    public float ��q�[��;
}
