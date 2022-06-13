using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class LevelManager : MonoBehaviour
{
    [Header("Level Elements")]
    //Testing Save User Data
    public int levelNumber = 1;
    //public int levelToUnlock = 2;
    public float countDownAngka = 4;
    public float globalTimer = 60;
    bool mulai = false;

    public int totalPesanan = 0;
    public int completePesanan = 0;

    public int TargetUang = 150000;

    

    public int emotionPoint = 7;
    public int uang = 50000;
    

    public int destroyTime = 3;

    public Coroutine popUpCoroutine;
    public Coroutine timerCoroutine;
    public float phaseTime = 0;
    
    public bool isPoppingUp;
    public int currentPesanan;


   // public GameObject playableBlock;
    
    
    
    public GameObject prefabPesanan;

    [Header("Phasing Related Var")]
    public int minPesanan = 2;
    public int maxPesanan = 4;
    public float waitBetweenPopUp = .5f; 
    public float waitBetweenPhase = 12f;

        
    public enum JenisPembeli
    {
        Anak = 1,
        Dewasa = 2,
        Tua = 3
    }
    [Header("UI Elements")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI uangText;
    public TextMeshProUGUI targetText;
    public TextMeshProUGUI countDown;

    public TextMeshProUGUI completeTotalPesanan;
    public TextMeshProUGUI completeJumlahPesanan;
    public TextMeshProUGUI completeUang;
    public GameObject failedPanel;
    public Slider slider;
    public Slider completeSlider;
    public GameObject panelComplete;

    public AudioClip failedSfx;
    public AudioClip completedSfx;
    public bool isLevelComplete = false;

    [Header("Level Objects")]
    public GameObject[] rumah = new GameObject[8];
    public GameObject[] bintang = new GameObject[3];

    [Header("Rumah Makan PopUp")]
    public GameObject[] restoran = new GameObject[8];




    [Header("Audio")]
    public AudioSource source;
    public AudioClip clip;
    public AudioClip clickSound;

    public GameObject tutorial;

    delegate void _delegate();
    _delegate m_delegate;





    private static LevelManager _instance;

    public static LevelManager Instance
    {
        get
        {
            
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<LevelManager>();
            }

            return _instance;
        }
    }
    private void Awake()
    {
        DOTween.Init();
        
    }

    private void Start()
    {
        targetText.text = "" + TargetUang;
        //if (MenuSound.Instance.isMuted) source.mute = true;

    }


    

    private void Update()
    {
        if (PlayerPrefs.GetInt("levelReach") > 0)
        {
            tutorial.SetActive(false);
            StartGame();

        }
        if (m_delegate == null) return;
        m_delegate();








    }

    void OnDestroy()
    {
        m_delegate -= StartGame;
    }

    public void StartGamePlay()
    {
        m_delegate += StartGame;
    }

    public void StartGame()
    {
        tutorial.SetActive(false);
        countDownAngka -= Time.deltaTime;
        countDown.text = "" + (int)countDownAngka;

        if (countDownAngka <= 1)
        {
            if (!mulai)
            {
                timerCoroutine = StartCoroutine(GlobalTiming());
                mulai = true;
                source.clip = clip;
                source.loop = true;
                source.Play();

                for (int i = 0; i < restoran.Length; i++)
                {
                    restoran[i].SetActive(true);
                }
            }
            countDown.transform.gameObject.SetActive(false);
            

            slider = GameObject.Find("Affection Meter").GetComponent<Slider>();


            globalTimer -= Time.deltaTime;
            timerText.text = "" + (int)globalTimer;
            slider.value = emotionPoint;
            uangText.text = "" + uang;


        }

        if (emotionPoint >= 15)
        {
            emotionPoint = 15;
        }

        if (globalTimer <= 0 && !isLevelComplete)
        {

            globalTimer = 0;
            isLevelComplete = true;
            if ((uang < TargetUang) && isLevelComplete)
            {

                source.Stop();
                source.PlayOneShot(failedSfx);
                failedPanel.GetComponent<PopupSlider>().ShowPopupComplete(0);
                isLevelComplete = true;
           
            }
            else
            {
               
                panelComplete.GetComponent<PopupSlider>().ShowPopupComplete(40);
                completeJumlahPesanan.text = "" + completePesanan;
                completeTotalPesanan.text = "" + totalPesanan;
                completeUang.text = "" + uang;
                
                completeSlider.value = emotionPoint;
                int bintangCount = 0;
                for (int i = 0; i < emotionPoint / 5; i++)
                {
                    bintang[i].SetActive(true);
                    bintangCount = i + 1;
                }
                if(GameManager.Instance.getBintang(levelNumber) < bintangCount)
                {
                    GameManager.Instance.getStars = bintangCount;
                    GameManager.Instance.uang = uang;
                    GameManager.Instance.SaveData(levelNumber);
                }

                isLevelComplete = true;
                source.Stop();
                source.PlayOneShot(completedSfx);

            }
        }

        if ((emotionPoint <= 0 || uang <= 0) && !isLevelComplete)
        {
            source.Stop();
            source.PlayOneShot(failedSfx);
            failedPanel.GetComponent<PopupSlider>().ShowPopupComplete(0);
            isLevelComplete = true;
          
        }

      
    }

    public void PlayClickSound()
    {
        LevelManager.Instance.source.PlayOneShot(clickSound);

    }

    public void StartPhasePesanan() {
        currentPesanan = Random.Range(minPesanan,maxPesanan + 1);
        rumah = RandomArray(rumah);
        popUpCoroutine = StartCoroutine(PopPesanan(currentPesanan));

    }

    IEnumerator GlobalTiming()
    {
        while (true)
        {
            StartPhasePesanan();
            yield return new WaitForSeconds(waitBetweenPhase);

        }

    }


    private IEnumerator PopPesanan(int count)
    {
        

            isPoppingUp = true;
        
            for (int index = 0; index < count; index++)
            {



            GameObject pesanan = Instantiate(prefabPesanan, rumah[index].transform);
            pesanan.transform.localScale = Vector3.zero;
            pesanan.transform.DOScale(new Vector3(2f, 2f, 2f), 1f).SetEase(Ease.OutBounce);
            totalPesanan++;

            
            yield return new WaitForSeconds(waitBetweenPopUp);

            }

            isPoppingUp = false;
        
        
            //yield return new WaitForSeconds(12);
       
       
        popUpCoroutine = null;

    }
    #region Utillities Function 
    

    Transform[] RandomArray(Transform[] a)
    {
        
        Transform[] array = a;
        for (int i = 0; i < a.Length; i++)
        {
            int rand = Random.Range(0, a.Length);
            Transform temp = array[rand];
            array[rand] = array[i];
            array[i] = temp;
        }
        return array;
    }
    GameObject[] RandomArray(GameObject[] a)
    {

        GameObject[] array = a;
        for (int i = 0; i < a.Length; i++)
        {
            int rand = Random.Range(0, a.Length);
            GameObject temp = array[rand];
            array[rand] = array[i];
            array[i] = temp;
        }
        return array;
    }

    public Makanan[] RandomArray(Makanan[] a)
    {

        Makanan[] array = a;
        for (int i = 0; i < a.Length; i++)
        {
            int rand = Random.Range(0, a.Length);
            Makanan temp = array[rand];
            array[rand] = array[i];
            array[i] = temp;
        }
        return array;
    }

    Sprite[] RandomArray(Sprite[] a)
    {

        Sprite[] array = a;
        for (int i = 0; i < a.Length; i++)
        {
            int rand = Random.Range(0, a.Length);
            Sprite temp = array[rand];
            array[rand] = array[i];
            array[i] = temp;
        }
        return array;
    }

    #endregion


}
