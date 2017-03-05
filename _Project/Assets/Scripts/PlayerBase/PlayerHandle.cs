using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandle : MonoBehaviour {

    private bool mIsHeld;
    private SpriteRenderer mSpriteRenderer;

	// Use this for initialization
	void Start () {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTouchBegin(Vector2 pos)
    {
        mIsHeld = true;
        mSpriteRenderer.enabled = true;
    }

    void OnTouchMove(Vector2 pos)
    {
        transform.position = pos;
    }

    void OnTouchExit(Vector2 pos)
    {
        mIsHeld = false;
        mSpriteRenderer.enabled = false;
        transform.localPosition = Vector2.zero;
    }

}
