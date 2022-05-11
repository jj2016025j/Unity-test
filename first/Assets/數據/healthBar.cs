using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour //圖片自己填充 簡單血條系統2
{
    public float currentMaxHealth;
    public float currentHealth;
    public Image bar;
    //public GameObject player;
    public characterstats characterstats;

    void Start()
    {
        if (currentMaxHealth == 0)
        {
            currentMaxHealth = 100;
            currentHealth = currentMaxHealth;
        }
        //bar = GetComponent<Image>();
        //characterstats = player.GetComponent<characterstats>();
    }
    void Update()
    {
        currentMaxHealth = characterstats.currentMaxHealth;
        currentHealth = characterstats.currentHealth;

        //hptext.text = currentHealth.ToString("f0") + "/" + currentMaxHealth.ToString("f0");
        bar.fillAmount = currentHealth / currentMaxHealth;//輸出到血條上
    }
}