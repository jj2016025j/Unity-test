using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class businessDeal : MonoBehaviour
{
    public characterstats 買賣者A;
    public characterstats 買賣者B;
    public List<itemData> 買賣者A的物品;
    public List<itemData> 買賣者B的物品;
    void Start()
    {
        買賣者A的物品 = 買賣者A.bagData.itemBackPack.Union( 買賣者A.bagData.equipmentBar).ToList< itemData>();//合併List方法
        買賣者A的物品 = 買賣者A.bagData.itemBackPack.Concat( 買賣者A.bagData.equipmentBar).ToList< itemData>();

        買賣者A.bagData.itemBackPack.AddRange( 買賣者A.bagData.equipmentBar);
        買賣者A的物品.AddRange(買賣者A.bagData.itemBackPack);
        買賣者A的物品.AddRange(買賣者B.bagData.itemBackPack);
        //買賣者A的物品.AddRange(買賣者A.bagData.itemBackPack.AddRange(買賣者A.bagData.equipmentBar));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
