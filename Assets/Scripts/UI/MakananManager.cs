using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MakananManager : MonoBehaviour
{
    public Makanan selectedMakanan;

    [Header("Makanan Description")]
    public GameObject makananDescription;
    public GameObject NextLevelPanel;
    public Image gambar;
    public Makanan makanan;
    public TextMeshProUGUI deskripsi;
    public Button btnExit;

    public GameObject[] bintang;



    #region Singleton
    private static MakananManager _instance;

    public static MakananManager Instance
    {
        get
        {

            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<MakananManager>();
            }

            return _instance;
        }
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        if (selectedMakanan == null) return;
        gambar.sprite = selectedMakanan.sprite;
        deskripsi.text = selectedMakanan.description;
        ShowBintang();
    }

    public void ShowLevelDetail()
    {
        NextLevelPanel.SetActive(true);
    }
    public void HideLevelDetail()
    {
        NextLevelPanel.SetActive(false);
    }
    public void ShowDescription()
    {
        makananDescription.SetActive(true);
    }
    public void HideDescription()
    {
        makananDescription.SetActive(false);
    }
    public void ShowBintang()
    {
        if (GameManager.Instance.getBintang(LevelManager.Instance.levelNumber + 1) == 0) return;
        
        for (int j = 0; j <= GameManager.Instance.getBintang(LevelManager.Instance.levelNumber+1); j++)
        {
            bintang[j].SetActive(true);
        }
    }

}
