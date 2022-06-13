using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pesanan : MonoBehaviour
{
    public Makanan finalPesanan;
    public Makanan[] makanan = new Makanan[2];
    public Sprite[] pembeliSprite = new Sprite[2];
    public GameObject prefabUang;

    public AudioClip[] voice = new AudioClip[44]; //ada 11 chara, tiap chara ada 4 sound, sound 1 drop bener, 2 salah, 3 lama, 4

    public bool isComplete = false;
  
    public GameObject pembeli;
    
    public SpriteRenderer spriteMakanan;
    public SpriteRenderer spritePembeli;
    public SpriteRenderer spritePesanan;
    public SpriteRenderer spriteDragging;
    public string namaPesanan;
    public Transform rumah;
    

    public float timer;

    public delegate void _delegate();
    public _delegate m_delegate;
    

    public bool isDropped;
    float timeDestroy;

    public bool isDropBener;

    

    public bool isPesananSampe = false;


    public LevelManager.JenisPembeli jenis;
    private void Awake()
    {
        makanan = LevelManager.Instance.RandomArray(makanan);
        spriteMakanan.sprite = makanan[0].sprite;

        jenis = (LevelManager.JenisPembeli)Random.Range(1,4);

        finalPesanan = makanan[0];

        timer = LevelManager.Instance.destroyTime;
        m_delegate += DestroyPesanan;
        m_delegate += Flashing;
        switch (jenis)
        {
            case LevelManager.JenisPembeli.Anak:
                {
                    timeDestroy = 5;
                    
                    break;
                }
            case LevelManager.JenisPembeli.Dewasa:
                {
                    timeDestroy = 8;
                    break;
                }
            case LevelManager.JenisPembeli.Tua:
                {
                    timeDestroy = 10;

                    break;
                }

            default: break;
        }
        isDropped = false;
        SelectCharacter();


    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (m_delegate == null)
            return;
        else m_delegate();

        

        
    }

    public void DestroyPesanan()
    {
        if (isDropped)
        {
            timeDestroy = timer;
            isDropped = false;
            return;
        }
        timeDestroy -= Time.deltaTime;
   

        
        if (timeDestroy <= 0)
        {
            if (!isComplete)
            {
                LevelManager.Instance.emotionPoint -= 1;
                Destroy(gameObject);

            }
        }

    }

    
    
    public void Flashing()
    {
        if (timeDestroy <= 3)
        {
            spritePembeli.color = new Color(1, 1, 1, Mathf.Sin(Time.time * 5) + 1.3f);
            spriteMakanan.color = new Color(1, 1, 1, Mathf.Sin(Time.time * 5) + 1.3f);
            spritePesanan.color = new Color(1, 1, 1, Mathf.Sin(Time.time * 5) + 1.3f);
            spriteDragging.color = new Color(1, 1, 1, Mathf.Sin(Time.time * 5) + 1.3f);
        }
    }
    public void CancelFlashing()
    {
        spritePembeli.color = new Color(1, 1, 1, 1);
    }


    void SelectCharacter()
    {
        switch (jenis)
        {
            case LevelManager.JenisPembeli.Anak:
                {
                    spritePembeli.sprite = pembeliSprite[Random.Range(0,2)];
                    break;
                }
            case LevelManager.JenisPembeli.Dewasa:
                {
                    spritePembeli.sprite = pembeliSprite[Random.Range(2, 4)];
                    break;
                }
            case LevelManager.JenisPembeli.Tua:
                {
                    spritePembeli.sprite = pembeliSprite[Random.Range(4, 6)];
                    break;
                }

            default: break;
        }
    }

  

    public void MunculDuit(Makanan makanan, Transform rumah)
    {
        GameObject uangOG = Instantiate(prefabUang, rumah);
        uangOG.transform.localScale = Vector3.zero;
        Uang uang = uangOG.GetComponent<Uang>();
        uang.makanan = makanan;

        uangOG.transform.DOScale(new Vector3(4.5f, 4.5f, 4.5f), 1f).SetEase(Ease.OutBounce);

    }

}
