using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelDetail : MonoBehaviour
{
    public Image title;
    public Button btnPlay;
    public GameObject container;
    public GameObject btnPrefab;
    public GameObject[] bintang = new GameObject[4];
    public GameObject panelWindow;
    public List<GameObject> listButton = new List<GameObject>();
 
    [Header("Makanan Description")]
    public Makanan[] jakarta = new Makanan[2];
    public Makanan[] jayapura = new Makanan[3];
    public Makanan[] makassar = new Makanan[3];
    public Makanan[] selor = new Makanan[4];
    public Makanan[] aceh = new Makanan[4];

    [Header("Sprite")]
    public Sprite jakartaSprite;
    public Sprite jayapuraSprite;
    public Sprite makassarSprite;
    public Sprite selorSprite;
    public Sprite acehSprite;

    public void showJakarta()
    {
        title.sprite = jakartaSprite;
        panelWindow.SetActive(true);

        for (int i = 0; i < jakarta.Length; i++)
        {
            GameObject button = Instantiate(btnPrefab, container.transform);
            button.GetComponent<ButtonMakanan>().makanan = jakarta[i];
            listButton.Add(button);
        }
        ShowStars(1);
        btnPlay.onClick.AddListener(() => { MenuManager.Instance.GoToLevel(2); Destroy(MenuSound.Instance.gameObject); }); 
    }

    public void showJayapura()
    {
        title.sprite = jayapuraSprite;
        panelWindow.SetActive(true);

        for (int i = 0; i < jayapura.Length; i++)
        {
            GameObject button = Instantiate(btnPrefab, container.transform);
            button.GetComponent<ButtonMakanan>().makanan = jayapura[i];
            listButton.Add(button);
        }
        ShowStars(2);
        btnPlay.onClick.AddListener(() => { MenuManager.Instance.GoToLevel(3); Destroy(MenuSound.Instance.gameObject); });
    }
    public void showMakassar()
    {
        title.sprite = makassarSprite;
        panelWindow.SetActive(true);

        for (int i = 0; i < makassar.Length; i++)
        {
            GameObject button = Instantiate(btnPrefab, container.transform);
            button.GetComponent<ButtonMakanan>().makanan = makassar[i];
            listButton.Add(button);
        }
        ShowStars(3);
        btnPlay.onClick.AddListener(() => { MenuManager.Instance.GoToLevel(4); Destroy(MenuSound.Instance.gameObject); });
    }
    public void showSelor()
    {
        title.sprite = selorSprite;
        panelWindow.SetActive(true);

        for (int i = 0; i < selor.Length; i++)
        {
            GameObject button = Instantiate(btnPrefab, container.transform);
            button.GetComponent<ButtonMakanan>().makanan = selor[i];
            listButton.Add(button);
        }
        ShowStars(4);
        btnPlay.onClick.AddListener(() => { MenuManager.Instance.GoToLevel(5); Destroy(MenuSound.Instance.gameObject); });
    }
    public void showAceh()
    {
        title.sprite = acehSprite;
        panelWindow.SetActive(true);

        for (int i = 0; i < aceh.Length; i++)
        {
            GameObject button = Instantiate(btnPrefab, container.transform);
            button.GetComponent<ButtonMakanan>().makanan = aceh[i];
            listButton.Add(button);
        }
        ShowStars(5);
        btnPlay.onClick.AddListener(() => { MenuManager.Instance.GoToLevel(6); Destroy(MenuSound.Instance.gameObject); });
    }

    public void ShowStars(int levelNumber)
    {

        for (int j= 1; j < bintang.Length; j++)
        {
            bintang[j].SetActive(false);
        }

        int starCount = PlayerPrefs.GetInt("SaveStars" + levelNumber);
        if (starCount == 0) return;
        
        for (int j = 0; j <= starCount ; j++)
        {
            bintang[j].SetActive(true);
        }
    }

    public void Close()
    {
       //panelWindow.SetActive(false) ;
        foreach(GameObject button in listButton)
        {
            Destroy(button);
        }
        listButton.Clear();
    }
}
