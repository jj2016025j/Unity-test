using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    public Image image1;
    public Image image2;
    public List<Sprite> images1=new List<Sprite>();
    public List<Sprite> images2=new List<Sprite>();
    public int index1;
    public int index2;
    void Start()
    {
        image1.sprite = images1[index1];
        index1++;
        image2.sprite = images2[index2];
        index2++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)&& index1== images1.Count-1)
        {
            image1.sprite = images1[index1];
            index1 = 0;
            return; 
        }
        if (Input.GetKey(KeyCode.K)&& index2== images2.Count-1)
        {
            image2.sprite = images2[index2];
            index2 = 0;
            return;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            image1.sprite = images1[index1];
            index1++;
        }
        if (Input.GetKey(KeyCode.K))
        {
            image2.sprite = images2[index2];
            index2++;
        }
    }
}
