using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RumahMakan : MonoBehaviour
{
    public Makanan makanan;
    public TextMeshProUGUI nama;
    public SpriteRenderer gambar;
    public TextMeshProUGUI harga;
    // Start is called before the first frame update
    void Start()
    {
        gambar.sprite = makanan.sprite;
        harga.text = makanan.harga.ToString().Substring(0,2) + "K";
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
