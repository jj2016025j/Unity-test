using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class businessDeal : MonoBehaviour
{
    public characterstats �R���A;
    public characterstats �R���B;
    public List<itemData> �R���A�����~;
    public List<itemData> �R���B�����~;
    void Start()
    {
        �R���A�����~ = �R���A.bagData.itemBackPack.Union( �R���A.bagData.equipmentBar).ToList< itemData>();//�X��List��k
        �R���A�����~ = �R���A.bagData.itemBackPack.Concat( �R���A.bagData.equipmentBar).ToList< itemData>();

        �R���A.bagData.itemBackPack.AddRange( �R���A.bagData.equipmentBar);
        �R���A�����~.AddRange(�R���A.bagData.itemBackPack);
        �R���A�����~.AddRange(�R���B.bagData.itemBackPack);
        //�R���A�����~.AddRange(�R���A.bagData.itemBackPack.AddRange(�R���A.bagData.equipmentBar));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
