using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster_Shop : Purchasable {

    private bool mIsPlaced = false;

    private float mPlaceRotation;

    private CircleCollider2D mCircleCollider;

	// Use this for initialization
	void Start ()
    {
        mCircleCollider = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTouchBegin(Vector2 pos)
    {
        mFingerOffset = (Vector2)transform.position - pos;
    }

    void OnTouchMove(Vector2 pos)
    {
        if (!mIsPlaced)
        {
            transform.position = pos + mFingerOffset;
        }
        else
        {
            mPlaceRotation = 180 + Mathf.Atan2(transform.position.y-pos.y, transform.position.x - pos.x) * Mathf.Rad2Deg;
            Debug.Log("Pos: " + transform.position.ToString() + " Finger: " + pos.ToString() + " Rotation: " + mPlaceRotation.ToString("N2") );
            transform.rotation = Quaternion.Euler(0, 0, -90 + mPlaceRotation);
        }
    }

    void OnTouchExit(Vector2 pos)
    {

        if (!mIsPlaced)
        {
            mIsPlaced = true;
            mCircleCollider.offset = Vector2.zero;
        }
        else
        {
            var fieldObject = Instantiate(mFieldVersion, transform.position, transform.rotation);
            transform.position = mStartPos;
            gameObject.SetActive(false);
        }
    }
}
