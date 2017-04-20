using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : Purchasable
{

    [Range(0.0f, 10.0f)]
    public float mShotVariance;

    [Range(0.0f, 15.0f)]
    public float mFireForce;

    public LayerMask defaultLayer;
    public LayerMask touchLayer;

    // Use this for initialization
    void Start ()
    {
        gameObject.layer = touchLayer.value;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public Vector2 GetBoost()
    {
        Vector2 outVec = new Vector2();
        float theta = Mathf.Deg2Rad * Random.Range(-mShotVariance, mShotVariance);

        float cos = Mathf.Cos(theta);
        float sin = Mathf.Sin(theta);

        outVec.x = transform.up.x * cos - transform.up.y * sin;
        outVec.y = transform.up.x * sin + transform.up.y * cos;

        return outVec * mFireForce;
    }

    #region Touch Methods
    void OnTouchBegin(Vector2 pos)
    {
        switch (mPurchasedState)
        {
            case EPurchasableState.Waiting:
                mPurchasedState = EPurchasableState.Moving;
                break;
            case EPurchasableState.Placed:
                break;
            default:
                break;
        }
    }

    void OnTouchMove(Vector2 pos)
    {
        switch (mPurchasedState)
        {

            case EPurchasableState.Moving:
                transform.position = pos;
                break;
            case EPurchasableState.Placed:
                break;
            default:
                break;
        }
    }

    void OnTouchExit(Vector2 pos)
    {
        switch (mPurchasedState)
        {

            case EPurchasableState.Moving:
                mPurchasedState = EPurchasableState.Placed;
                break;
            case EPurchasableState.Placed:
                mPurchasedState = EPurchasableState.Active;
                gameObject.layer = defaultLayer.value;
                break;
            default:
                break;
        }
    }
    #endregion
}
