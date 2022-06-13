using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour
{
    
    public GameObject pausePanel;
    public Physics2DRaycaster raycaster;

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        Destroy(GameManager.Instance.gameObject);
        SceneManager.LoadScene(1);
        
    }
    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        LevelManager.Instance.source.Pause();
    }
    public void CompleteGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        
    }
    public void Resume()
    {
        //pausePanel.SetActive(false);
        Time.timeScale = 1;
        LevelManager.Instance.source.UnPause();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void MuteSound()
    {
        LevelManager.Instance.source.mute = true;
    }

    public void UnmuteSound()
    {
        LevelManager.Instance.source.mute = false;

    }
}
