using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{

    private bool isDragging = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopDragging(Vector2 releasePos)
    {
        // find distance
        // clamp to min/max 
        // fire projectile
    }

    void OnTouchMove(Vector2 touchPos)
    {
        transform.position = touchPos;
    }
}
