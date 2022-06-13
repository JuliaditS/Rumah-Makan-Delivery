using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PopupSlider : MonoBehaviour
{
    [Header("Gameobjects")]
    public GameObject popupPanel;
    public GameObject popupExitBtn;
    public GameObject panelBlur;

    private float _panelPositionY;
    public Pause pause;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
    }

    IEnumerator SlidePanelIn()
    {
        Tween myTween = popupPanel.GetComponent<RectTransform>().DOAnchorPosY(_panelPositionY, 0.8f, true).SetEase(Ease.OutBounce);
        yield return myTween.WaitForCompletion();
        

        popupExitBtn.GetComponent<Image>().DOFade(255, 2);
    }

    IEnumerator SlidePanelOut()
    {
        Tween myTween = popupPanel.GetComponent<RectTransform>().DOAnchorPosY(_panelPositionY, 0.8f, true);
        yield return myTween.WaitForCompletion();

        popupExitBtn.GetComponent<Image>().DOFade(0, 2);
        panelBlur.SetActive(false);
    }

    public void ShowPopupSlider(float positionY)
    {
        _panelPositionY = positionY;
        panelBlur.SetActive(true);
        StartCoroutine("SlidePanelIn");
    }

    public void HidePopupSlider(float positionY)
    {
        _panelPositionY = positionY;
        StartCoroutine("SlidePanelOut");
    }

    IEnumerator SlidePanelOutNoBlur()
    {
        Tween myTween = popupPanel.GetComponent<RectTransform>().DOAnchorPosY(_panelPositionY, 0.8f, true);
        yield return myTween.WaitForCompletion();

        popupExitBtn.GetComponent<Image>().DOFade(0, 2);
    }

    public void ShowPopupSliderNoBlur(float positionY)
    {
        _panelPositionY = positionY;
        StartCoroutine("SlidePanelIn");
    }
    public void HidePopupSliderNoBlur(float positionY)
    {
        _panelPositionY = positionY;
        StartCoroutine("SlidePanelOutNoBlur");
    }

    IEnumerator SlidePanelInNoExit()
    {
        Tween myTween = popupPanel.GetComponent<RectTransform>().DOAnchorPosY(_panelPositionY, 0.8f, false).SetEase(Ease.OutBounce);
        yield return myTween.WaitForCompletion();
        pause.PauseGame();


    }

    IEnumerator SlidePanelOutNoExit()
    {
        pause.Resume();
        Tween myTween = popupPanel.GetComponent<RectTransform>().DOAnchorPosY(_panelPositionY, 0.4f, true);
        yield return myTween.WaitForCompletion();

        panelBlur.SetActive(false);
    }
    IEnumerator SlidePanelInComplete()
    {
        Tween myTween = popupPanel.GetComponent<RectTransform>().DOAnchorPosY(_panelPositionY, 0.8f, false).SetEase(Ease.OutBounce);
        yield return myTween.WaitForCompletion();
        pause.CompleteGame();


    }

    public void ShowPopupSliderNoExit(float positionY)
    {
        _panelPositionY = positionY;
        panelBlur.SetActive(true);
        StartCoroutine("SlidePanelIn");
    }
    public void HidePopupSliderNoExit(float positionY)
    {
        _panelPositionY = positionY;
        StartCoroutine("SlidePanelOut");
    }

    public void ShowPopupPause(float positionY)
    {
        _panelPositionY = positionY;
        panelBlur.SetActive(true);
        StartCoroutine("SlidePanelInNoExit");
    }
    public void ShowPopupComplete(float positionY)
    {
        _panelPositionY = positionY;
        panelBlur.SetActive(true);
        StartCoroutine("SlidePanelInComplete");
    }

    public void Resume(float positionY)
    {
        _panelPositionY = positionY;
        StartCoroutine("SlidePanelOutNoExit");
    }
}
