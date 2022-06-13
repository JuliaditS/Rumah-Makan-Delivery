using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    
    
    public SpriteRenderer spriteRenderer;
    public GameObject dragging;

    public Sprite defaultSprite;
    //public Sprite draggingSprite;
    public GameObject makanan;
    public AudioClip clickClip;
    


    private void Awake()
    {
        spriteRenderer.sprite = defaultSprite;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        gameObject.layer = 8;
        spriteRenderer.sprite = null;
        dragging.SetActive(true);
     
    }

    public void OnDrag(PointerEventData eventData)
    {
        

        transform.position =
            new Vector3(Camera.main.ScreenToWorldPoint(eventData.position).x, Camera.main.ScreenToWorldPoint(eventData.position).y, -0.28f);
            

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        gameObject.layer = 0;
        transform.localPosition = Vector3.zero ;
        spriteRenderer.sprite = defaultSprite;
        dragging.SetActive(false);

    }



    public void OnPointerDown(PointerEventData eventData)
    {
        LevelManager.Instance.source.PlayOneShot(clickClip);
    }

    
}

    

