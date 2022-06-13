using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
public class MenuManager : MonoBehaviour
{
   

    public Makanan selectedMakanan;

    [Header("Makanan Description")]
    public MakananDescription makananDescription;
    public Image gambar;
    public Makanan makanan;
    public TextMeshProUGUI deskripsi;
    public Button btnExit;


    public PopupSlider popupSlider;
    public GameObject popupPanel;
    public GameObject popupExitBtn;
    public GameObject panelBlur;


    #region Singleton
    private static MenuManager _instance;

    public static MenuManager Instance
    {
        get
        {

            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<MenuManager>();
            }

            return _instance;
        }
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        if (selectedMakanan == null) return;
        gambar.sprite = selectedMakanan.sprite;
        deskripsi.text = selectedMakanan.description;
    }

    
    public void GoToLevel(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void ResetProgress()
    {

        // PlayerPrefs.SetInt("levelReach", 1);
        Destroy(MenuSound.Instance.gameObject);
        PlayerPrefs.DeleteAll();
        MenuSound.Instance.source.Stop();
        Destroy(GameManager.Instance.gameObject);

        var request = new UpdateUserDataRequest {
            Data = new Dictionary<string, string>{
                {"levelReach", null},
                {"SaveUang", null},
                {"SaveStars1", null},
                {"SaveStars2", null},
                {"SaveStars3", null},
                {"SaveStars4", null},
                {"SaveStars5", null}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);


        SceneManager.LoadScene(1);
    //     Debug.Log(PlayerPrefs.GetInt("levelReach"));
    //     Debug.Log(PlayerPrefs.GetInt("SaveUang"));
    //     Debug.Log(PlayerPrefs.GetInt("SaveStars" + 1));
    }

    void OnDataSend(UpdateUserDataResult result){
        //Debug.Log("Successful user data send!");
    }

    void OnError(PlayFabError error) {
        //Debug.Log("Error while logging in/creating account!");
        //Debug.Log(error.GenerateErrorReport());
    }

    public void CloseApp()
    {
        Application.Quit();
    }


   
}


