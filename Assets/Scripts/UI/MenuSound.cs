using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    public AudioClip bgSound;
    public AudioClip clickSound;
    public AudioSource source;
    public bool isMuted;

    #region Singleton
    private static MenuSound _instance;

    public static MenuSound Instance
    {
        get
        {

            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<MenuSound>();
            }

            return _instance;
        }
    }
    #endregion
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayBGSound();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMuted) GameObject.FindObjectOfType<AudioSource>().mute = true;
        else GameObject.FindObjectOfType<AudioSource>().mute = false;
    }

   public void PlayBGSound()
   {
        source.clip = bgSound;
        source.loop = true;
        source.Play();

        
   }

    public void PlayClickSound()
    {
        source.PlayOneShot(clickSound);
      
    }

    public void OffBGSound()
    {
        isMuted = true;
    }
    public void OnBGSound()
    {
        isMuted = false;
    }
}
