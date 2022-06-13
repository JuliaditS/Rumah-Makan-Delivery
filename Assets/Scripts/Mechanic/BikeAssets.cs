using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeAssets : MonoBehaviour
{
    public Sprite[] spriteBike;
    
    private float lastX;
    private float lastY;

    private SpriteRenderer spRender;

    void Start()
    {
        lastX = transform.position.x;
        lastY = transform.position.y;

        spRender = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (lastX > transform.position.x)
        {
            lastX = transform.position.x;
            spRender.sprite = spriteBike[0];
            spRender.flipX = false;
        }

        if (lastX < transform.position.x)
        {
            lastX = transform.position.x;
            spRender.sprite = spriteBike[0];
            spRender.flipX = true;
        }

        if (lastY < transform.position.y)
        {
            lastY = transform.position.y;
            spRender.sprite = spriteBike[2];
        }
        
        if (lastY > transform.position.y)
        {
            lastY = transform.position.y;
            spRender.sprite = spriteBike[1];
        }
    }
}

