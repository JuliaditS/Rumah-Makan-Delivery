using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonMakanan : MonoBehaviour, IPointerDownHandler
{
    public GameObject descriptionPanel;
    public Button button;
    public Image gambarMakanan;
    public TextMeshProUGUI namaMakanan;
    public Makanan makanan;
    public MenuSound sound;

    private void Awake()
    {
        sound = GameObject.Find("MusicContainer").GetComponent<MenuSound>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        MenuManager.Instance.selectedMakanan = makanan;
        MenuManager.Instance.popupSlider.ShowPopupSliderNoBlur(24);
        sound.PlayClickSound();
    }

    // Start is called before the first frame update
    void Start()
    {

        namaMakanan.text = makanan.nama;
        gambarMakanan.sprite = makanan.sprite;
    }

   

}
