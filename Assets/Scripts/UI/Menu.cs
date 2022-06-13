using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public GameObject levelPanel;
    public GameObject prefabsButton;

    public void OpenLevelSelect()
    {
        levelPanel.SetActive(true);
        prefabsButton.SetActive(false);
    }

    public void CloseLevelSelect()
    {
        levelPanel.SetActive(false);
        prefabsButton.SetActive(true);
    }

}
