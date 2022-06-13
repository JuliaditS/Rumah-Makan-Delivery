using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TutorialsAnim : MonoBehaviour
{
    public GameObject tangan;
    public GameObject blink;
    public GameObject ojek;
    public GameObject orang;
    public GameObject popup_drag;
    public GameObject popup_pesanan;
    public GameObject popup_rm;
    public GameObject popup_saldo;
    public TextMeshProUGUI textTut;
    public GameObject buttons;

    void OnEnable()
    {
        // Called when you enable this gameobject
        StartCoroutine(AnimStep());
    }

    void Awake()
    {
        doReset();
    }

    void Start()
    {
        
    }

    public void doReset()
    {
        blink.transform.localScale = new Vector3(0, 0, 0);
        orang.transform.localScale = new Vector3(0, 0, 0);
        popup_drag.transform.localScale = new Vector3(0, 0, 0);
        popup_pesanan.transform.localScale = new Vector3(0, 0, 0);
        popup_rm.transform.localScale = new Vector3(0, 0, 0);
        popup_saldo.transform.localScale = new Vector3(0, 0, 0);
        buttons.transform.localScale = new Vector3(0, 0, 0);
        buttons.SetActive(false);
        tangan.GetComponent<RectTransform>().anchoredPosition = new Vector2(-3, 33);
    }

    IEnumerator AnimStep()
    {
        // Step 1 - Muncul Popup_RM dan Popup_Pesanan
        popup_rm.SetActive(true);
        yield return popup_rm.transform.DOScale(new Vector3(0.86f, 0.86f, 0.86f), 1f).SetEase(Ease.OutBounce).WaitForCompletion();

        orang.SetActive(true);
        yield return orang.transform.DOScale(new Vector3(0.3f, 0.3f, 0.3f), 1f).SetEase(Ease.OutBounce).WaitForCompletion();

        popup_pesanan.SetActive(true);
        yield return popup_pesanan.transform.DOScale(new Vector3(1f, 1f, 1f), 1f).SetEase(Ease.OutBounce).WaitForCompletion();

        // Step 2 - Klik Pesanan Lalu Drag ke Popup_RM
        textTut.text = "Drag & Drop orders to the right restaurant";

        yield return tangan.GetComponent<RectTransform>().DOAnchorPos(new Vector3(185f, 45f, 0f), 1f).SetEase(Ease.OutSine).WaitForCompletion();
    
        blink.SetActive(true);
        yield return blink.transform.DOScale(new Vector3(0.22f, 0.22f, 0.22f), 0.4f).SetEase(Ease.InQuad).WaitForCompletion();
        blink.transform.DOScale(new Vector3(0f, 0f, 0f), 0.4f).SetEase(Ease.OutQuad);
        yield return popup_pesanan.transform.DOScale(new Vector3(0f, 0f, 0f), 0.4f).SetEase(Ease.OutQuad).WaitForCompletion();


        popup_pesanan.SetActive(false);
        popup_drag.SetActive(true);
        yield return popup_drag.transform.DOScale(new Vector3(1f, 1f, 1f), 1f).SetEase(Ease.OutBounce).WaitForCompletion();

        yield return tangan.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-182f, 25f, 0f), 1.4f).SetEase(Ease.OutSine).WaitForCompletion();
        
        
        popup_drag.transform.DOScale(new Vector3(0f, 0f, 0f), 0.4f).SetEase(Ease.OutQuad);
        yield return tangan.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-3f, 33f, 0f), 1.4f).SetEase(Ease.OutSine).WaitForCompletion();
        popup_drag.SetActive(false);

        // Step 3 - Tunggu ojek ke rumah lalu muncul Popup_Saldo, Klik untuk ambil
        textTut.text = "Take the money that appears to complete the order";
        yield return ojek.GetComponent<RectTransform>().DOAnchorPosX(1481f, 1f).SetEase(Ease.InOutQuad).WaitForCompletion();
        popup_saldo.SetActive(true);
        yield return popup_saldo.transform.DOScale(new Vector3(1f, 1f, 1f), 1f).SetEase(Ease.OutBounce).WaitForCompletion();

        yield return tangan.GetComponent<RectTransform>().DOAnchorPos(new Vector3(185f, 45f, 0f), 1f).SetEase(Ease.OutSine).WaitForCompletion();
        yield return blink.transform.DOScale(new Vector3(0.22f, 0.22f, 0.22f), 0.4f).SetEase(Ease.InQuad).WaitForCompletion();
        blink.transform.DOScale(new Vector3(0f, 0f, 0f), 0.4f).SetEase(Ease.OutQuad);
        yield return popup_saldo.transform.DOScale(new Vector3(0f, 0f, 0f), 0.4f).SetEase(Ease.OutQuad).WaitForCompletion();
        popup_saldo.SetActive(false);

        // Muncul Buttons
        buttons.SetActive(true);
        yield return buttons.transform.DOScale(new Vector3(0.975f, 0.975f, 0.975f), 1f).SetEase(Ease.OutBounce).WaitForCompletion();
    }

    public void btnResetOnClick()
    {
        doReset();
        StartCoroutine(AnimStep());
    }
}
