using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogText : MonoBehaviour
{
    [Header("UI組件")]
    public Text textLabel;
    public Image faceimage;

    [Header("文本文件")]  
    public TextAsset textFile;
    public int index;
    public float textSpeed;
    public bool textFinished;
    public bool cancelTyping;

    [Header("頭像")]
    public Sprite face01, face02;

    public List<string> textList = new List<string>();

    void Awake()
    {
        GetTextFormFile(textFile);
    }

    private void OnEnable()
    {
        //textLabel.text = textList[index];
        //index++;
        textFinished = false;
        GetTextFormFile(textFile);

        StartCoroutine(SetTextUI());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)&& index == textList.Count-1)
                {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        /*else if (Input.GetKeyDown(KeyCode.K)&& textFinished)
        {
            //textLabel.text = textList[index];
            //index++;
            StartCoroutine(SetTextUI());
        }*/
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (textFinished && !cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if(!textFinished && !cancelTyping)
            {
                cancelTyping = !cancelTyping;
            }
        }
    }
    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";
        switch (textList[index])
        {
            case "1" +
            "":
                faceimage.sprite = face01;
                index++;
                break;
            case "B" +
            "":
                faceimage.sprite = face02;
                index++;
                break;
            case "" +
            "":
                faceimage.sprite = face02;
                index++;
                break;
        }
        for (int i = 0; i < textList[index].Length&&!cancelTyping; i++)
        {
            textLabel.text += textList[index][i];
            yield return new WaitForSeconds(textSpeed);
        }
        textLabel.text = textList[index];
        cancelTyping = false;
        textFinished = true;
        index++;
    }
    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var LineDate = file.text.Split('\n');
        foreach(var line in LineDate)
        {
            textList.Add(line);
        }
        
    }
}
