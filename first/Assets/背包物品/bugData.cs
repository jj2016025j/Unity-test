using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static itemData;

public class bagData : MonoBehaviour
{
    // �Z��, �u��, �ī~, ����
    public List<itemData> bag;//�������I�]
    public List<itemData> itemBackPack;//���~�I�]
    public List<itemData> equipmentBar;//�˳���
    public characterstats ���a;
    void �\��()//�������~
    {
        if (equipmentBar[0])
        {
            //�p�G�I�]J��m����
            int j = new int(); ;
            itemBackPack[j].ID = equipmentBar[0].ID;
            //�p�G�I�]���F
        }
        int i=new int();
        if (itemBackPack[i].�i�˳�)//�˳Ƹ˳�
        {
            ���a.currentMaxHealth += itemBackPack[i].�W�[��q�W��;
            ���a.currentHealth += itemBackPack[i].�W�[��q�W��;//�˳ƪ��P�ɦ�q����  �i�H����k
            ���a.currentDamage += itemBackPack[i].�����O�[��;
            ���a.currentDefense += itemBackPack[i].���m�[��;
            ���a.currentHealth += itemBackPack[i].��q�[��;
        }
        if (itemBackPack[i].�i�ϥ�)//�ϥ��ī~
        {
            ���a.currentHealth += itemBackPack[i].�W�[HP;
        }
    }
}