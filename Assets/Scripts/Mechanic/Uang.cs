using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Uang : MonoBehaviour, IPointerClickHandler
{
    public Makanan makanan;
    public SpriteRenderer uangSprite;
    public float timeDestroy = 8;
    public AudioClip uangSound;
    public int harga;
   

    // Start is called before the first frame update
    void Start()
    {
        uangSprite = GetComponent<SpriteRenderer>();
    }
    

    // Update is called once per frame
    void Update()
    {
        timeDestroy -= Time.deltaTime;
        Flashing();
    }
    private void Awake()
    {
        
        
    }


    
    public void Flashing()
    {
        if (timeDestroy <= 3)
        {
            uangSprite.color = new Color(1, 1, 1, Mathf.Sin(Time.time * 5) + 1.3f);
        }
        if (timeDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        LevelManager.Instance.uang += makanan.harga;
        LevelManager.Instance.source.PlayOneShot(uangSound);
        Destroy(gameObject);
    }
}
