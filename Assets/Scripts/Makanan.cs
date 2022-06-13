using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Makanan",menuName = "Assets/Makanan")]
public class Makanan : ScriptableObject
{
    /// <summary>
    /// 
    /// </summary>
    public string nama;
    public Sprite sprite;
    public string description;
    public int harga;
    public string id;

}
