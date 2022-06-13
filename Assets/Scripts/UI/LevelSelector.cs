using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons;

    public GameObject[] jakartaBintang;
    public GameObject[] acehBintang;
    public GameObject[] tanjungSelorBintang;
    public GameObject[] torajaBintang;
    public GameObject[] jayapuraBintang;

    private int jkt;
    private int ach;
    private int tjs;
    private int trj;
    private int jyp;    

    public int level;
        
    // Start is called before the first frame update
    void Start()
    {
        jkt = PlayerPrefs.GetInt("SaveStars" + 1);
        jyp = PlayerPrefs.GetInt("SaveStars" + 2);
        trj = PlayerPrefs.GetInt("SaveStars" + 3);
        tjs = PlayerPrefs.GetInt("SaveStars" + 4);
        ach = PlayerPrefs.GetInt("SaveStars" + 5);
        
        ShowStars();
    }

    public void ShowLevel()
    {
        int levelReach = PlayerPrefs.GetInt("levelReach", 1);
        
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReach)
            {
                levelButtons[i].interactable = false;
                for (int j = 0; j < levelButtons[i].transform.childCount; j++)
                {
                    levelButtons[i].transform.GetChild(j).gameObject.SetActive(false);
                }
            }
            // if (i <= levelReach)
            // {
            //     
            // }
        }
    }

    public void ShowStars()
    {
        if (jkt == 0 && ach == 0 && tjs == 0 && trj == 0 && jyp == 0)
        {
            return;
        }
        
        for (int j = 0; j <= jkt; j++)
        {
            jakartaBintang[j].SetActive(true);
        }
        for (int j = 0; j <= ach; j++)
        {
            acehBintang[j].SetActive(true);
        }
        for (int j = 0; j <= tjs; j++)
        {
            tanjungSelorBintang[j].SetActive(true);
        }
        for (int j = 0; j <= trj; j++)
        {
            torajaBintang[j].SetActive(true);
        }
        for (int j = 0; j <= jyp; j++)
        {
            jayapuraBintang[j].SetActive(true);
        }
    }
}
