using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static itemData;

public class bagData : MonoBehaviour
{
    // 武器, 工具, 藥品, 材料
    public List<itemData> bag;//掉落物背包
    public List<itemData> itemBackPack;//物品背包
    public List<itemData> equipmentBar;//裝備欄
    public characterstats 玩家;
    void 功能()//雙擊物品
    {
        if (equipmentBar[0])
        {
            //如果背包J位置為空
            int j = new int(); ;
            itemBackPack[j].ID = equipmentBar[0].ID;
            //如果背包滿了
        }
        int i=new int();
        if (itemBackPack[i].可裝備)//裝備裝備
        {
            玩家.currentMaxHealth += itemBackPack[i].增加血量上限;
            玩家.currentHealth += itemBackPack[i].增加血量上限;//裝備的同時血量提升  可以換方法
            玩家.currentDamage += itemBackPack[i].攻擊力加成;
            玩家.currentDefense += itemBackPack[i].防禦加成;
            玩家.currentHealth += itemBackPack[i].血量加成;
        }
        if (itemBackPack[i].可使用)//使用藥品
        {
            玩家.currentHealth += itemBackPack[i].增加HP;
        }
    }
}