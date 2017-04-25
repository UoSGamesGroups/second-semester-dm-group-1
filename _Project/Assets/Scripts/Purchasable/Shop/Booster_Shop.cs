using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster_Shop : Purchasable_Shop {

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

    new void OnTouchMove(Vector2 pos)
    {
        if (!mIsPlaced)
        {
            base.OnTouchMove(pos);
        }
        else
        {
            mPlaceRotation = 180 + Mathf.Atan2(transform.position.y-pos.y, transform.position.x - pos.x) * Mathf.Rad2Deg;
            //Debug.Log("Pos: " + transform.position.ToString() + " Finger: " + pos.ToString() + " Rotation: " + mPlaceRotation.ToString("N2") );
            transform.rotation = Quaternion.Euler(0, 0, -90 + mPlaceRotation);
        }
    }

    new void OnTouchExit(Vector2 pos)
    {

        if (!mIsPlaced)
        {
            mIsPlaced = true;
            mCircleCollider.offset = Vector2.zero;
        }
        else
        {
            Purchasable_Field fieldObject = Instantiate(mFieldVersion, transform.position, Quaternion.Euler(0, 0, -90 + mPlaceRotation));
            mFieldVersion.Init(mPlayerColour);

            transform.position = mStartPos;
            gameObject.SetActive(false);
        }
    }
}
