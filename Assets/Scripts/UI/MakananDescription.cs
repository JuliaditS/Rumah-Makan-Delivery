using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MakananDescription : MonoBehaviour
{
    public Image gambar;
    public Makanan makanan;
    public TextMeshProUGUI deskripsi;
    public Button btnExit;
    





    // Start is called before the first frame update
    void Start()
    {
        btnExit.onClick.AddListener(()=> { MenuManager.Instance.popupSlider.HidePopupSlider(720); });
        
    }
  

}
