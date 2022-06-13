using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InGameButtonMakanan : MonoBehaviour, IPointerDownHandler
{
    public GameObject descriptionPanel;
    public Button button;
    public Image gambarMakanan;
    public TextMeshProUGUI namaMakanan;
    public Makanan makanan;


    private void Awake()
    {
        button.onClick.AddListener(()=> LevelManager.Instance.PlayClickSound());    
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        MakananManager.Instance.selectedMakanan = makanan;
        descriptionPanel.SetActive(true);
    }



    // Start is called before the first frame update
    void Start()
    {
        if (makanan == null) return;
        namaMakanan.text = makanan.nama;
        gambarMakanan.sprite = makanan.sprite;
    }

}