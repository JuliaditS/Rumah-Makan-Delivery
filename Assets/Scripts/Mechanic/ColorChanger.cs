using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{


    private Image img;
    public Sprite[] fillImage;
    public Sprite[] emoji;

    void Start()
    {
        img = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.Instance.emotionPoint > 0 && LevelManager.Instance.emotionPoint <= 3 )
        {
            img.sprite = fillImage[2];
        } else if (LevelManager.Instance.emotionPoint >= 4 && LevelManager.Instance.emotionPoint <= 7)
        {
            img.sprite = fillImage[1];
        }
        else if (LevelManager.Instance.emotionPoint >= 8 && LevelManager.Instance.emotionPoint < 15)
        {
            img.sprite = fillImage[0];
        }
    }
}
