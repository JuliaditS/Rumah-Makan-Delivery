using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class GameManager : MonoBehaviour
{
    public int getStars;
    public int uang;


    #region Singleton
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {

            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }
    #endregion
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int getBintang(int levelNumber)
    {
        return PlayerPrefs.GetInt("SaveStars" + levelNumber);

        // int bintang=0;
        // PlayFabClientAPI.GetUserData(new GetUserDataRequest(), 
        // result=>{
        //     Debug.Log("Recieved user data!");
        //     if (result.Data != null && result.Data.ContainsKey("SaveStars" + levelNumber))
        //         bintang=int.Parse(result.Data["SaveStars" + levelNumber].Value);
        //     else 
        //         Debug.Log("No Data");
        // }, OnError);
        // return bintang;
    }

    public void SaveData(int levelNumber)
    {
        int levelreach = levelNumber + 1;
        int saveuang = uang + PlayerPrefs.GetInt("SaveUang");

        PlayerPrefs.SetInt("levelReach", levelreach);
        PlayerPrefs.SetInt("SaveUang", saveuang);
        PlayerPrefs.SetInt("SaveStars" + levelNumber, getStars);
        PlayerPrefs.Save();
        
        //Playfabs save
        var request = new UpdateUserDataRequest {
            Data = new Dictionary<string, string>{
                {"levelReach", levelreach.ToString()},
                {"SaveUang", saveuang.ToString()},
                {"SaveStars" + levelNumber, getStars.ToString()}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);

    }

    void OnDataSend(UpdateUserDataResult result){
        //Debug.Log("Successful user data send!");
    }

    void OnError(PlayFabError error) {
        //Debug.Log("Error while logging in/creating account!");
        //Debug.Log(error.GenerateErrorReport());
    }
    //
}
